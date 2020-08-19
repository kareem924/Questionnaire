import { FormGroup } from '@angular/forms';
import { QuestionBase } from './../../models/question-base';
import { Component, OnInit, Input } from '@angular/core';
import { QuestionControlService } from '../../question-control-service.service';
import { QuestionType } from '../../models/question-type.enum';

@Component({
  selector: 'ngx-form-submission',
  templateUrl: './form-submission.component.html',
  styleUrls: ['./form-submission.component.scss'],
})
export class FormSubmissionComponent implements OnInit {

  questions: QuestionBase[] = [];
  form: FormGroup;
  payLoad = '';

  constructor(private qcs: QuestionControlService) { }

  ngOnInit() {
    this.questions.push(new QuestionBase({
      key: '1',
      label: 'test',
      required: true,
      order: 1,
      controlType: QuestionType.TextBox,
      type: 'text',
    }));
    this.questions.push(new QuestionBase({
      key: '2',
      label: 'test1',
      required: true,
      order: 1,
      controlType: QuestionType.Time,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '3',
      label: 'test2',
      required: true,
      order: 1,
      controlType: QuestionType.Date,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '4',
      label: 'test4',
      required: true,
      order: 1,
      controlType: QuestionType.DropDown,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '5',
      label: 'test5',
      required: true,
      order: 1,
      controlType: QuestionType.CheckBox,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '6',
      label: 'test6',
      required: true,
      order: 1,
      controlType: QuestionType.MultipleChoice,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '7',
      label: 'test7',
      required: true,
      order: 1,
      controlType: QuestionType.LinearRate,
      type: 'text1',
    }));
    this.questions.push(new QuestionBase({
      key: '8',
      label: 'test8',
      required: true,
      order: 1,
      controlType: QuestionType.LinearScale,
      type: 'text1',
    }));
    this.form = this.qcs.toFormGroup(this.questions);
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
  }

}
