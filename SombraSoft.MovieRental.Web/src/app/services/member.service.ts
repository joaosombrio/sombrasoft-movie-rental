import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from '../models/member.model';
import { MemberSummary } from '../models/member-summary.model';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  apiUrl = 'http://localhost:5000';
  constructor(private http: HttpClient) { }

  getAll(): Promise<Member[]> {
    return this.http.get<Member[]>(`${this.apiUrl}/members`).toPromise();
  }

  getSummaries(): Promise<MemberSummary[]> {
    return this.http.get<MemberSummary[]>(`${this.apiUrl}/members/summaries`).toPromise();
  }

  create(member: Member): Promise<Member> {
    return this.http.post<Member>(`${this.apiUrl}/members`, member).toPromise();
  }

  update(member: Member): Promise<Member> {
    return this.http.put<Member>(`${this.apiUrl}/members/${member.id}`, member).toPromise();
  }

  delete(id: string): Promise<void> {
    return this.http.delete<void>(`${this.apiUrl}/members/${id}`).toPromise();
  }
}
