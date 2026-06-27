export interface Factura {
  id?: string;
  cliente: string;
  email: string;
  numeroFactura: string;
  valor: number;
  estado: string;
}