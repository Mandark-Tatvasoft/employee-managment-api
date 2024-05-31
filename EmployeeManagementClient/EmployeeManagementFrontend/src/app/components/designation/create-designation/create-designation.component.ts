import { Component } from '@angular/core';
import { DesignationsService } from '../services/designations.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Designation } from '../../../core/models/designation.model';

@Component({
  selector: 'app-create-designation',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-designation.component.html',
  styleUrl: './create-designation.component.css',
})
export class CreateDesignationComponent {
  designation: Designation = {
    designationId: 0,
    designationName: '',
  };

  constructor(
    private designationService: DesignationsService,
    private router: Router
  ) {}

  createDesignation() {
    this.designationService.createDesignation(
      'https://localhost:7196/Designations/AddDesignation',
      this.designation
    );
  }
}
