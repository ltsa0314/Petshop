import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import {
  NbActionsModule,
  NbBadgeModule,
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbIconModule,
  NbInputModule,
  NbLayoutModule,
  NbSelectModule,
  NbTooltipModule,
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { AdminGuard } from 'src/app/guards/admin.guard';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: 'products',
      },
      {
        path: 'products',
        canActivate: [AdminGuard],
        loadChildren: () =>
          import('./products/products.module').then((m) => m.ProductsModule),
      },
    ],
  },
];

@NgModule({
  declarations: [AdminComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    NbLayoutModule,
    NbEvaIconsModule,
    NbActionsModule,
    NbButtonModule,
    NbSelectModule,
    NbIconModule,
    NbBadgeModule,
    NbSelectModule,
    NbInputModule,
    NbCheckboxModule,
    NbCardModule,
    NbTooltipModule,
  ],
  exports: [RouterModule],
})
export class AdminModule {}
