import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  constructor(private homeService: HomeService) {

  }
  ngOnInit(): void {
    this.getReadingData();
  }
  getReadingData() {
    this.homeService.getReadingData(1, 1, 1).subscribe((res: any) => {
      console.log(res);
    })
  }
}
