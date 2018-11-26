import {Routes} from '@angular/router';
import { AuthGuard } from '../resolvers/auth/auth.guard';
import { ForbiddenComponent } from '../shared/forbidden/forbidden.component';
import { MainContentComponent } from '../shared/main-content/main-content.component';
import { SignUpComponent } from '../views/sign-up/sign-up.component';
import { SignInComponent } from '../views/sign-in/sign-in.component';
import { UserComponent } from '../views/user/user.component';
import { ProfileComponent } from '../views/profile/profile/profile.component';
import { MystudentComponent } from '../views/mystudent/mystudent/mystudent.component';
import { MyteacherComponent } from '../views/myteacher/myteacher/myteacher.component';
import { ClassesComponent } from '../views/classes/classes/classes.component';
import { ClasseDetailComponent } from '../views/classes/classe-detail/classe-detail.component';
import { AddClasseComponent } from '../views/classes/add-classe/add-classe.component';
import { SubjectsComponent } from '../views/subjects/subjects/subjects.component';
import { SubjectDetailComponent } from '../views/subjects/subject-detail/subject-detail.component';
import { AddSubjectComponent } from '../views/subjects/add-subject/add-subject.component';
import { StudentsComponent } from '../views/students/students/students.component';
import { TeachersComponent } from '../views/teachers/teachers/teachers.component';
import { TeacherDetailComponent } from '../views/teachers/teacher-detail/teacher-detail.component';
import { StudentDetailComponent } from '../views/students/student-detail/student-detail.component';

export const appRoutes : Routes = [
  {path : 'home', component : MainContentComponent, canActivate: [AuthGuard],data : {roles : ['Admin']}},
  {path: 'forbidden', component : ForbiddenComponent},
  {path : 'signup',  component : MainContentComponent,
  children : [{path : '', component : SignUpComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classes',  component : MainContentComponent,
  children : [{path : '', component : ClassesComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'subjects',  component : MainContentComponent,
  children : [{path : '', component : SubjectsComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'students',  component : MainContentComponent,
  children : [{path : '', component : StudentsComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'teachers',  component : MainContentComponent,
  children : [{path : '', component : TeachersComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classe/detail/:code',  component : MainContentComponent,
  children : [{path : '', component : ClasseDetailComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'classe/add',  component : MainContentComponent,
  children : [{path : '', component : AddClasseComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'teacher/detail/:id',  component : MainContentComponent,
  children : [{path : '', component : TeacherDetailComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'student/detail/:id',  component : MainContentComponent,
  children : [{path : '', component : StudentDetailComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'subject/detail/:code',  component : MainContentComponent,
  children : [{path : '', component : SubjectDetailComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'subject/add',  component : MainContentComponent,
  children : [{path : '', component : AddSubjectComponent}],canActivate: [AuthGuard],data : {roles : ['Admin']}
  },
  {path : 'mystudent',  component : MainContentComponent,
  children : [{path : '', component : MystudentComponent}],canActivate: [AuthGuard],data : {roles : ['Student']}
  },
  {path : 'myteacher',  component : MainContentComponent,
  children : [{path : '', component : MyteacherComponent}],canActivate: [AuthGuard],data : {roles : ['Teacher']}
  },
  {path: 'profile', component : MainContentComponent,
  children : [{path : '', component : ProfileComponent}],canActivate: [AuthGuard],data : {roles : ['Admin','Student','Teacher']}
  },
  {path : 'login', component : UserComponent,
  children : [{path : '', component : SignInComponent}]
  },
  {
      path : '', redirectTo:'/login', pathMatch : 'full'
  }
];