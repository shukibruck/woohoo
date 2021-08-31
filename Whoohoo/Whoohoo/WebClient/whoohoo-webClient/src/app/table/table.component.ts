import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CamerasDivided } from '../models/cameras-divided';
import { CameraService } from '../services/camera-service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  $camerasDivided: Observable<CamerasDivided>;

  constructor(private cameraService: CameraService) { }

  ngOnInit() {
    this.$camerasDivided = this.cameraService.getDividedCameras();
  }
}
