import { QuestionControl } from './../../models/question-control.model';
import { Component, OnInit, HostListener, forwardRef, Output, EventEmitter, Input, AfterViewInit } from '@angular/core';
import { questionTypes } from '../../models/question-type.enum';
import { ControlValueAccessor, NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';



@Component({
  selector: 'ngx-question-control',
  templateUrl: './question-control.component.html',
  styleUrls: ['./question-control.component.scss'],
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: forwardRef(() => QuestionControlComponent),
    multi: true
  },
  {
    provide: NG_VALIDATORS,
    useExisting: forwardRef(() => QuestionControlComponent),
    multi: true,
  }]
})

export class QuestionControlComponent implements ControlValueAccessor, AfterViewInit, OnInit, Validator {

  questionTypes = questionTypes;
  @Output() onCopy = new EventEmitter<QuestionControl>();
  @Output() onDelete = new EventEmitter<any>();
  @Input() isActive: boolean;
  @Input('value') val: QuestionControl = new QuestionControl();
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
    this.val.selectedType = this.questionTypes[0];
  }

  ngAfterViewInit(): void {

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

    return (this.val.label)
      ? null
      : {
        jsonParseError: {
          valid: false,
        },
      };
  }

  registerOnValidatorChange?(fn: () => void): void {
    // this.onChange = fn;
  }

  copy() {
    this.onCopy.emit(this.val);
  }

  remove() {
    this.onDelete.emit();
  }

}
