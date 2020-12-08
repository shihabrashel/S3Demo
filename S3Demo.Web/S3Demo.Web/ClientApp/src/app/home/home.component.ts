import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home-service';
import { LineChartWrapperService } from '../services/line-chart-wrapper-service';
import { S3IntFilter } from '../models/s3-int-filter';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  buildingId: number = 0;
  objectId: number = 0;
  dataFieldId: number = 0;
  startDate: Date = new Date();
  endDate: Date = new Date();
  buildingList: Array<S3IntFilter> = [];
  objectList: Array<S3IntFilter> = [];
  dataFieldList: Array<S3IntFilter> = [];
  constructor(private homeService: HomeService
    , private lineChartWrapperService: LineChartWrapperService) {

  }
  ngOnInit(): void {
    //this.lineChartWrapperService.renderReadingDataChart();
    this.getBuildingList();
  }
  getReadingData() {
    this.homeService.getReadingData(this.buildingId, this.objectId, this.dataFieldId, this.startDate.toISOString(), this.endDate.toISOString()).subscribe((res: any) => {
      console.log(res);
      this.lineChartWrapperService.renderReadingDataChart(res);
    })
  }
  getBuildingList() {
    this.homeService.getBuildings().subscribe((res: any) => {
      this.buildingList = res;
      this.buildingId = res && res.length > 0 ? res[0].Id : 0;
      this.getObjectList();
    })
  }
  getObjectList() {
    this.homeService.getObjects().subscribe((res: any) => {
      this.objectList = res;
      this.objectId = res && res.length > 0 ? res[0].Id : 0;
      this.getDataFields();
    })
  }
  getDataFields() {
    this.homeService.getDataFields().subscribe((res: any) => {
      this.dataFieldList = res;
      this.dataFieldId = res && res.length > 0 ? res[0].Id : 0;
      this.getReadingData();
    })
  }
}
