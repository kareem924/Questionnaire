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

const routes: Routes = [
  {
    path: '',
    component: GenerateFormComponent,

  },
];

@NgModule({
  imports: [
    CommonModule,
    DragDropModule,
    RouterModule.forChild(routes),
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  declarations: [
    GenerateFormComponent,
    QuestionControlComponent,
    OptionsControlComponent,
    LinearScaleControlComponent]
})
export class QuestionnaireModule { }
