import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {UserService} from './services/users/user.service';
import {HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
import { appRoutes } from './config/routes';
import { ClasseService } from './services/classes/classe.service';
import { ForbiddenComponent } from './shared/forbidden/forbidden.component';
import { AuthGuard } from './resolvers/auth/auth.guard';
import { MainContentComponent } from './shared/main-content/main-content.component';
import { SignInComponent } from './views/sign-in/sign-in.component';
import { SignUpComponent } from './views/sign-up/sign-up.component';
import { UserComponent } from './views/user/user.component';
import { ProfileComponent } from './views/profile/profile/profile.component';
import { MystudentComponent } from './views/mystudent/mystudent/mystudent.component';
import { MyteacherComponent } from './views/myteacher/myteacher/myteacher.component';
import { ClassesComponent } from './views/classes/classes/classes.component';
import { ClasseDetailComponent } from './views/classes/classe-detail/classe-detail.component';
import { AddClasseComponent } from './views/classes/add-classe/add-classe.component';
import { NgxSmartModalModule } from 'ngx-smart-modal';
import { AngularDraggableModule } from 'angular2-draggable';
import {NgxPaginationModule} from 'ngx-pagination';
import { FilterPipeModule } from 'ngx-filter-pipe';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { SubjectsComponent } from './views/subjects/subjects/subjects.component';
import { SubjectDetailComponent } from './views/subjects/subject-detail/subject-detail.component';
import { AddSubjectComponent } from './views/subjects/add-subject/add-subject.component';
import { NgHttpLoaderModule } from 'ng-http-loader';
import { StudentsComponent } from './views/students/students/students.component';
import { OrderModule } from 'ngx-order-pipe';
import { SearchPipe } from './pipes/search.pipe';
import { TeachersComponent } from './views/teachers/teachers/teachers.component';
import { TeacherDetailComponent } from './views/teachers/teacher-detail/teacher-detail.component';
import { StudentDetailComponent } from './views/students/student-detail/student-detail.component';
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { StudentService } from './services/students/student.service';
import { SubjectService } from './services/subjects/subject.service';
import { TeacherService } from './services/teachers/teacher.service';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    UserComponent,
    SignUpComponent,
    MainContentComponent,
    ForbiddenComponent,
    ProfileComponent,
    MystudentComponent,
    MyteacherComponent,
    ClassesComponent,
    ClasseDetailComponent,
    AddClasseComponent,
    SubjectsComponent,
    SubjectDetailComponent,
    AddSubjectComponent,
    StudentsComponent,
    SearchPipe,
    TeachersComponent,
    TeacherDetailComponent,
    StudentDetailComponent,
    MainNavComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    NgxSmartModalModule.forRoot(),
    AngularDraggableModule,
    NgxPaginationModule,
    FilterPipeModule,
    Ng4LoadingSpinnerModule.forRoot(),
    NgHttpLoaderModule,
    OrderModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
  providers: [UserService, AuthGuard, ClasseService, StudentService, SubjectService, TeacherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
