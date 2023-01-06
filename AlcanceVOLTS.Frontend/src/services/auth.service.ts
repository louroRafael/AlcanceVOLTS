import { HttpHeaders } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Router } from '@angular/router';
import { GLOBAL } from 'src/infra/global';
import { AuthResult } from 'src/models/login/auth-result';
import { TokenPayload } from 'src/models/login/token-payload';
import { LoginService } from './login.service';
import jwtDecode from "jwt-decode";
import * as moment from "moment";
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserTypeLabelMapping } from 'src/enums/user-type';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  	public storage;
	userTypes = UserTypeLabelMapping;
  	@Output("updatedUser") updatedUser: EventEmitter<boolean> = new EventEmitter<boolean>();
	@Output("usuarioLogado") usuarioLogado: EventEmitter<boolean> = new EventEmitter<boolean>();

	constructor(private loginService: LoginService,
				private router: Router,
				private snackBar: MatSnackBar) { 
		this.storage = localStorage;
	}

	login(email: string, password: string) {
		this.loginService.login(email, password).subscribe(r => {
			this.saveAuthResult(r);
			this.router.navigate(['home']);
			this.usuarioLogado.emit(true);
		}, (e) => {
			var errorMessage = ""
			if (e && e.error && e.error.message)
				errorMessage = e.error.message;
			else
				errorMessage = "Usuário ou senha inválidos";

			this.snackBar.open("Ops! " + errorMessage, "OK", {
				duration: 5000,
				panelClass: ['error-snackbar']
			});
		});
	}

	saveAuthResult(authResult: AuthResult) {
		this.storage.clear();
		this.storage.setItem(GLOBAL.TokenStorageKey, authResult.accessToken);
		this.storage.setItem(GLOBAL.RefreshTokenStorageKey, authResult.refreshToken);

		const tokenInfo = this.getTokenPayload(authResult.accessToken);

		this.storage.setItem(GLOBAL.UserDisplayNameStorageKey, tokenInfo.name);
		this.storage.setItem(GLOBAL.UserMailStorageKey, tokenInfo.email);
		this.storage.setItem(GLOBAL.UserRoleStorageKey, tokenInfo.role);
		this.storage.setItem(GLOBAL.UserIdStorageKey, tokenInfo.id);

		this.updateUser();
	}

  	private getTokenPayload(token: string): TokenPayload {
		const base64 = token.split(".")[1].replace("-", "+").replace("_", "/");
		const decoded = JSON.parse(this.b64DecodeUnicode(base64));

		const result = <TokenPayload>{
		  	id: decoded.unique_name[2],
		  	name: decoded.unique_name[1],
		  	email: decoded.email,
		  	role: decoded.role,
		};
		
		return result;
	}

  	b64DecodeUnicode(str: string) {
		return decodeURIComponent(window.atob(str).split('').map(function (c) {
		  return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
		}).join(''));
	}

  	updateUser() {
		this.updatedUser.emit(true);
	}

  	getHeaders(): HttpHeaders {
		let headers = new HttpHeaders();
		headers = headers.set("Content-Type", 'application/json; charset=utf-8');
		
		if (this.isAuthenticated)
			headers = headers.set("Authorization", "Bearer " + this.token);
		
		return headers;
	}

  	get isAuthenticated(): boolean {
		const token = this.storage.getItem(GLOBAL.TokenStorageKey);
	
		if (token) {
		  const decoded: any = jwtDecode(token || "");
	
		  const isExpired = moment(decoded.exp * 1000) < moment();
		  return !isExpired;
		}
	
		return false;
	}

  	get userId(): string {
		return this.storage.getItem(GLOBAL.UserIdStorageKey) ?? '';
	}

	get userName(): string {
		return this.storage.getItem(GLOBAL.UserDisplayNameStorageKey) ?? '';
	}

	get userType(): string {
		var userType = this.storage.getItem(GLOBAL.UserRoleStorageKey) ?? '';
		return this.userTypes.find(x => x.value == userType)?.label ?? '';
	}

  	get token(): string {
		return this.storage.getItem(GLOBAL.TokenStorageKey) ?? '';
	}

  	logout() {
		this.storage.clear();
		this.updateUser();
		this.router.navigate([""]);
	}
}
