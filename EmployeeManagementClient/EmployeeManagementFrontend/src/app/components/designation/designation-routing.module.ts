import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesignationComponent } from './designation-list/designation.component';
import { CreateDesignationComponent } from './create-designation/create-designation.component';
import { EditDesignationComponent } from './edit-designation/edit-designation.component';

const routes: Routes = [
  {
    path: '',
    component: DesignationComponent,
  },
  {
    path: 'create-designation',
    component: CreateDesignationComponent,
  },
  {
    path: 'edit-designation/:id',
    component: EditDesignationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DesignationRoutingModule {}
