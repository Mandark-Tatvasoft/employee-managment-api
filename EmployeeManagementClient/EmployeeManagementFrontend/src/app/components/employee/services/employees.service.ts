import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../../../core/models/employee.model';
import { Response } from '../../../core/models/response.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  getAllUrl = 'https://localhost:7196/Employees/GetAllEmployees';
  getOneUrl = 'https://localhost:7196/Employees/GetEmployee?id=';
  deleteUrl = 'https://localhost:7196/Employees//DeleteEmployee?id=';
  createUrl = 'https://localhost:7196/Employees/AddEmployee';

  constructor(private http: HttpClient) {}

  getData() {
    return this.http.get<Response<Employee[]>>(this.getAllUrl);
  }

  getEmployee(id: number) {
    return this.http.get<Response<Employee>>(this.getOneUrl + id);
  }

  deleteEmployee(id: number) {
    return this.http.delete(this.deleteUrl + id).subscribe();
  }

  addEmployee(employee: Employee) {
    return this.http.post(this.createUrl, employee).subscribe();
  }

  editEmployee(url: string, employee: Employee) {
    return this.http.put(url, employee).subscribe();
  }
}
