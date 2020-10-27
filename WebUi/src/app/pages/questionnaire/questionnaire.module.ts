import { BlockUIModule } from 'ng-block-ui';
import { SliderRateComponent } from './generate-form/form-submission/controls/slider-rate/slider-rate.component';
import { TimeComponent } from './generate-form/form-submission/controls/time/time.component';
import { StarRateComponent } from './generate-form/form-submission/controls/star-rate/star-rate.component';
import { RadioButtonComponent } from './generate-form/form-submission/controls/radio-button/radio-button.component';
import { DropdownListComponent } from './generate-form/form-submission/controls/dropdown-list/dropdown-list.component';
import { DateTimeComponent } from './generate-form/form-submission/controls/date-time/date-time.component';
import { CheckboxComponent } from './generate-form/form-submission/controls/checkbox/checkbox.component';
import { LinearScaleControlComponent } from './generate-form/question-control/linear-scale-control/linear-scale-control.component';
import { OptionsControlComponent } from './generate-form/question-control/options-control/options-control.component';
import { QuestionControlComponent } from './generate-form/question-control/question-control.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenerateFormComponent } from './generate-form/generate-form.component';
import { Routes, RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '../../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { FormSubmissionComponent } from './generate-form/form-submission/form-submission.component';
import { ControlsComponent } from './generate-form/form-submission/controls/controls.component';
import { InputComponent } from './generate-form/form-submission/controls/input/input.component';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { StarRatingModule } from 'angular-star-rating';
import { SuccessSubmissionComponent } from './generate-form/form-submission/success-submission/success-submission.component';
import { FormResultComponent } from './form-result/form-result.component';
import { NgxEchartsModule } from 'ngx-echarts';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ChartModule } from 'angular2-chartjs';
import { NbCardModule } from '@nebular/theme';
import { ResultPieChartComponent } from './form-result/result-pie-chart/result-pie-chart.component';

const routes: Routes = [
  {
    path: '',
    component: GenerateFormComponent,
  },
  {
    path: 'submit/:id',
    component: FormSubmissionComponent,
  },
  {
    path: 'result/:id',
    component: FormResultComponent,
  },
  {
    path: 'success',
    component: SuccessSubmissionComponent,
  },
];

@NgModule({
  imports: [
    CommonModule,
    DragDropModule,
    RouterModule.forChild(routes),
    BlockUIModule.forRoot(),
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    NgxEchartsModule,
    NgxChartsModule,
    ChartModule,
    NbCardModule,
    NgxMaterialTimepickerModule,
    StarRatingModule.forRoot(),
  ],
  declarations: [
    GenerateFormComponent,
    QuestionControlComponent,
    OptionsControlComponent,
    LinearScaleControlComponent,
    FormSubmissionComponent,
    ControlsComponent,
    InputComponent,
    CheckboxComponent,
    DateTimeComponent,
    DropdownListComponent,
    RadioButtonComponent,
    StarRateComponent,
    SuccessSubmissionComponent,
    TimeComponent,
    SliderRateComponent,
    FormResultComponent,
    ResultPieChartComponent],
})
export class QuestionnaireModule { }
