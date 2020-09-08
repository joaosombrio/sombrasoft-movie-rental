import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Purchase } from '../models/purchase.model';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  apiUrl = 'http://localhost:5000';
  constructor(private http: HttpClient) { }

  getAll(): Promise<Purchase[]> {
    return this.http.get<Purchase[]>(`${this.apiUrl}/purchases`).toPromise();
  }

  create(purchase: Purchase): Promise<Purchase> {
    return this.http.post<Purchase>(`${this.apiUrl}/purchases`, purchase).toPromise();
  }

  update(purchase: Purchase): Promise<Purchase> {
    return this.http.put<Purchase>(`${this.apiUrl}/purchases/${purchase.id}`, purchase).toPromise();
  }

  delete(id: string): Promise<void> {
    return this.http.delete<void>(`${this.apiUrl}/purchases/${id}`).toPromise();
  }
}
