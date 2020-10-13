import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { TenantDto } from '../queuer-api';
import { TenantService } from './tenant.service';

@Injectable()
export class TenantResolver implements Resolve<TenantDto> {
  constructor(private tenantService: TenantService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<TenantDto> {
    return this.tenantService.getBySlug(route.params.slug);
  }
}
