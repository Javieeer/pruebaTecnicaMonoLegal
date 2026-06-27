import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Factura } from '../models/factura';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  private apiUrl = 'http://localhost:5254/api/facturas';

  constructor(private http: HttpClient) { }

  obtenerFacturas(): Observable<Factura[]> {
    return this.http.get<Factura[]>(this.apiUrl);
  }
}