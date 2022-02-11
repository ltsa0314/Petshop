import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsFormComponent } from './products-form/products-form.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {
  NbActionsModule,
  NbButtonModule,
  NbCardModule,
  NbDatepickerModule,
  NbIconModule,
  NbInputModule,
  NbSelectModule,
  NbUserModule,
} from '@nebular/theme';

const routes: Routes = [
  {
    path: '',
    component: ProductsListComponent,
  },
  {
    path: 'insert',
    component: ProductsFormComponent,
  },
  {
    path: 'update/:id',
    component: ProductsFormComponent,
  },
  {
    path: 'info/:id',
    component: ProductsFormComponent,
  },
];

@NgModule({
  declarations: [ProductsListComponent, ProductsFormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    NbCardModule,
    NbActionsModule,
    NbUserModule,
    NbButtonModule,
    NbInputModule,
    NbSelectModule,
    NbDatepickerModule,
    NbIconModule,
  ],
  exports: [RouterModule],
})
export class ProductsModule {}
