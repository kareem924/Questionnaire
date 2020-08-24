import { questionType } from './../../../../models/question-control.model';
import { QuestionBase } from './../../../../models/question-base';
import { ControlValueAccessor, AbstractControl, ValidationErrors, Validator, NG_VALUE_ACCESSOR, NG_VALIDATORS } from '@angular/forms';
import { Component, OnInit, Input, forwardRef } from '@angular/core';

@Component({
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true,
    }
  ],
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss']
})
export class CheckboxComponent implements OnInit, ControlValueAccessor, Validator {

  @Input() question: QuestionBase;
  @Input('value') val: any;
  get value() {
    return this.val;
  }
  set value(val) {
    console.log(val);
    this.val = val;
    this.onChange(val);
    this.onTouched();
  }
  constructor() { }

  ngOnInit() {
  }

  onChange: any = () => {
    console.log(this.val);
  }

  onTouched: any = () => { };

  writeValue(obj: any): void {
    if (obj) {
      this.value = obj;
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }

  validate(control: AbstractControl): ValidationErrors {

    if (this.question.required) {
      return (this.val)
        ? null
        : {
          jsonParseError: {
            valid: false,
          },
        };
    } else {
      return null;
    }

  }

  registerOnValidatorChange?(fn: () => void): void {
    // this.onChange = fn;
  }

  valueChange(option, $event) {
    //set the two-way binding here for the specific unit with the event
    this.question.options
      .find(optionfinded => optionfinded.key === option.key).checked = $event.checked;
    const values = this.question.options;
    const valuesMaped = values.map(value => {
      if (value.checked) {
        return String(value.key);
      } else {
        return '';
      }
    }).filter(mapped => mapped);
    this.value = valuesMaped;
    console.log(this.value)
  }

}
