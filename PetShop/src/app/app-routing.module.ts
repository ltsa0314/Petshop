import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from './guards/admin.guard';
import { BuyerGuard } from './guards/buyer.guard';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: 'shop'
  },
  {
    path: "auth",
    loadChildren: () =>
      import("./pages/auth/auth.module").then(
        (m) => m.AuthModule
      ),
  },
  {
    path: "admin",
    canActivate: [AdminGuard],
    loadChildren: () =>
      import("./pages/admin/admin.module").then(
        (m) => m.AdminModule
      ),
  },
  {
    path: "shop",
    canActivate: [BuyerGuard],
    loadChildren: () =>
      import("./pages/shop/shop.module").then(
        (m) => m.ShopModule
      ),
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
