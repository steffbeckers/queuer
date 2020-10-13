import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TenantDto } from './queuer-api';

@Injectable({ providedIn: 'root' })
export class AppState {
  tenant: BehaviorSubject<TenantDto> = new BehaviorSubject<TenantDto>(null);
}
