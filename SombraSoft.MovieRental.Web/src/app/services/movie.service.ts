import { Injectable } from '@angular/core';
import { Movie } from '../models/movie.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  apiUrl = "https://localhost:5001";
  constructor(private http: HttpClient) { }

  getAll(): Promise<Movie[]> {
    return this.http.get<Movie[]>(`${this.apiUrl}/movies`).toPromise();
  }

  create(movie: Movie): Promise<Movie> {
    return this.http.post<Movie>(`${this.apiUrl}/movies`, movie).toPromise();
  }

  update(movie: Movie): Promise<Movie> {
    return this.http.put<Movie>(`${this.apiUrl}/movies/${movie.id}`, movie).toPromise();
  }

  delete(id: string): Promise<void> {
    return this.http.delete<void>(`${this.apiUrl}/movies/${id}`).toPromise();
  }
}
