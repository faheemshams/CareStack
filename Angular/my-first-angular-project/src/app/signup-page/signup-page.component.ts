import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuthService } from '../Services/userAuth.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { IBookDetails, IGetUserDetails } from '../Interfaces/app.interface';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.scss']
})
export class SignupPageComponent implements OnInit{ 

  public signUpForm!: FormGroup<
  {
    name : FormControl<any>,
    email : FormControl<any>,
    password : FormControl<any>,
    confirmPassword : FormControl<any>
  }
  >;

  public form!: IGetUserDetails;

  constructor(private router: Router, private readonly userAuthService: UserAuthService, private readonly formBuilder :  FormBuilder)
  {

  }

  public error = false;

  public ngOnInit(): void 
  {
   this.signUpForm = this.formBuilder.group(
    {
      name : ['', Validators.required],
      email : ['', Validators.compose([Validators.required, this.emailValidator()])],
      password : ['', Validators.required],
      confirmPassword : ['', Validators.required]
     }
   ) ;
  }

  public onSubmit()
  {
    console.log(this.signUpForm.value);
    
    if(this.signUpForm.valid)
    {
      this.error = false;
      this.userAuthService.setUserDetails(this.signUpForm.value as IGetUserDetails);
      this.router.navigate(['login']);
    }
    else
    this.error = true;
  }

  public populateSignUpForm()
  {
    this.form = {
      name : 'faheem',
      email : 'faheem@gmail.com',
      password : '123456',
      confirmPassword : '123456'
  }

  this.signUpForm.patchValue(
    {
      name : this.form.name,
      email : this.form.email,
      password : this.form.password,
      confirmPassword : this.form.confirmPassword
    }
  );
  }

  public onReset()
  {
    this.signUpForm.reset();
  }

  //write this in another file, service file, Can make it static

  private emailValidator() : ValidatorFn
  {
    return(control : AbstractControl) : { [key:string] : boolean} | null =>
    {
      if(!control.value)  
      return null;

     return control.value.includes('@carestack.com') ? null : {invalidEmail : true};
  }
}
}