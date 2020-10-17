import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { TicketDto } from '../../queuer-api';
import { TenantService } from '../tenant.service';

@Injectable()
export class TicketResolver implements Resolve<TicketDto> {
  constructor(private tenantService: TenantService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<TicketDto> {
    return this.tenantService.getTicketById(route.params.id);
  }
}
