import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FoodList } from './components/food-list/food-list';

@Component({
  imports: [RouterOutlet, FoodList],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
}