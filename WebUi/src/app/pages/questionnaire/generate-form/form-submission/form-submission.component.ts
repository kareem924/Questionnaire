import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormsService } from './../../form.service';
import { questionType } from './../../models/question-control.model';
import { SectionModel } from './../../models/section-model';
import { FormGroup, FormBuilder, AbstractControl, FormArray } from '@angular/forms';
import { QuestionBase, RatingValue } from './../../models/question-base';
import { Component, OnInit, Input } from '@angular/core';
import { QuestionControlService } from '../../question-control-service.service';
import { QuestionType } from '../../models/question-type.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { SubmitModel } from '../../models/submit-model';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'ngx-form-submission',
  templateUrl: './form-submission.component.html',
  styleUrls: ['./form-submission.component.scss'],
})
export class FormSubmissionComponent implements OnInit {

  sections: SectionModel[] = [];
  form: FormGroup;
  payLoad: any;
  formId: any;
  get formArray(): AbstractControl | null { return this.form.get('formArray'); }
  @BlockUI() blockUI: NgBlockUI;

  constructor(
    private qcs: QuestionControlService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toastrService: NbToastrService,
    private formService: FormsService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.form = this.formBuilder.group({ formArray: [] })
    this.formId = this.activatedRoute.snapshot.paramMap.get('id');
    this.formService.GetById(this.formId).subscribe(result => {
      result.sections.forEach(section => {
        this.sections.push(new SectionModel({
          name: section.title,
          questions: section.fields.map(field => {
            return new QuestionBase({
              key: field.id,
              label: field.label,
              required: field.isRequired,
              order: 1,
              controlType: field.type,
              type: 'text',
              ratingValue: field.ratingValue || new RatingValue(
                {
                  from: field.ratingValue.from,
                  to: field.ratingValue.to,
                  fromLabel: field.ratingValue.fromLabel,
                  toLabel: field.ratingValue.toLabel
                }),
              options: field.fieldOptions
                .map((option: { id: any; value: any; }) => {
                  return { key: option.id, value: option.value, checked: false }
                })
            })
          })
        }));
      });
      console.log(this.sections)
      const forms: any = [];
      this.sections.forEach((section, index) => {
        forms.push(this.qcs.toFormGroup(section.questions))
      })
      this.form = this.formBuilder.group({ formArray: this.formBuilder.array(forms) })
    })
  }

  onSubmit() {
    this.blockUI.start('Loading...');
    this.payLoad = this.form.getRawValue();
    console.log(this.payLoad)
    console.log(this.testArray)
    const values = [];
    this.payLoad.formArray.forEach((element) => {
      console.log(element)
      for (var i in element) {

        const question = this.getQuestion(parseInt(i));
        if (question.controlType === QuestionType.CheckBox ||
          question.controlType === QuestionType.DropDown ||
          question.controlType === QuestionType.MultipleChoice) {
          const value = { id: parseInt(i), values: null }
          if (Array.isArray(element[i])) {
            value.values = element[i];
          }
          else {
            value.values = [element[i]]
          }
          values.push(value);
        }
        else {
          const value = { id: parseInt(i), value: element[i] }
          values.push(value);
        }
      }
    });
    const submitModel = new SubmitModel();
    submitModel.formId = parseInt(this.formId);
    submitModel.FiledsValues = values;
    console.log(submitModel)
    this.formService.SubmitForm(submitModel).subscribe(() => {
      this.blockUI.stop();
      this.toastrService.success('Saved Successfuly.')
      setTimeout(() => {
        this.router.navigateByUrl(`/pages/questions/success`);
      }, 400);
    })
  }

  get testArray() {
    return this.form?.get('formArray') as FormArray;
  }

  testControls(): any[] {
    return this.testArray.controls;
  }

  getQuestion(id: any): QuestionBase {
    const questions = this.sections.reduce((pn, u) => [...pn, ...u.questions], []);
    return questions.find(question => question.key == id);
  }

  getSection(index: any): SectionModel {
    return this.sections[index];
  }

  getControl(control: any) {
    console.log(control)
  }
}
