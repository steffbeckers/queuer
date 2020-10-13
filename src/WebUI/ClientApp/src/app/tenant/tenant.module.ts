import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TenantComponent } from './tenant.component';
import { TenantResolver } from './tenant.resolver';
import { TenantService } from './tenant.service';

const routes: Routes = [
  {
    path: '',
    component: TenantComponent,
    resolve: {
      tenant: TenantResolver,
    },
  },
];

@NgModule({
  declarations: [TenantComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  providers: [TenantService, TenantResolver],
})
export class TenantModule {}
