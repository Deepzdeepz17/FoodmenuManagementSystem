
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Food } from '../../services/food';
import { Auth } from '../../services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css'
})
export class AdminDashboard implements OnInit {

  foodItems: any[] = [];

  editingId: number | null = null;

  newFood = {
    name: '',
    category: '',
    description: '',
    price: 0,
    isAvailable: true
  };

  constructor(
    private foodService: Food,
    private authService: Auth,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getFoods();
  }

  getFoods(): void {
    this.foodService.getAllFoods().subscribe({
      next: (data) => {
        this.foodItems = data;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  addFood(): void {
    this.foodService.addFood(this.newFood).subscribe({
      next: () => {
        alert('Food added successfully!');
        this.resetForm();
        this.getFoods();
      },
      error: (error) => {
        console.log(error);
        alert('Unable to add food.');
      }
    });
  }

  editFood(food: any): void {
    this.editingId = food.id;

    this.newFood = {
      name: food.name,
      category: food.category,
      description: food.description,
      price: food.price,
      isAvailable: food.isAvailable
    };
  }

  updateFood(): void {
    if (this.editingId === null) return;

    this.foodService.updateFood(
      this.editingId,
      this.newFood
    ).subscribe({
      next: () => {
        alert('Food updated successfully!');
        this.resetForm();
        this.getFoods();
      },
      error: (error) => {
        console.log(error);
        alert('Unable to update food.');
      }
    });
  }

  deleteFood(id: number): void {
    if (confirm('Are you sure you want to delete this food item?')) {

      this.foodService.deleteFood(id).subscribe({
        next: () => {
          alert('Food deleted successfully!');
          this.getFoods();
        },
        error: (error) => {
          console.log(error);
          alert('Unable to delete food.');
        }
      });

    }
  }

  resetForm(): void {
    this.editingId = null;

    this.newFood = {
      name: '',
      category: '',
      description: '',
      price: 0,
      isAvailable: true
    };
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/admin-login']);
  }
}
