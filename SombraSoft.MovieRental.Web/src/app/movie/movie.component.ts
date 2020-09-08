import { Component, OnInit } from "@angular/core";
import { Movie } from '../models/movie.model';
import { MovieService } from '../services/movie.service';

@Component({
  selector: "app-movie",
  templateUrl: "./movie.component.html",
  styleUrls: ["./movie.component.scss"]
})
export class MovieComponent implements OnInit {
  movies: Movie[] = [];
  displayedMovies: Movie[] = [];
  movie: Movie;
  showNew: Boolean = false;
  submitType: string = "Save";
  selectedRow: number;
  filter: string;
  constructor(private movieService: MovieService) {
  }

  async ngOnInit(): Promise<void> {
    await this.fetchMovies();
  }

  filterMovies(): void {
    if(!this.filter) this.filter = '';
    this.displayedMovies = this.movies.filter(m => m.title.toLowerCase().includes(this.filter.toLowerCase()));
  }

  async fetchMovies(): Promise<void> {
    this.movies = await this.movieService.getAll();
    this.displayedMovies = [...this.movies];
  }

  onNew() {
    this.submitType = 'Save';
    this.showNew = true;
    this.movie = <Movie>{};
  }

  async onSave(): Promise<void> {
    if (this.submitType === 'Save') {
      const newMovie = await this.movieService.create(this.movie);
      this.movies.unshift(newMovie);
      this.filterMovies();
    } else {
      const updatedMovie = await this.movieService.update(this.movie);
      this.movies.unshift(updatedMovie);
      this.filterMovies();
    }

    this.showNew = false;
  }

  onEdit(movie: Movie) {
    // Retrieve selected 
    this.movie = Object.assign({}, movie);
    this.submitType = 'Update';
    this.showNew = true;
  }

  async onDelete(movie: Movie): Promise<void> {
    await this.movieService.delete(movie.id);
    this.movies.splice(this.movies.findIndex(m => m.id == movie.id), 1);
    this.filterMovies();
  }

  onCancel() {
    this.showNew = false;
  }
}
