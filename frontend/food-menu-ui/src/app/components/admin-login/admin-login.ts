
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-admin-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './admin-login.html',
  styleUrl: './admin-login.css'
})
export class AdminLogin {

  email: string = '';
  password: string = '';

  errorMessage: string = '';

  constructor(
    private authService: Auth,
    private router: Router
  ) {}

  login(): void {

    this.errorMessage = '';

    const loginData = {
      email: this.email,
      password: this.password
    };

    this.authService.login(loginData).subscribe({
      next: (response) => {

        if (response.role === 'Admin') {
          this.router.navigate(['/admin-dashboard']);
        }

      },
      error: (error) => {
        this.errorMessage = 'Invalid email or password';
      }
    });
  }
}
