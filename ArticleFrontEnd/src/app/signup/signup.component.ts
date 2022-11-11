import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  invalidSignUp!: boolean;
  myForm!: FormGroup;
  constructor(
    private fb:FormBuilder,
    private authservice:AuthService,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.GForm();
  }

  GForm(){
   this.myForm=this.fb.group({
      firstName:['',Validators.required],
      lastName: ['',Validators.required],
      userName:['',Validators.required],
      email:['',Validators.required],
      password:['',Validators.required]
   });
  }

  signup(){
    this.authservice.signup(this.myForm.value).subscribe(result =>{
      if(result)
        this.router.navigate(['/login']);
      
      this.invalidSignUp=true;
    });
  }

    get firstName(){
      return this.myForm.get('firstName');
    }
    get lastName(){
      return this.myForm.get('lastName');
    }
    get userName(){
      return this.myForm.get('userName');
    }
    get email(){
      return this.myForm.get('email');
    }
    get password(){
      return this.myForm.get('password');
    }
   

}
