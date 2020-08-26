import { Component, OnInit } from '@angular/core';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { FormBuilder, FormGroup, Validators, FormArray, ValidationErrors } from '@angular/forms';
import { QuestionControl, CreateForm } from '../models/question-control.model';
import { questionTypes } from '../models/question-type.enum';
import { FormsService } from '../form.service';
import { NbToastrService } from '@nebular/theme';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'ngx-generate-form',
  templateUrl: './generate-form.component.html',
  styleUrls: ['./generate-form.component.scss'],
  animations: [
    trigger('tabState', [state('default', style({
      top: '{{top}}'
    }), { params: { top: "202px" } }),
    state('ss', style({
      top: '{{top}}'
    }), { params: { top: "202px" } }),
    transition('default <=> open', animate(500))
    ])
  ]
})
export class GenerateFormComponent implements OnInit {

  generateFormFormGroup: FormGroup;
  state = "default";
  top = "202"
  selectedSectionIndex = 0;
  @BlockUI() blockUI: NgBlockUI;

  constructor(private fb: FormBuilder,
    private formService: FormsService,
    private toastrService: NbToastrService,
    private router: Router) {

    this.generateFormFormGroup = this.fb.group({
      sections: this.fb.array([this.newSection()]),
    })
  }
  ngOnInit(): void {

  }


  sections(): FormArray {
    return this.generateFormFormGroup.get("sections") as FormArray
  }

  newSection(): FormGroup {
    return this.fb.group({
      title: ['', Validators.required],
      description: '',
      fields: this.fb.array([this.newField()])
    })
  }

  addSection() {
    this.sections().push(this.newSection());
  }

  removeSection(sectionIndex: number) {
    this.sections().removeAt(sectionIndex);
  }

  duplicateSection(sectionIndex: number) {
    const selectedSection = this.sections().at(sectionIndex);
    this.sections().push(selectedSection);
  }

  sectionFields(empIndex: number): FormArray {
    return this.sections().at(empIndex).get("fields") as FormArray
  }

  newField(): FormGroup {
    const field = new QuestionControl();
    field.isRequired = false;
    field.selectedType = questionTypes[0];
    return this.fb.group({
      field: field
    })
  }

  addSectionField() {
    this.sectionFields(this.selectedSectionIndex).push(this.newField());
  }

  removeSectionField(sectionIndex: number, fieldIndex: number) {
    this.sectionFields(sectionIndex).removeAt(fieldIndex);
  }

  duplicateField(sectionIndex: number, fieldIndex: number) {
    const selectedField = this.sectionFields(sectionIndex).controls[fieldIndex];
    this.sectionFields(sectionIndex).push(selectedField);
  }

  submit() {
    this.blockUI.start('Loading...');
    console.log(this.generateFormFormGroup.value);
    this.formService.Create(this.generateFormModel()).subscribe(() => {
      this.blockUI.stop();
      this.toastrService.success('Saved Successfuly.')
    })
  }
  onComeIn($event: any) {
    var target = $event.currentTarget;

    var pElement = target.getBoundingClientRect().top;
    // var pclassAttr = pElement.attributes.class;
    let el = $event.srcElement.getBoundingClientRect().top;
    if (this.state === 'default') {
      this.state = 'default';
      this.top = pElement + "px";
    } else {
      this.state = 'default';
      this.top = pElement + "px";
    }
  }

  drop(event: CdkDragDrop<any[]>, sectionIndex) {
    moveItemInArray(this.sectionFields(sectionIndex).controls, event.previousIndex, event.currentIndex);
  }

  routeToSubmit() {
    this.blockUI.start('Loading...');
    this.formService.Create(this.generateFormModel()).subscribe((result) => {
      this.blockUI.stop();
      this.toastrService.success('Saved Successfuly.')
      this.router.navigateByUrl(`/pages/questions/submit/${result}`);
    })
  }

  generateFormModel(): CreateForm {
    console.log(this.generateFormFormGroup.value);
    const sections = [];
    this.generateFormFormGroup.value.sections.forEach(section => {
      sections.push({
        title: section.title, description: section.description,
        fields: section.fields.map((field, index) => {
          const nestedField = field.field;
          return {
            type: nestedField.selectedType.type,
            isRequired: nestedField.isRequired || false,
            label: nestedField.label || '',
            fieldOptions: nestedField.options.map((option, index) => {
              return { value: option.optionValue, order: index };
            }),
            ratingValue: nestedField.rateValue,
            order: index
          }
        })
      })
    });
    const createModel = new CreateForm();
    createModel.sections = sections;
    return createModel;
  }

  getAllErrors(form: FormGroup | FormArray): { [key: string]: any; } | null {
    let hasError = false;
    const result = Object.keys(form.controls).reduce((acc, key) => {
        const control = form.get(key);
        const errors = (control instanceof FormGroup || control instanceof FormArray)
            ? this.getAllErrors(control)
            : control.errors;
        if (errors) {
            acc[key] = errors;
            hasError = true;
        }
        return acc;
    }, {} as { [key: string]: any; });
    return hasError ? result : null;
}
}
