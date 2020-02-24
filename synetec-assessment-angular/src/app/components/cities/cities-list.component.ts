import { Component, OnInit, OnDestroy } from "@angular/core";
import { ICity } from "../../models/city.model";
import { CitiesService } from "../../services/cities";
import { Subscription } from "rxjs/Subscription";
import { catchError, map, first, takeUntil } from 'rxjs/operators';
import { Observable } from "rxjs/Observable";
import { Subject } from "rxjs/Subject";
import { AlertService } from "../../services/alert.service";

@Component({
    selector: 'cities-list',
    templateUrl: './cities-list.component.html',
    styleUrls: ['./cities-list.component.css']
})

export class CitiesListComponent implements OnInit, OnDestroy {
    ngOnDestroy(): void {
        this.destroy$.next();  // trigger the unsubscribe
        this.destroy$.complete(); // finalize & clean up the subject stream
    }
    cities: ICity[] = [];
    errorReceived: boolean = false;
    private destroy$ = new Subject();
    constructor(private _citiesService: CitiesService, private alertService: AlertService) { }

    ngOnInit(): void {
        this.loadCities();
    }

    loadCities() {
        //we do not need to unsubsribe from Observable, because HTTP request calls observer.complete() on receive,
        //which automatially unsubscribe all subscriptions, but there are controversial opionions about memory leaks
        //so we explicitly unsubscribe
        this._citiesService.get().pipe(
            takeUntil(this.destroy$),
            map(x => {
            this.cities = x;
        }), catchError((err) => this.handleError(err))).subscribe();
    }

    delete(id: number) {
        let that = this;
        this.alertService.confirmThis("Are you sure you want to remove city from the list?", function () {

            that._citiesService.delete(id).pipe(
                takeUntil(that.destroy$),
                map(x => {
                    //since backend has an bug in implementation of city deletion because of ToList().Remove
                    //next line actually "hides" that problem, but server side API should not rely on UI anyway
                    //and must be covered by UnitTests
                    that.cities = that.cities.filter(x => x.id != id);
                    //this.loadCities();
                }), catchError((err) => that.handleError(err))).subscribe();

        }, function () {
        }) 

       
    }

    private handleError(error: any) {
        console.log(error);
        this.errorReceived = true;
        return Observable.throw(error);
    }
}
