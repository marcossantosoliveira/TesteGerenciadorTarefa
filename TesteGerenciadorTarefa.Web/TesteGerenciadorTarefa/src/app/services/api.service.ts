import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable} from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class ApiService {
    public httpOptions: any = null;
    private urlAPI = 'http://localhost:31362/api/';

    constructor(private http: HttpClient, private router: Router) { }

    private setHeaders() {
        this.httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        };
    }

    private obterUrlAPI(): string {
        return this.urlAPI;
    }

    public get(url: string): Observable<{}> {
        this.setHeaders();
        let requisicao = this.http.get(this.obterUrlAPI() + url, this.httpOptions).pipe(
        );

        return requisicao;
    }

    public post(url: string, parametros: any, showSpinner: boolean = true): Observable<{}> {
        this.setHeaders();
        let requisicao = this.http.post(this.obterUrlAPI() + url, JSON.stringify(parametros), this.httpOptions).pipe(

        );

        return requisicao;
    }

    public put(url: string, parametros: any): Observable<{}> {
        this.setHeaders();

        return this.http.put(this.obterUrlAPI() + url, JSON.stringify(parametros), this.httpOptions);
    }

    public delete(url: string): Observable<{}> {
        this.setHeaders();

        return this.http.delete(this.obterUrlAPI() + url, this.httpOptions);
    }
}
