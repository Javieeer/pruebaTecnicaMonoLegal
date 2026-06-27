import { Component, OnInit } from '@angular/core';
import { Factura } from '../../models/factura';
import { FacturaService } from '../../services/factura.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {

  facturas: Factura[] = [];

  constructor(private facturaService: FacturaService) {}

  ngOnInit(): void {
    this.facturaService
      .obtenerFacturas()
      .subscribe(data => {
        this.facturas = data;
      });
  }
}