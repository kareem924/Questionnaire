import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbThemeService, NbToastrService } from '@nebular/theme';
import { FormsService } from '../form.service';

@Component({
  selector: 'app-form-result',
  templateUrl: './form-result.component.html',
  styleUrls: ['./form-result.component.scss']
})
export class FormResultComponent implements OnInit {
  options: any;
  formId: any;
  formSummary: any;

  constructor(private theme: NbThemeService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toastrService: NbToastrService,
    private formService: FormsService) { }

  ngOnInit() {
    this.theme.getJsTheme().subscribe(config => {
      const chartjs: any = config.variables.chartjs;
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

    this.formId = this.activatedRoute.snapshot.paramMap.get('id');
    this.formService.GetFormSummary(this.formId).subscribe(result => {
      console.log(result);
      this.formSummary = result;
    });
  }

}
