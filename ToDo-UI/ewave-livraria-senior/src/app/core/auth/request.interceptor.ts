import { Injectable } from "@angular/core";
import { HttpErrorResponse, HttpInterceptor } from "@angular/common/http";
import { HttpRequest } from "@angular/common/http";
import { HttpHandler } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { HttpSentEvent } from "@angular/common/http";
import { HttpHeaderResponse } from "@angular/common/http";
import { HttpProgressEvent } from "@angular/common/http";
import { HttpResponse } from "@angular/common/http";
import { HttpUserEvent } from "@angular/common/http";
import { TokenService } from "../token/token.service";
import { catchError } from 'rxjs/operators';
import { UserService } from 'app/core/user/usuario.service';



@Injectable()
export class RequestInterceptor implements HttpInterceptor {

    constructor(private tokenService: TokenService,
        private userService: UserService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent
        | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
        if (this.tokenService.hasToken()) {
            const token = this.tokenService.getToken();
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }

        return next.handle(req).pipe(catchError(err => {
            if ([401, 403].includes(err.status) && this.tokenService.tokenExpired())
                this.userService.logout();

            return throwError(err);
        }))

    }
}