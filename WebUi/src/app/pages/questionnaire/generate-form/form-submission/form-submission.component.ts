import { questionType } from './../../models/question-control.model';
import { SectionModel } from './../../models/section-model';
import { FormGroup, FormBuilder, AbstractControl, FormArray } from '@angular/forms';
import { QuestionBase, RatingValue } from './../../models/question-base';
import { Component, OnInit, Input } from '@angular/core';
import { QuestionControlService } from '../../question-control-service.service';
import { QuestionType } from '../../models/question-type.enum';

@Component({
  selector: 'ngx-form-submission',
  templateUrl: './form-submission.component.html',
  styleUrls: ['./form-submission.component.scss'],
})
export class FormSubmissionComponent implements OnInit {

  sections: SectionModel[] = [];
  form: FormGroup;
  payLoad = '';
  get formArray(): AbstractControl | null { return this.form.get('formArray'); }

  constructor(
    private qcs: QuestionControlService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.sections.push(new SectionModel({
      name: 'test', questions: [
        new QuestionBase({
          key: '1',
          label: 'test',
          required: true,
          order: 1,
          controlType: QuestionType.TextBox,
          type: 'text',
        }),
        new QuestionBase({
          key: '1',
          label: 'test',
          required: true,
          order: 1,
          controlType: QuestionType.TextArea,
          type: 'text',
        }),
        new QuestionBase({
          key: '2',
          label: 'test1',
          required: true,
          order: 1,
          controlType: QuestionType.Time,
          type: 'text1',
        }),
        new QuestionBase({
          key: '3',
          label: 'test2',
          required: true,
          order: 1,
          controlType: QuestionType.Date,
          type: 'text1',
        }),
        new QuestionBase({
          key: '8',
          label: 'test8',
          required: true,
          order: 1,
          controlType: QuestionType.LinearScale,
          type: 'text1',
          ratingValue: new RatingValue({ from: 1, to: 8, fromLabel: 'from' })
        })
      ]
    }),
      new SectionModel({
        name: 'test 2',
        questions: [
          new QuestionBase({
            key: '5',
            label: 'CheckBox',
            required: true,
            order: 1,
            controlType: QuestionType.CheckBox,
            type: 'text1',
            options: [
              { key: '1', value: 'test 1', checked: false },
              { key: '2', value: 'test 2', checked: false },
              { key: '3', value: 'test 3', checked: false }]
          }), new QuestionBase({
            key: '6',
            label: 'MultipleChoice',
            required: true,
            order: 1,
            controlType: QuestionType.MultipleChoice,
            type: 'text1',
            options: [
              { key: '1', value: 'test 1', checked: false },
              { key: '2', value: 'test 2', checked: false },
              { key: '3', value: 'test 3', checked: false }]
          }), new QuestionBase({
            key: '7',
            label: 'test7',
            required: true,
            order: 1,
            controlType: QuestionType.LinearRate,
            type: 'text1',
            ratingValue: new RatingValue({ from: 1, to: 10, fromLabel: 'from', toLabel: 'to' })
          }),]
      }))
    const forms: any = [];
    this.sections.forEach((section, index) => {
      forms.push(this.qcs.toFormGroup(section.questions))
    })
    console.log(forms)
    this.form = this.formBuilder.group({ formArray: this.formBuilder.array(forms) })
    console.log(this.form)
    console.log(this.formArray)
    console.log((this.formArray?.get([0])))
    console.log(this.formArray?.get([1]))
    console.log(this.testArray.controls)
    console.log(this.testArray.controls[0])
    console.log(this.testArray.controls[1])
    console.log(this.testArray.value)

  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
  }

  get testArray() {
    return this.form.get('formArray') as FormArray;
  }

  testControls(): any[] {
    return this.testArray.controls;
  }

  getQuestion(id: any): QuestionBase {
    const questions = this.sections.reduce((pn, u) => [...pn, ...u.questions], []);
    return questions.find(question => question.key === id);
  }

  getControl(control: any) {
    console.log(control)
  }
}
