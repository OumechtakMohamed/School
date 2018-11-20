import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {UserService} from './services/users/user.service';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
import { appRoutes } from './config/routes';
import { ClasseService } from './services/classes/classe.service';
import { ForbiddenComponent } from './shared/forbidden/forbidden.component';
import { AuthGuard } from './resolvers/auth/auth.guard';
import { HomeComponent } from './views/home/home.component';
import { SignInComponent } from './views/sign-in/sign-in.component';
import { SignUpComponent } from './views/sign-up/sign-up.component';
import { UserComponent } from './views/user/user.component';
import { ProfileComponent } from './views/profile/profile/profile.component';
import { MystudentComponent } from './views/mystudent/mystudent/mystudent.component';
import { MyteacherComponent } from './views/myteacher/myteacher/myteacher.component';
import { ClassesComponent } from './views/classes/classes/classes.component';
import { ClasseDetailComponent } from './views/classe-detail/classe-detail/classe-detail.component';
import { AddClasseComponent } from './views/add-classe/add-classe/add-classe.component';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    UserComponent,
    SignUpComponent,
    HomeComponent,
    ForbiddenComponent,
    ProfileComponent,
    MystudentComponent,
    MyteacherComponent,
    ClassesComponent,
    ClasseDetailComponent,
    AddClasseComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UserService, AuthGuard, ClasseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
