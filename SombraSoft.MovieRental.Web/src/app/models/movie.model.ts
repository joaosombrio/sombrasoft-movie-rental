export interface Movie {
  id: string;
  title: string;
  year: number;
  genres: string[];
  runtime: number;
  director: string;
  writers: string;
  description: string;
  actors: string[];
  rating: number;
  releaseDate: Date;
  rentalDuration: number;
  rentalCost: number;
  updatedOn: Date;
}

