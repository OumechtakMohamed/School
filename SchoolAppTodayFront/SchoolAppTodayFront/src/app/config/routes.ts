import {Routes} from '@angular/router';
import { AuthGuard } from '../resolvers/auth/auth.guard';
import { ForbiddenComponent } from '../shared/forbidden/forbidden.component';
import { HomeComponent } from '../views/home/home.component';
import { SignUpComponent } from '../views/sign-up/sign-up.component';
import { SignInComponent } from '../views/sign-in/sign-in.component';
import { UserComponent } from '../views/user/user.component';
import { ProfileComponent } from '../views/profile/profile/profile.component';
import { MystudentComponent } from '../views/mystudent/mystudent/mystudent.component';
import { MyteacherComponent } from '../views/myteacher/myteacher/myteacher.component';
import { ClassesComponent } from '../views/classes/classes/classes.component';
import { ClasseDetailComponent } from '../views/classe-detail/classe-detail/classe-detail.component';
import { AddClasseComponent } from '../views/add-classe/add-classe/add-classe.component';

export const appRoutes : Routes = [
  {path : 'home', component : HomeComponent, canActivate: [AuthGuard],data : {roles : ['Admin']}},
  {path: 'forbidden', component : ForbiddenComponent, canActivate : [AuthGuard]},
  {path : 'signup',  component : HomeComponent,
  children : [{path : '', component : SignUpComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classes',  component : HomeComponent,
  children : [{path : '', component : ClassesComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classe/detail/:code',  component : HomeComponent,
  children : [{path : '', component : ClasseDetailComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classe/add',  component : HomeComponent,
  children : [{path : '', component : AddClasseComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'mystudent',  component : HomeComponent,
  children : [{path : '', component : MystudentComponent}],canActivate: [AuthGuard],data : {roles : ['Student']}
  },
  {path : 'myteacher',  component : HomeComponent,
  children : [{path : '', component : MyteacherComponent}],canActivate: [AuthGuard],data : {roles : ['Teacher']}
  },
  {path: 'profile', component : HomeComponent,
  children : [{path : '', component : ProfileComponent}],canActivate: [AuthGuard],data : {roles : ['Admin','Student','Teacher']}
  },
  {path : 'login', component : UserComponent,
  children : [{path : '', component : SignInComponent}]
  },
  {
      path : '', redirectTo:'/login', pathMatch : 'full'
  }
];