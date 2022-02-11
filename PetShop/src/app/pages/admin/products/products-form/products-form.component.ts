import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product.order';
import { Location } from '@angular/common';
import { ProductsService } from 'src/app/services/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-products-form',
  templateUrl: './products-form.component.html',
  styleUrls: ['./products-form.component.scss'],
})
export class ProductsFormComponent implements OnInit {
  title: string = 'Insertar';
  isInfo: boolean = false;
  model: Product = new Product();

  constructor(
    private location: Location,
    public route: ActivatedRoute,
    public srvProducts: ProductsService
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'info' ? true : false;
    const { id } = this.route.snapshot.params;

    if (id) {
      this.srvProducts.getById(id).subscribe(
        (response) => {
          if (!response) this.location.back();
          this.model = response;
        },
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Error...',
            text: 'Ocurrio un error al obtener informacion!',
          });
        }
      );
    }
  }

  ngOnInit(): void {}
  getImage(image: string) {
    let url =
      'https://png.pngtree.com/png-vector/20190820/ourmid/pngtree-no-image-vector-illustration-isolated-png-image_1694547.jpg';

    if (image.length > 0) url = image;
    return url;
  }
  onSave() {
    Swal.fire({
      title: '¿Seguro que desea guardar informacion?',
      showCancelButton: true,
      confirmButtonText: `SI`,
      cancelButtonText: `NO`,
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire('Guardando informacion...');
        Swal.showLoading();

        if (this.title === 'insert') {
          this.srvProducts.create(this.model).subscribe(
            (response) => {
              Swal.fire('Guardado con exito!', '', 'success').then((result) => {
                if (result.isConfirmed) {
                  this.location.back();
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

        if (this.title === 'update') {
          this.srvProducts.update(this.model).subscribe(
            (response) => {
              Swal.fire('Guardado con exito!', '', 'success').then((result) => {
                if (result.isConfirmed) {
                  this.location.back();
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
      }
    });
  }
  onCancel() {
    this.location.back();
  }
}
