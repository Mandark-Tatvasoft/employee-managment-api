import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { DesignationsService } from '../services/designations.service';
import { Router } from '@angular/router';
import { Designation } from '../../../core/models/designation.model';
import { Response } from '../../../core/models/response.model';

@Component({
  selector: 'app-designation',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './designation.component.html',
  styleUrl: './designation.component.css',
})
export class DesignationComponent implements OnInit {
  response: Response<Designation[]> = {
    isSuccess: false,
    message: '',
    data: [],
  };

  constructor(
    private router: Router,
    private designationService: DesignationsService
  ) {}

  ngOnInit() {
    this.designationService
      .getDesignations('https://localhost:7196/Designations/GetAllDesignations')
      .subscribe((data) => {
        this.response = data;
      });
  }

  addDesignation() {
    this.router.navigate(['designations/create-designation']);
  }

  editDesignation(id: number) {
    this.router.navigate(['designations/edit-designation', id]);
  }
}
