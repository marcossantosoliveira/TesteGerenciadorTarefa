
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TarefaCriarEditarComponent } from './tarefa-criar-editar.component';

const routes: Routes = [{path: '', component: TarefaCriarEditarComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],

})
export class TarefaCriarEditarRoutingModule { }
