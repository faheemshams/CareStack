import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})

export class SignupComponent implements OnInit {
  signupForm! : FormGroup;

  constructor(private fb : FormBuilder){
  }

  ngOnInit(): void {
    this.signupForm = this.fb.group(
      {
        username : [''],
        email : [''],
        password : [''],
        confirmPassword : ['']
      });
    }

    public signUp()
    {
      console.log(this.signupForm.value);
    }
}
