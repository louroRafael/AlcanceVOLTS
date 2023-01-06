import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, catchError, throwError } from "rxjs";
import { AuthService } from "src/services/auth.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(
      private auth: AuthService
    ) { }

    isRefreshingToken = false;
    tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');

    intercept(request: HttpRequest<any>, next: HttpHandler): any {
        return next.handle(this.addTokenToRequest(request))
        .pipe(
            catchError(error => {
            if (error instanceof HttpErrorResponse && error.status === 401) {
                this.auth.logout();
            }
            return throwError(() => error);
            })
        );
    }

    private addTokenToRequest(request: HttpRequest<any>): HttpRequest<any> {
        if (request.url.includes('viacep')) {
        return request.clone();
        }
        return request.clone({ headers: this.auth.getHeaders() });
    }
}