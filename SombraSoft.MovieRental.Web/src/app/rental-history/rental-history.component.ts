import { Component, OnInit } from "@angular/core";
import { Purchase } from '../models/purchase.model';
import { PurchaseService } from '../services/purchase.service';

@Component({
  selector: "app-rental-history",
  templateUrl: "./rental-history.component.html",
  styleUrls: ["./rental-history.component.scss"]
})
export class RentalHistoryComponent implements OnInit {
  purchases: Purchase[] = [];
  displayedPurchases: Purchase[] = [];
  purchase: Purchase;
  showNew: Boolean = false;
  submitType: string = "Save";
  selectedRow: number;
  filter: string;
  constructor(private purchaseService: PurchaseService) { }

  async ngOnInit(): Promise<void> {
    await this.fetchRentals();
  }

  filterPurchases(): void {
    if(!this.filter) this.filter = '';
    this.displayedPurchases = this.purchases.filter(p => p.memberId.toLowerCase().includes(this.filter.toLowerCase()));
  }

  async fetchRentals(): Promise<void> {
    this.purchases = await this.purchaseService.getAll();
    this.displayedPurchases = [...this.purchases];
  }
}
