import { Component, OnInit } from '@angular/core';
import { DesignationsService } from '../../designation/services/designations.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms';
import { EmployeesService } from '../services/employees.service';
import { Router } from '@angular/router';
import { Designation } from '../../../core/models/designation.model';
import { Employee } from '../../../core/models/employee.model';
import { Response } from '../../../core/models/response.model';

@Component({
  selector: 'app-create-employee',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-employee.component.html',
  styleUrl: './create-employee.component.css',
})
export class CreateEmployeeComponent implements OnInit {
  url = 'https://localhost:7196/Designations';

  designations: Response<Designation[]> = {
    isSuccess: false,
    message: '',
    data: [],
  };

  employee: Employee = {
    id: 0,
    firstname: '',
    lastname: '',
    designation: 0,
    salary: 0,
  };

  constructor(
    private designationService: DesignationsService,
    private employeeService: EmployeesService,
    private router: Router
  ) {}

  ngOnInit() {
    this.designationService
      .getDesignations(this.url + '/GetAllDesignations')
      .subscribe((data) => {
        this.designations = data;
      });
  }

  addEmployee() {
    this.employeeService.addEmployee(this.employee);
    this.router.navigate(['employees']);
  }
}
