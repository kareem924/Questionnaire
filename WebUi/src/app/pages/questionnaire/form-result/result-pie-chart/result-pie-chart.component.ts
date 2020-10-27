import { OnDestroy } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { NbThemeService } from '@nebular/theme';

@Component({
  selector: 'app-result-pie-chart',
  templateUrl: './result-pie-chart.component.html',
  styleUrls: ['./result-pie-chart.component.scss']
})
export class ResultPieChartComponent implements OnInit, OnDestroy {
  @Input() labels: any;
  @Input() values: any;
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService) {

  }
  ngOnInit(): void {
    this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;
      console.log(colors)
      this.data = {
        labels: this.labels,
        datasets: [{
          data: this.values,
          backgroundColor: [colors.primaryLight, colors.infoLight, colors.successLight],
        }],
      };

      this.options = {
        maintainAspectRatio: false,
        responsive: true,
        scales: {
          xAxes: [
            {
              display: false,
            },
          ],
          yAxes: [
            {
              display: false,
            },
          ],
        },
        legend: {
          labels: {
            fontColor: chartjs.textColor,
          },
        },
      };
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
