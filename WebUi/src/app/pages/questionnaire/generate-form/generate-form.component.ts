import { Component, OnInit } from '@angular/core';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { QuestionControl, CreateForm } from '../models/question-control.model';
import { questionTypes } from '../models/question-type.enum';
import { FormsService } from '../form.service';
import { NbToastrService } from '@nebular/theme';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'ngx-generate-form',
  templateUrl: './generate-form.component.html',
  styleUrls: ['./generate-form.component.css'],
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

  constructor(private fb: FormBuilder, private formService: FormsService,
    private toastrService: NbToastrService) {

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
    console.log("Adding a section");
    this.sections().push(this.newSection());
  }


  removeSection(empIndex: number) {
    this.sections().removeAt(empIndex);
  }

  duplicateSection(sectionIndex: number) {

    const selectedSection = this.sections().at(sectionIndex);
    console.log(selectedSection)
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
    console.log(this.generateFormFormGroup.value);
    const sections = [];
    this.generateFormFormGroup.value.sections.forEach(section => {
      sections.push({
        title: section.title, description: section.description,
        fields: section.fields.map(field => {
          const nestedField = field.field;
          return {
            type: nestedField.selectedType.type,
            isRequired: nestedField.isRequired || false,
            label: nestedField.label || '',
            fieldOptions: nestedField.options.map(option => { value: option.optionValue }),
            ratingValue: nestedField.rateValue
          }
        })
      })
    });
    const createModel = new CreateForm();
    createModel.sections = sections;
    this.formService.Create(createModel).subscribe(() => {
      this.toastrService.success('Saved Successfuly.')
    })
  }
  onComeIn($event: any) {
    var target = $event.currentTarget;

    var pElement = target.getBoundingClientRect().top;
    // var pclassAttr = pElement.attributes.class;
    console.log(pElement);
    let el = $event.srcElement.getBoundingClientRect().top;
    console.log(el)
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
}
