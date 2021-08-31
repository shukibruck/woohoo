import { AfterViewInit, Component, OnInit } from '@angular/core';
import { CameraService } from '../services/camera-service';
import * as leaflet from 'leaflet';
import { Observable } from 'rxjs';
import { Camera } from '../models/camera';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit, AfterViewInit {
  private map: any;
  private $cameras: Observable<Camera[]>

  constructor(private cameraService: CameraService) { }

  ngAfterViewInit(): void {
    this.initMap();
    this.addMarkersToMap();
  }

  ngOnInit(): void {
    this.$cameras = this.cameraService.getCameras();
  }

  private initMap(): void {
    this.map = leaflet.map('map', {
      center: [52.0914, 5.1115],
      zoom: 12
    });

    const tiles = leaflet.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    tiles.addTo(this.map);
  }

  private addMarkersToMap(): void {
    this.$cameras.subscribe(cam => {
      cam.forEach(c => {
        leaflet.marker([c.latitude, c.longitude])
         .bindPopup("<b> Id: " + c.id + "</b><br>" + c.name + "")
         .addTo(this.map);
      })
    })
  }
}
