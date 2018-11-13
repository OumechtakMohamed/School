import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {UserService} from './shared/user.service';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
