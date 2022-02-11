import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  fullname: string = '';

  constructor(
    public srvAuthService: AuthenticationService,
    private router: Router
  ) {
    this.fullname = srvAuthService.getFullname();
  }

  ngOnInit(): void {}
  salir() {
    localStorage.removeItem('profile');
    localStorage.removeItem('user');
    localStorage.removeItem('fullname');
    this.router.navigateByUrl('/auth/login');
  }
}
