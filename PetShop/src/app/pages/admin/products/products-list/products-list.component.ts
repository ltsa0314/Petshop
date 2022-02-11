import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product.order';
import { ReportTopSales } from 'src/app/models/repot-top-sales.model';
import { ProductsService } from 'src/app/services/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss'],
})
export class ProductsListComponent implements OnInit {
  data: Product[] = [];
  topSales: ReportTopSales[] = [];
  constructor(
    public srvProductsService: ProductsService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.data = [];
    this.topSales = [];

    this.srvProductsService.getTopSales().subscribe((result) => {
      this.topSales = result;
    });

    this.srvProductsService.getAll().subscribe((result) => {
      this.data = result;
    });
  }
  onInfo(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/info/' + id,
    ]);
  }
  onUpdate(id: number) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/update/' + id,
    ]);
  }
  onDelete(id: number) {
    Swal.fire({
      title: 'Estas Seguro?',
      text: '¡No podrás revertir esto!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '¡Sí, bórralo!',
    }).then((result: any) => {
      if (result.isConfirmed) {
        this.srvProductsService.delete(id).subscribe(() => {
          Swal.fire('¡Eliminado!', 'El producto ha sido eliminado.', 'success');
          this.loadData();
        });
      }
    });
  }
}
