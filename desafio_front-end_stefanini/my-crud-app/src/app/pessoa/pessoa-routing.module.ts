import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatePessoaComponent } from './create-pessoa/create-pessoa.component';
import { EditPessoaComponent } from './edit-pessoa/edit-pessoa.component';
import { IndexPessoaComponent } from './index-pessoa/index-pessoa.component';
import { ViewPessoaComponent } from './view-pessoa/view-pessoa.component';


const routes: Routes = [
  { path: 'pessoa', redirectTo: 'pessoa/index', pathMatch: 'full'},
  { path: 'pessoa/index', component: IndexPessoaComponent },
  { path: 'pessoa/:pessoaId/view', component: ViewPessoaComponent },
  { path: 'pessoa/create', component: CreatePessoaComponent },
  { path: 'pessoa/:pessoaId/edit', component: EditPessoaComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PessoaRoutingModule { }
