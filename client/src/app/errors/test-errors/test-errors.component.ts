import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-test-errors',
  standalone: true,
  imports: [],
  templateUrl: './test-errors.component.html',
  styleUrl: './test-errors.component.css'
})
export class TestErrorsComponent {
  baseUrl = 'http://localhost:5000/api/';
  private http = inject(HttpClient);
  validationErrors: string[] =[];

  get400Error() {
    this.http.get('http://localhost:5000' + '/api/buggy/bad-request').subscribe ({
      next: response => console.log(response),
      error: error => console.log(error)
    }) 
  }

  get401Error() {
    this.http.get('http://localhost:5000' + '/api/buggy/auth').subscribe ({
      next: response => console.log(response),
      error: error => console.log(error)
    }) 
  }

  get404Error() {
    this.http.get('http://localhost:5000' + '/api/buggy/not-found').subscribe ({
      next: response => console.log(response),
      error: error => console.log(error)
    }) 
  }

  get500Error() {
    this.http.get('http://localhost:5000' + '/api/buggy/server-error').subscribe ({
      next: response => console.log(response),
      error: error => console.log(error)
    }) 
  }

  get400ValidationError() {
    this.http.post('http://localhost:5000' + '/api/account/register', {}).subscribe ({
      next: response => console.log(response),
      error: error => {
        console.log(error)
        this.validationErrors = error;
      }
    }) 
  }
}
