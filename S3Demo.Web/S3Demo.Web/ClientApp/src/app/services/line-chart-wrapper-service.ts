import { Injectable } from "@angular/core";
import * as CanvasJS from '../../assets/canvasjs.min';
import { Reading } from "../models/reading";

@Injectable({
  providedIn: "root"
})
export class LineChartWrapperService {
  renderReadingDataChart(data: Array<Reading>) {
    //let dataPoints = [];
    //let y = 0;
    //for (var i = 0; i < data.length; i++) {
    //  dataPoints.push({ y: data[i].Value })
    //}
    //let chart = new CanvasJS.Chart("chartContainer", {
    //  zoomEnabled: true,
    //  animationEnabled: true,
    //  exportEnabled: true,
    //  title: {
    //    text: "Time series data"
    //  },
    //  data: [
    //    {
    //      type: "line",
    //      dataPoints: dataPoints
    //    }]
    //});

    //chart.render();

    let dataPoints = [];
    let dpsLength = 0;
    let chart = new CanvasJS.Chart("chartContainer", {
      exportEnabled: true,
      title: {
        text: "Timeseries Data"
      },
      data: [{
        type: "line",
        dataPoints: dataPoints,
      }]
    });

    for (var i = 0; i < data.length; i++) {
      dataPoints.push({ y: data[i].Value, x: parseInt(data[i].Timestamp) })
    }

    dpsLength = dataPoints.length;
    chart.render();
  }
}
