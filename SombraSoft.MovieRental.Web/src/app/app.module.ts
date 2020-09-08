import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MovieComponent } from './movie/movie.component';
import { HttpClientModule } from '@angular/common/http';
import { MemberComponent } from './member/member.component';
import { RentalHistoryComponent } from './rental-history/rental-history.component';
import { MemberSummaryComponent } from './member-summary/member-summary.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    MovieComponent,
    MemberComponent,
    RentalHistoryComponent,
    MemberSummaryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
