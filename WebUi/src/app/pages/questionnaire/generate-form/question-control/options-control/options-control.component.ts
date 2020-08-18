import { Component, OnInit, forwardRef, Input } from '@angular/core';
import { OptionsValue } from '../../../models/question-control.model';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { QuestionType } from '../../../models/question-type.enum';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'ngx-options-control',
  templateUrl: './options-control.component.html',
  styleUrls: ['./options-control.component.scss'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => OptionsControlComponent),
    multi: true
  }]
})
export class OptionsControlComponent implements ControlValueAccessor, OnInit {

  options: OptionsValue[];
  @Input() type: QuestionType;
  types = QuestionType;

  constructor() { }

  ngOnInit() {
  }

  addOption() {
    this.options.push({ optionValue: `Option ${this.options.length + 1}` })
    this.propagateChange(this.options);
  }

  removeOption(index: number) {
    this.options.splice(index, 1);
    this.propagateChange(this.options);
  }

  writeValue(value: OptionsValue[]): void {
    if (value !== undefined) {
      this.options = value;

    }
  }

  propagateChange = (_: any) => { };

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() { }

  setDisabledState?(isDisabled: boolean): void {
  }

  drop(event: CdkDragDrop<OptionsValue[]>) {
    moveItemInArray(this.options, event.previousIndex, event.currentIndex);
  }
}
