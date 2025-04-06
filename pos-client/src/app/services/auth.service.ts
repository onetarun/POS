import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginRequestDto, LoginResponseDto } from '../Dto/userLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token:LoginResponseDto={token:''};

  private apiUrl=environment.loginapiUrl;

  private authstate=new BehaviorSubject<boolean>(this.isAuthenticated());
  authstate$=this.authstate.asObservable();

  constructor(private httpClient:HttpClient) { }

  login(credentials: LoginRequestDto): Observable<LoginResponseDto> {
     return this.httpClient.post<LoginResponseDto>(`${this.apiUrl}/login`, credentials);
  }

  Logout()
  {
    localStorage.removeItem('UserToken');
    this.token = { token: '' };
    this.authstate.next(false);
  }

  isAuthenticated():boolean
  {
    this.token=JSON.parse(localStorage.getItem('UserToken')!);
    return true;
  }

  UpdateAuthState(auth:boolean)
  {
    this.authstate.next(auth);
  }
}
