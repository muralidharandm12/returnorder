import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule,ReactiveFormsModule } from "@angular/forms"
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule,routingcomponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { Returnservice } from './service/returnservice.model';
import { ProcessfinalComponent } from './processfinal/processfinal.component';
import { CompletionprocessComponent } from './completionprocess/completionprocess.component';

@NgModule({
  declarations: [
    AppComponent,
    routingcomponent,
    ProcessfinalComponent,
    CompletionprocessComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule 
  ],
  providers: [Returnservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
