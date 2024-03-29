import { QuestionBase } from './../../../../models/question-base';
import { AbstractControl, ValidationErrors, ControlValueAccessor, Validator, NG_VALUE_ACCESSOR, NG_VALIDATORS } from '@angular/forms';
import { Component, OnInit, Input, forwardRef } from '@angular/core';

@Component({
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DateTimeComponent),
      multi: true,
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => DateTimeComponent),
      multi: true,
    }
  ],
  selector: 'app-date-time',
  templateUrl: './date-time.component.html',
  styleUrls: ['./date-time.component.scss']
})
export class DateTimeComponent implements OnInit, ControlValueAccessor, Validator {

  @Input() question: QuestionBase;
  @Input('value') val: string;
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


}
