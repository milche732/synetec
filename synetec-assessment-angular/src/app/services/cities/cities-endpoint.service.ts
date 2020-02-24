import { Injectable, Injector } from "@angular/core";
import { environment } from "../../../environments/environment";
import { BaseService } from "../base.service";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { ICity } from "../../models/city.model";

@Injectable()
export class CitiesEndpoint extends BaseService {

    constructor(private _httpClient: HttpClient, private _injector: Injector) {
        super(_httpClient, _injector);
    }

    get(): Observable<Array<ICity>> {
        let baseUrl = this.getBaseUrl();
        return this._httpClient.get<Array<ICity>>(`${baseUrl}api/cities`, this.getRequestHeaders());
    }

    delete(id: number): Observable<any> {
        let baseUrl = this.getBaseUrl();
        return this._httpClient.delete(`${baseUrl}api/cities/delete-city/${id}`, this.getRequestHeaders());
    }
}
