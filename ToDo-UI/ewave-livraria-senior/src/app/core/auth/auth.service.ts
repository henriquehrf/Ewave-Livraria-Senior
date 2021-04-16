import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '@env/environment';
import { tap } from 'rxjs/operators';

import { UserService } from '../user/usuario.service';
import { Credencial } from './credencial';

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
        API_URL + '/api/login/autenticar',
        { usuario, senha },
        { observe: 'response' }
      )
      .pipe(tap(res => {
        const authToken = res.body as Credencial;
        
        this.userService.setToken(authToken.acessToken);
      }));
  }
}