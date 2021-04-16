import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './signin.component.html'
})
export class SignInComponent implements OnInit {

    loginForm: FormGroup;
    @ViewChild('userNameInput') userNameInput: ElementRef<HTMLInputElement>;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            userName: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    login() {
        const usuario = this.loginForm.get('userName').value;
        const senha = this.loginForm.get('password').value;

        this.authService
            .authenticate(usuario, senha)
            .subscribe(
                () => this.router.navigate(['home']),
                err => {
                    this.loginForm.reset();
                    this.userNameInput.nativeElement.focus();
                    alert('Usuário e/ou senha esta(ão) inválido(s)!');
                }
            );
    }
}