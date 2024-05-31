import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { DesignationsService } from '../../designation/services/designations.service';
import { EmployeesService } from '../services/employees.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Designation } from '../../../core/models/designation.model';
import { Response } from '../../../core/models/response.model';
import { Employee } from '../../../core/models/employee.model';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css',
})
export class EditEmployeeComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private designation: DesignationsService,
    private employeeService: EmployeesService,
    private router: Router
  ) {}

  designations: Response<Designation[]> = {
    isSuccess: false,
    message: '',
    data: [],
  };
  id: number = 0;

  employeeDetails: Response<Employee> = {
    isSuccess: false,
    message: '',
    data: {
      id: 0,
      firstname: '',
      lastname: '',
      designation: 0,
      salary: 0,
    },
  };

  ngOnInit() {
    this.route.params.subscribe((params: Params) => (this.id = params['id']));

    this.designation
      .getDesignations('https://localhost:7196/Designations/GetAllDesignations')
      .subscribe((data) => {
        this.designations = data;
      });

    this.employeeService.getEmployee(this.id).subscribe((data) => {
      this.employeeDetails = data;
    });
  }

  editEmployee() {
    this.employeeService.editEmployee(
      'https://localhost:7196/Employees/UpdateEmployeeDetails',
      this.employeeDetails.data
    );
    this.router.navigate(['employees']);
  }
}
