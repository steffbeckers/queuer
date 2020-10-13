import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppState } from '../app.state';
import { TenantDto } from '../queuer-api';

@Component({
  selector: 'app-tenant',
  templateUrl: './tenant.component.html',
  styleUrls: ['./tenant.component.css'],
})
export class TenantComponent implements OnInit {
  tenant: TenantDto;

  constructor(public appState: AppState, public route: ActivatedRoute) {}

  ngOnInit(): void {
    this.tenant = this.route.snapshot.data['tenant'];
  }
}
