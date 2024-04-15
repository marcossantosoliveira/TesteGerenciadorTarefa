import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [

    {
        path: '',
        loadChildren: () => import('../../src/app/components/tarefas/lista-tarefas.module')
        .then(mod => mod.ListaTarefasModule)
    },
    {
        path: 'tarefa/:id',
        loadChildren: () => import('./components/tarefas/tarefa-criar-editar/tarefa-criar-editar.module')
        .then(mod => mod.TarefaCriarEditarModule)
    },
    {
        path: 'tarefa-detalhe/:id',
        loadChildren: () => import('../../src/app/components/tarefas/tarefa-detalhe/tarefa-detalhe.module')
        .then(mod => mod.TarefaDetalheModule)
    },
  ];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
