
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TarefaDetalheComponent } from './tarefa-detalhe.component';

const routes: Routes = [{path: '', component: TarefaDetalheComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],

})
export class TarefaDetalheRoutingModule { }
