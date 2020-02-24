import { Injectable } from "@angular/core";
import { CitiesEndpoint } from "./cities-endpoint.service";
import { ICity } from "../../models/city.model";
import { Observable } from "rxjs/Observable";
import { extend } from "webdriver-js-extender";

@Injectable()
export class CitiesService {
    constructor(private _citiesEndpoint: CitiesEndpoint) { }
    get(): Observable<ICity[]> {
        return this._citiesEndpoint.get();     
    }
    delete(id: number): Observable<any> {
        return this._citiesEndpoint.delete(id);     
    }
}
