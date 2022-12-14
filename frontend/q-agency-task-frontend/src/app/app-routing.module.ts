import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailAddComponent } from './email-add/email-add/email-add.component';
import { HistoryOverviewComponent } from './history/history-overview/history-overview.component';

const routes: Routes = [
  { path: '', redirectTo: '/add', pathMatch: 'full' },
  { path: 'add', component:  EmailAddComponent},
  { path: 'history', component:  HistoryOverviewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
