import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home-service';
import { LineChartWrapperService } from '../services/line-chart-wrapper-service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(private homeService: HomeService
    , private lineChartWrapperService: LineChartWrapperService) {

  }
  ngOnInit(): void {
    this.lineChartWrapperService.renderReadingDataChart();
  }
  getReadingData() {
    this.homeService.getReadingData(1, 1, 1).subscribe((res: any) => {
      console.log(res);
    })
  }
  
}
