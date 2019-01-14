import { Component, OnInit } from '@angular/core';
import * as CanvasJS from '../../../canvasjs.min.js';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    let chart = new CanvasJS.Chart("chartContainer", {
      theme: "light2",
      animationEnabled: true,
      exportEnabled: true,
      title:{
        text: "Statistica note"
      },
      data: [{
        type: "pie",
        showInLegend: true,
        toolTipContent: "<b>{name}</b>: ${y} (#percent%)",
        indexLabel: "{name} - #percent%",
        dataPoints: [
          { y: 5, name: "Nota 5 - 5,99" },
          { y: 6, name: "Nota 6 - 6,99" },
          { y: 7, name: "Nota 7 - 7,99" },
          { y: 8, name: "Nota 8 - 8,99" },
          { y: 9, name: "Nota 9 - 9,99"},
          { y: 10, name: "Nota 10" }
        ]
      }]
    });

    chart.render();
  }


}
