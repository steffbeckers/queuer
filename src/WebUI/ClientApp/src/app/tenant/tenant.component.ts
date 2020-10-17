import { Component, OnInit } from '@angular/core';
import { AppState } from '../app.state';

@Component({
  selector: 'app-tenant',
  templateUrl: './tenant.component.html',
  styleUrls: ['./tenant.component.css'],
})
export class TenantComponent implements OnInit {
  // tenant: TenantDto;

  constructor(public appState: AppState) {}

  ngOnInit(): void {
    // this.tenant = this.route.snapshot.data['tenant'];
  }
}
