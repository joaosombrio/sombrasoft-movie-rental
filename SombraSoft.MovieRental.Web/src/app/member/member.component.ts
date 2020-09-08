import { Component, OnInit } from "@angular/core"
import { Member } from '../models/member.model';
import { MemberService } from '../services/member.service';

@Component({
  selector: "app-member",
  templateUrl: "./member.component.html",
  styleUrls: ["./member.component.scss"]
})
export class MemberComponent implements OnInit {
  members: Member[] = [];
  displayedMembers: Member[] = [];
  member: Member;
  filter: string;
  constructor(private memberService: MemberService) {}

  async ngOnInit(): Promise<void> {
    await this.fetchMembers();
  }

  filterMembers(): void {
    if(!this.filter) this.displayedMembers = [...this.members];
    this.displayedMembers = this.members.filter(m => m.fullName.toLowerCase().includes(this.filter.toLowerCase()));
  }

  async fetchMembers(): Promise<void> {
    this.members = await this.memberService.getAll();
    this.displayedMembers = [...this.members];
  }
}
