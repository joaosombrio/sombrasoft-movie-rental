import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieComponent } from './movie/movie.component';
import { MemberComponent } from './member/member.component';
import { RentalHistoryComponent } from './rental-history/rental-history.component';
import { MemberSummaryComponent } from './member-summary/member-summary.component';

const routes: Routes = [
  { path: '', redirectTo: '/movies', pathMatch: 'full' },
  { path: 'movies', component: MovieComponent },
  { path: 'members', component: MemberComponent },
  { path: 'rental-history', component: RentalHistoryComponent },
  { path: 'member-summary', component: MemberSummaryComponent },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
