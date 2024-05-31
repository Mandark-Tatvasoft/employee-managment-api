import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'employees',
    loadChildren: () =>
      import('./components/employee/employee.module').then(
        (m) => m.EmployeeModule
      ),
  },
  {
    path: 'designations',
    loadChildren: () =>
      import('./components/designation/designation.module').then(
        (m) => m.DesignationModule
      ),
  },
];
