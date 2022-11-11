import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthGuard } from './services/auth-guard.service';
import { HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppErrorHandler } from './common/app-error-handler';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NoAccessComponent } from './no-access/no-access.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ArticleComponent } from './article/article.component';
import { CommentComponent } from './comment/comment.component';
import { AuthService } from './services/auth.service';
import {MatDialogModule} from '@angular/material/dialog'
import { AdminAuthGuard} from './services/admin-auth-guard.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    AdminComponent,
    NavbarComponent,
    NoAccessComponent,
    NotFoundComponent,
    ArticleComponent,
    CommentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDialogModule

  ],
  providers: [
    AuthService,
    AuthGuard,
    AdminAuthGuard,
    {provide:ErrorHandler,useClass:AppErrorHandler},
    JwtHelperService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
