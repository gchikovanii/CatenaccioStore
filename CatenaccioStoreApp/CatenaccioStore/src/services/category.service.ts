import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private categoryUrl = 'Category';
  private addCategoryUrl = 'Category/AddCategory';
  private deleteCategoryUrl = 'Category/Delete';
  private updateCategotyUrl = 'Category/Update'
  constructor(private http: HttpClient) {}

  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${environment.apiUrl}/${this.categoryUrl}`);
  }

  addCategory(category: { name: string }): Observable<any> {
    return this.http.post(`${environment.apiUrl}/${this.addCategoryUrl}`, category);
  }
  deleteCategory(categoryName: string): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/${this.deleteCategoryUrl}`, { params: { categoryName } });
  }
  updateCategory(categoryName: string, newCategoryName: string): Observable<any> {
    return this.http.put(`${environment.apiUrl}/${this.updateCategotyUrl}`, null, {
      params: { categoryName, newCategoryName }
    });
  }
}
