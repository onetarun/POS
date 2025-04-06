import { Component } from '@angular/core';
import { LoginRequestDto, LoginResponseDto } from '../../Dto/userLogin';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-user-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {

loginuser:LoginRequestDto={email:'', password:''};

constructor(private auth:AuthService, private router:Router ){}

UserLogin()
{
  this.auth.login(this.loginuser).subscribe({
  next: (response)=>{
    this.auth.token=response;
    localStorage.setItem("UserToken",JSON.stringify(this.auth.token));
    this.auth.UpdateAuthState(true);
    this.router.navigate(['/']);  }
});
}
}
