import { Component, OnInit } from '@angular/core';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { QuestionControl } from '../models/question-control.model';
import { questionTypes } from '../models/question-type.enum';

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

  constructor(private fb: FormBuilder) {

    this.generateFormFormGroup = this.fb.group({
      title: '',
      description: '',
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
      title: '',
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
}
