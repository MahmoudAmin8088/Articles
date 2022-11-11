import { NotFoundError } from './../common/not-found-error';
import { BadInput } from './../common/bad-input';
import { CommentService } from './../services/comment.service';
import { ActivatedRoute } from '@angular/router';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'app/services/auth.service';
import { AppError } from 'app/common/app-error';
import { Comments } from 'app/comment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  comments:Comments[]=[];
  myForm!:FormGroup;
  

  constructor(@Inject(MAT_DIALOG_DATA) public data:any,public dialogRef:MatDialogRef<CommentComponent>,private route:ActivatedRoute,public ComService:CommentService,private fb:FormBuilder,public authService: AuthService) { }

  ngOnInit(): void {
   
   this.GetCommentOfArticle();
   this.GForm();
  }

  GForm(){
    this.myForm=this.fb.group({
      commentId:[null],
      commentDetails:['',Validators.required],
     // commentTime:[''],
      articleId:[''],
      userId:['']
    });
  }
  GetCommentOfArticle(){
    this.ComService.GetArticleComments(this.data.articleId).subscribe(res=>{
      this.comments=res;
    });
  }


  Create(){
    debugger
    this.myForm.controls['userId'].setValue(this.authService.currentUser.userId);
    this.myForm.controls['articleId'].setValue(this.data.articleId);

    this.ComService.Create(this.myForm.value).subscribe(res=>{
      this.myForm.reset();
      this.GetCommentOfArticle();

    },
    (error:AppError)=>{
      if(error instanceof BadInput)
        alert('BadRequist');
      else throw error;
    }
    );
  }
  Update(){
    this.ComService.Update(this.myForm.value).subscribe(res=>{
      this.myForm.reset();
      this.GetCommentOfArticle();
    },(error:AppError)=>{
      if(error instanceof BadInput)
        alert('BadRequist');
      else throw error;  
  }
    );
  }

  Delete(id:string){
    this.ComService.Delete(id).subscribe(res=>{
      this.GetCommentOfArticle();
    },
    (error:AppError)=>{

      if(error instanceof NotFoundError)
        alert('This Comment has Already deleted');
      else throw error;
     
    }
    );
  }
  edit(comment:any){
    this.myForm.controls['commentId'].setValue(comment.commentId);
    this.myForm.patchValue(comment);
  }

  delete(comment:any){
    let id = comment.commentId;
    this.Delete(id);

  }


  CreateData(){
    if (this.myForm.value.commentId == null) {
      this.Create();
    }
    else {
      this.Update();
    }
  }

  get commentDetails(){
    return this.myForm.get('commentDetails');
   }
   

}
