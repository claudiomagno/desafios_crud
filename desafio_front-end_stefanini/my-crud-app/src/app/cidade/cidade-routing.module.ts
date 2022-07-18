import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { IndexComponent } from './index/index.component';
import { ViewComponent } from './view/view.component';


const routes: Routes = [

  { path: 'cidade', redirectTo: 'cidade/index', pathMatch: 'full'},
  { path: 'cidade/index', component: IndexComponent },
  { path: 'cidade/:cidadeId/view', component: ViewComponent },
  { path: 'cidade/create', component: CreateComponent },
  { path: 'cidade/:cidadeId/edit', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CidadeRoutingModule { }
