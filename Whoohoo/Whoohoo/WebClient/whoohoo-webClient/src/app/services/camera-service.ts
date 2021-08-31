import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Camera } from '../models/camera';
import { CamerasDivided } from '../models/cameras-divided';

@Injectable({
  providedIn: 'root'
})

export class CameraService {
  private apiUrl: string = 'api/camera/'

  constructor(private http: HttpClient) { }

  public getCameras(): Observable<Camera[]> {
    return this.http.get<Camera[]>(this.createApiUrl('GetAll'))
      .pipe(
        catchError(this.handleError)
      )
  }

  public getDividedCameras(): Observable<CamerasDivided> {
    return this.http.get<CamerasDivided>(this.createApiUrl('GetDivided'))
      .pipe(
        catchError(this.handleError)
      )
  }

  private createApiUrl(url: string): string {
    return this.apiUrl + url;
  }

  private handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}