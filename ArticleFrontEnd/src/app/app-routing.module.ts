import { CommentComponent } from './comment/comment.component';
import { SignupComponent } from './signup/signup.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { ArticleComponent } from './article/article.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NoAccessComponent } from './no-access/no-access.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AuthGuard } from './services/auth-guard.service';
import { AdminAuthGuard } from './services/admin-auth-guard.service';

const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  { path:'home',
     component:HomeComponent
  },
  {
    path:'admin',
    component:AdminComponent,
    canActivate:[AuthGuard,AdminAuthGuard]
  },
  {
    path:'article',
    component:ArticleComponent,
    canActivate:[AuthGuard]

  },
  {
    path:'comment/:articleId',
     component:CommentComponent,
     canActivate:[AuthGuard]

  },
  {
    path:'comment',
     component:CommentComponent,
     canActivate:[AuthGuard]

  },
  {
    path:'signup',
    component:SignupComponent
  },
  {
    path:'no-access',
    component:NoAccessComponent
  },
  {
    path:'**',
    component:NotFoundComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
