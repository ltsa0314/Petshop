import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/login-request.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  submitted: boolean = false;
  model: LoginRequest = new LoginRequest();
  constructor(
    private srvAuthentication: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  onLogin() {
    this.srvAuthentication.login(this.model).subscribe(
      (response) => {
        if (response.Type == 0) {
          this.router.navigateByUrl('/admin');
        }
        if (response.Type == 1) {
          this.router.navigateByUrl('/shop');
        }
      },
      (error) => {
        console.log(JSON.stringify(error));
        Swal.fire({
          icon: 'error',
          title: 'Error...',
          text: JSON.stringify(error.error),
        });
      }
    );
  }
}
