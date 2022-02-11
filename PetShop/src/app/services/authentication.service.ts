import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../models/login-request.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private url: string = environment.url;
  private endpoint: string = environment.endPointAuthentication;
  public isAunthenticate: boolean = false;

  constructor(private httpClient: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  login(item: LoginRequest): Observable<any> {
    return this.httpClient
      .post<any>(
        `${this.url}/api/${this.endpoint}/login`,
        JSON.stringify(item),
        this.httpOptions
      )
      .pipe(
        tap((resp) => {
          localStorage.setItem('user', resp.Id);
          localStorage.setItem('fullname', resp.FullName);
          localStorage.setItem('profile', resp.Type);
        })
      );
  }

  isAdmin() {
    let profile = localStorage.getItem('profile') || '';
    return profile == '0';
  }

  isBuyer() {
    let profile = localStorage.getItem('profile') || '';
    return profile == '1';
  }
  getUser() {
    return localStorage.getItem('user') || '';
  }
  getFullname() {
    return localStorage.getItem('fullname') || '';
  }
}
