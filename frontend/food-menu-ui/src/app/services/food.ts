import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Food {

  private apiUrl = 'https://localhost:7075/api/FoodItems';

  constructor(private http: HttpClient) {}

  getAllFoods(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}