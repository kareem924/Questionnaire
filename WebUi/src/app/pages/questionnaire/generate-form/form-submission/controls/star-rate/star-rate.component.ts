import { NG_VALUE_ACCESSOR, NG_VALIDATORS, ControlValueAccessor, Validator, AbstractControl, ValidationErrors } from '@angular/forms';
import { Component, OnInit, forwardRef, Input } from '@angular/core';
import { QuestionBase } from '../../../../models/question-base';

@Component({
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => StarRateComponent),
      multi: true,
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => StarRateComponent),
      multi: true,
    },
  ],
  selector: 'app-star-rate',
  templateUrl: './star-rate.component.html',
  styleUrls: ['./star-rate.component.scss'],
})
export class StarRateComponent implements OnInit, ControlValueAccessor, Validator {

  ratingArr = [];
  rating: number;
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
    for (let i = this.question.ratingValue.from; i < this.question.ratingValue.to; i++) {
      this.ratingArr.push(i);
    }
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

  onClick(rating: number) {
    this.rating = rating;
    this.value = rating.toString();
  }

  showIcon(index: number) {
    if (this.rating >= index + 1) {
      return 'star';
    } else {
      return 'star_border';
    }
  }
}

