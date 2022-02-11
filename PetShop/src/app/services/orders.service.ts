import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  url: string;
  endpoint: string;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private httpClient: HttpClient) {
    this.url = environment.url;
    this.endpoint = environment.endPointOrders;
  }

  create(item: Order): Observable<Order> {
    return this.httpClient
      .post<Order>(
        `${this.url}/api/${this.endpoint}`,
        JSON.stringify(item),
        this.httpOptions
      )
      .pipe(retry(2), catchError(this.handleError));
  }

  getById(id: number): Observable<Order> {
    return this.httpClient
      .get<Order>(`${this.url}/api/${this.endpoint}/${id}`)
      .pipe(retry(2), catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      //error client
      errorMessage = error.error.message;
    } else {
      //error server
      errorMessage =
        `Código do error: ${error.status}, ` + `message: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
