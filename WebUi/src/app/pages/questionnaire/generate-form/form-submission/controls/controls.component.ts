import { QuestionType } from './../../../models/question-type.enum';
import { QuestionBase } from './../../../models/question-base';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.scss']
})
export class ControlsComponent implements OnInit {

  @Input() question: QuestionBase;
  @Input() form: FormGroup;
  controlTypes = QuestionType;
  constructor() { }

  ngOnInit(): void {

  }

  getControl(key: string) {
    const control = this.form.controls[key];
    return control;
  }
}
