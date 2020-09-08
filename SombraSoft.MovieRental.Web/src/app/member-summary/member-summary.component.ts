import { Component, OnInit } from "@angular/core";
import { MemberService } from '../services/member.service';
import { MemberSummary } from '../models/member-summary.model';

@Component({
  selector: "app-member-summary",
  templateUrl: "./member-summary.component.html",
  styleUrls: ["./member-summary.component.scss"]
})
export class MemberSummaryComponent implements OnInit {
  summaries: MemberSummary[] = [];
  displayedSummaries: MemberSummary[] = [];
  filter: string;
  constructor(private memberService: MemberService) {}

  async ngOnInit(): Promise<void> {
    await this.fetchMembers();
  }

  filterSummaries(): void {
    if(!this.filter) this.displayedSummaries = [...this.summaries];
    this.displayedSummaries = this.summaries.filter(m => m.memberFullName.toLowerCase().includes(this.filter.toLowerCase()));
  }

  async fetchMembers(): Promise<void> {
    this.summaries = await this.memberService.getSummaries();
    this.displayedSummaries = [...this.summaries];
  }
}
