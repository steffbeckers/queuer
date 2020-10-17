import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TenantComponent } from './tenant.component';
import { TenantResolver } from './tenant.resolver';
import { TenantService } from './tenant.service';
import { TenantRequestTicketComponent } from './request-ticket/request-ticket.component';
import { TenantTicketComponent } from './ticket/ticket.component';
import { TicketResolver } from './ticket/ticket.resolver';

const routes: Routes = [
  {
    path: '',
    component: TenantComponent,
    resolve: {
      tenant: TenantResolver,
    },
    children: [
      {
        path: ':id',
        component: TenantTicketComponent,
        resolve: {
          ticket: TicketResolver,
        },
      },
      {
        path: '',
        component: TenantRequestTicketComponent,
      },
      {
        path: '**',
        pathMatch: 'full',
        redirectTo: '',
      },
    ],
  },
];

@NgModule({
  declarations: [
    TenantComponent,
    TenantRequestTicketComponent,
    TenantTicketComponent,
  ],
  imports: [CommonModule, RouterModule.forChild(routes)],
  providers: [TenantService, TenantResolver, TicketResolver],
})
export class TenantModule {}
