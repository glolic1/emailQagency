import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmailAddComponent } from './email-add/email-add/email-add.component';
import { HistoryOverviewComponent } from './history/history-overview/history-overview.component';

import { MessageModule } from 'primeng/message';
import { TabMenuModule } from 'primeng/tabmenu';
import { ReactiveFormsModule } from '@angular/forms';
import {InputTextModule} from 'primeng/inputtext';
import {ButtonModule} from 'primeng/button';
import { HttpClientModule } from '@angular/common/http';

import {TableModule} from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { ConfirmPopupModule } from "primeng/confirmpopup";
import { ToastModule } from "primeng/toast";
import { ConfirmationService, MessageService } from 'primeng/api';
@NgModule({
  declarations: [
    AppComponent,
    EmailAddComponent,
    HistoryOverviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MessageModule,
    TabMenuModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
    FormsModule,
    DropdownModule,
    HttpClientModule,
    InputTextareaModule,
    BrowserAnimationsModule,
    ConfirmPopupModule,
    ToastModule,
    TableModule
  ],
  providers: [ConfirmationService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
