import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../services/employees.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Employee } from '../../../core/models/employee.model';
import { Response } from '../../../core/models/response.model';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent implements OnInit {
  constructor(
    private employeeService: EmployeesService,
    private router: Router
  ) {}
  url = 'https://localhost:7196/Employees';

  response: Response<Employee[]> = {
    isSuccess: false,
    message: '',
    data: [],
  };

  ngOnInit() {
    this.employeeService.getData().subscribe((data) => {
      this.response = data;
    });
  }

  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id);
    window.location.reload();
  }

  addEmployee() {
    this.router.navigate(['employees/create-employee']);
  }

  editEmployee(id: number) {
    this.router.navigate(['employees/edit-employee', (id = id)]);
  }
}
