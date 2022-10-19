import { CommentService } from './../services/comment.service';
import { CatagoryService } from './../services/catagory.service';
import { NotFoundError } from './../common/not-found-error';
import { BadInput } from './../common/bad-input';
import { AppError } from './../common/app-error';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from './../services/auth.service';
import { ArticleService } from './../services/article.service';
import { Component, OnInit, Output } from '@angular/core';
import { Article } from 'app/article';
import { identifierName } from '@angular/compiler';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {

  myForm!:FormGroup;
  articles:Article[]=[];
  catigorys:any;
  @Output()article:any;

  constructor(private service:ArticleService,private CommentService:CommentService,public authService:AuthService,private fb:FormBuilder,public catService:CatagoryService) { }

  ngOnInit(): void {
    this.GForm();
    this.GetCataigory();
    this.GetAll();
  }


  GForm(){
    this.myForm=this.fb.group({
      articleId:[null],
      articleDetails:['',Validators.required],
      //articleTime:[''],
      catigoryId:['',Validators.required],
      userId:['']
    });
  }

  GetCataigory(){
    this.catService.GetAll().subscribe(res=>{
      this.catigorys=res;
      console.log(res);

    })
  }
 
  GetAll(){
    this.service.GetAll().subscribe(res=>{
      this.articles=res
    });
  }

  Create(){
    this.myForm.controls['userId'].setValue(this.authService.currentUser.userId);
    this.service.Create(this.myForm.value).subscribe(res=>{
      this.myForm.reset();
      this.GetAll();
    },
    (error:AppError)=>{
      if(error instanceof BadInput)
        alert('BadRequist 400');

      else throw error;

    }
    );

  }

  Update(){
    this.service.Update(this.myForm.value).subscribe(res=>{
      this.myForm.reset();
      this.GetAll();
    },
    (error:AppError)=>{
      if(error instanceof BadInput)
      alert('BadRequist 400');
    else throw error;  
    }
    );
  }

  Delete(id:string){
    this.service.Delete(id).subscribe(res=>{
      this.GetAll();
    },
    (error:AppError)=>{
      if(error instanceof NotFoundError)
      alert('This Article has Already deleted');
    else throw error;
    }
    );
  }

  CreateData(){
  if(this.myForm.value.articleId==null){
    this.Create();
  }
  else{
    this.Update();
  }
  }
  edit(article:any){
    this.myForm.patchValue(article);

  }
  delete(article:any){
    let id = article.articleId;
    this.Delete(id);
  }

  get getName(){
   let a =  this.authService.currentUser.GivenName;
   console.log(a);
   
   return a;

  }


  get articleDetails(){
    return this.myForm.get('articleDetails');
  }
  get catigoryId(){
    return this.myForm.get('catigoryId');
  }

}
