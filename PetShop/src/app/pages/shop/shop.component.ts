import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderItem } from 'src/app/models/order-item.model';
import { Order } from 'src/app/models/order.model';
import { Product } from 'src/app/models/product.order';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { OrdersService } from 'src/app/services/orders.service';
import { ProductsService } from 'src/app/services/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  data: Product[] = [];
  order: Order = new Order();
  fullname: string = '';
  constructor(
    public srvProductsService: ProductsService,
    public srvAuthService: AuthenticationService,
    public srvOrderService: OrdersService,
    private router: Router
  ) {
    this.fullname = srvAuthService.getFullname();
    this.order.UserId = Number.parseInt(srvAuthService.getUser());
    this.order.Date = new Date();
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.data = [];
    this.srvProductsService.getAll().subscribe((result) => {
      this.data = result;
    });
  }

  addToCart(product: Product) {
    let item: any;
    item = this.order.OrderItems.find((x) => x.ProductId === product.Id);
    if (item) {
      item.Count++;
    } else {
      item = new OrderItem();
      item.ProductId = product.Id;
      item.Count = 1;
      item.Price = product.Price;
      this.order.OrderItems.push(item);
    }
    this.calculate();
  }
  removeToCart(item: OrderItem) {
    let index = this.order.OrderItems.indexOf(item);
    this.order.OrderItems.splice(index, 1);
    this.calculate();
  }

  calculate() {
    this.order.TotalAmount = 0;
    this.order.OrderItems.forEach((item) => {
      item.TotalAmount = item.Price * item.Count;
      this.order.TotalAmount += item.TotalAmount;
    });
  }
  salir() {
    localStorage.removeItem('profile');
    localStorage.removeItem('user')
    localStorage.removeItem('fullname')
    this.router.navigateByUrl('/auth/login');
  }
  saveOrder() {
    Swal.fire({
      title: '¿Seguro que desea finalizar la compra?',
      showCancelButton: true,
      confirmButtonText: `SI`,
      cancelButtonText: `NO`,
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire('Guardando informacion...');
        Swal.showLoading();
        this.srvOrderService.create(this.order).subscribe(
          (result) => {
            Swal.fire('Guardado con exito!', '', 'success').then((result) => {
              if (result.isConfirmed) {
                this.order = new Order();
                this.order.UserId = Number.parseInt(
                  this.srvAuthService.getUser()
                );
                this.order.Date = new Date();
              }
            });
          },
          (error) => {
            Swal.fire({
              icon: 'error',
              title: 'Error...',
              text: 'Ocurrio un error al guardar informacion!',
            });
          }
        );
      }
    });
  }
  getProductById(Id: number): any {
    return this.data.find((x) => x.Id === Id);
  }
}
