export interface Purchase {
  id: string;
  memberId: string;
  movieIds: string[];
  rentalDate: Date;
  rentalExpiry: Date;
  totalCost: number;
}

