import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { UserService } from '../user/usuario.service';
import {environment} from '@env/environment';

const API_URL = environment.todo_api;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private userService: UserService
  ) { }

  authenticate(usuario: string, senha: string) {

    return this.http
      .post(
        API_URL + '/api/login',
        { usuario, senha },
        { observe: 'response' }
      )
      .pipe(tap(res => {
        const authToken = res.body['accessToken'];
        this.userService.setToken(authToken);
      }));
  }
}