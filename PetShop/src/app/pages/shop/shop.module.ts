import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
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

const routes: Routes = [
  {
    path: '',
    component: ShopComponent,
  },
];

@NgModule({
  declarations: [ShopComponent],
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
    NbTooltipModule
    
  ],
  exports: [RouterModule],
})
export class ShopModule {}
