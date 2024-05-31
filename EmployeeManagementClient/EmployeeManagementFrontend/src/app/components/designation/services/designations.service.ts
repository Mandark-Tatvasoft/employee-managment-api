import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Response } from '../../../core/models/response.model';
import { Designation } from '../../../core/models/designation.model';
import { ApiService } from '../../../core/services/api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DesignationsService {
  constructor(private api: ApiService, private router: Router) {}

  getDesignations(apiUrl: string) {
    return this.api.get(apiUrl);
  }

  getDesignation(url: string) {
    return this.api.get(url);
  }

  createDesignation(url: string, designation: Designation) {
    this.api
      .post(url, designation)
      .subscribe((res) => this.router.navigate(['designations']));
  }

  editDesignation(url: string, designation: Designation) {
    this.api
      .put(url, designation)
      .subscribe((res) => this.router.navigate(['designations']));
  }
}
