import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

@Component({
    selector: 'app-lista-tarefas',
    templateUrl: './lista-tarefas.component.html',
    styleUrls: ['./lista-tarefas.component.scss']
})
export class ListaTarefasComponent implements OnInit {

    public dataSource;
    public displayedColumns = [];
    public listatarefas: any[] = [];
    public columnNames = [{id: 'id',value:'Id',},{id: 'descricao',value:'Descricao',},{id: 'data',value:'Data',}
    ,{id: 'data',value:'Data',}, {id: 'status',value:'Status',}];

    @ViewChild(MatSort) sort: MatSort;


    constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) { }

    ngOnInit() {
        this.buscartarefas();
    }

    buscartarefas() {

        this.apiService.get('tarefas/buscartarefas').subscribe((result: any) => {
            this.listatarefas = result;
            this.dataSource = new MatTableDataSource(this.listatarefas);
            this.dataSource.sort = this.sort;
            this.displayedColumns = this.columnNames.map(m=>m.id);
        });
    }

    criar(){
        this.router.navigateByUrl('/tarefa/0');
    }

    editar(id:any){

        this.router.navigateByUrl('/tarefa/' + id);
    }

    detalhe(id:any){

        this.router.navigateByUrl('/tarefa-detalhe/' + id);
    }

    excluir(id:string){

        this.apiService.delete('tarefas/deletar/' + id ).subscribe((result: any) => {
          this.buscartarefas();
        });
    }
}
