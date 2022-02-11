import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.order';
import { ReportTopSales } from '../models/repot-top-sales.model';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  url: string;
  endpoint: string;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private httpClient: HttpClient) {
    this.url = environment.url;
    this.endpoint = environment.endPointProducts;
  }

  getAll(): Observable<Product[]> {
    return this.httpClient
      .get<Product[]>(`${this.url}/api/${this.endpoint}`)
      .pipe(retry(2), catchError(this.handleError));
  }

  getTopSales(): Observable<ReportTopSales[]> {
    return this.httpClient
      .get<ReportTopSales[]>(`${this.url}/api/${this.endpoint}/TopSales`)
      .pipe(retry(2), catchError(this.handleError));
  }

  getById(id: number): Observable<Product> {
    return this.httpClient
      .get<Product>(`${this.url}/api/${this.endpoint}/${id}`)
      .pipe(retry(2), catchError(this.handleError));
  }

  create(item: Product): Observable<Product> {
    return this.httpClient
      .post<Product>(
        `${this.url}/api/${this.endpoint}`,
        JSON.stringify(item),
        this.httpOptions
      )
      .pipe(retry(2), catchError(this.handleError));
  }

  update(item: Product): Observable<Product> {
    return this.httpClient
      .put<Product>(
        `${this.url}/api/${this.endpoint}`,
        JSON.stringify(item),
        this.httpOptions
      )
      .pipe(retry(2), catchError(this.handleError));
  }

  delete(id: number) {
    return this.httpClient
      .delete<any>(`${this.url}/api/${this.endpoint}/${id}`, this.httpOptions)
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
