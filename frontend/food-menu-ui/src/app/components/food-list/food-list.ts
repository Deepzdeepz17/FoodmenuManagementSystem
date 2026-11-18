import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';
import { RouterLink } from '@angular/router';

import { Food } from '../../services/food';

@Component({
  selector: 'app-food-list',
  imports: [RouterLink],
  templateUrl: './food-list.html',
  styleUrl: './food-list.css'
})
export class FoodList implements OnInit {

  foodItems: any[] = [];

  constructor(
    private foodService: Food,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.getFoods();
  }

  getFoods(): void {

    this.foodService.getAllFoods().subscribe({

      next: (data) => {
        this.foodItems = data;

        this.cdr.detectChanges();

        console.log('Food Items:', this.foodItems);
      },

      error: (error) => {
        console.log('Error fetching food items:', error);
      }

    });

  }

}