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
   addFood(food: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, food);
  }
  updateFood(id: number, food: any): Observable<any> {
  return this.http.put<any>(`${this.apiUrl}/${id}`, food);
}

// Delete food item
deleteFood(id: number): Observable<any> {
  return this.http.delete<any>(`${this.apiUrl}/${id}`);
}
}