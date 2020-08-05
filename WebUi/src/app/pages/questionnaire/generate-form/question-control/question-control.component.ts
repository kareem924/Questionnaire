import { QuestionControl } from './../../models/question-control.model';
import { Component, OnInit, HostListener, forwardRef, Output, EventEmitter, Input } from '@angular/core';
import { questionTypes } from '../../models/question-type.enum';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';


@Component({
  selector: 'ngx-question-control',
  templateUrl: './question-control.component.html',
  styleUrls: ['./question-control.component.css'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => QuestionControlComponent),
    multi: true
  }]
})

export class QuestionControlComponent implements ControlValueAccessor, OnInit {

  questionTypes = questionTypes;
  question: QuestionControl = new QuestionControl();
  @Output() onCopy = new EventEmitter<QuestionControl>();
  @Output() onDelete = new EventEmitter<any>();
  @Input() isActive: boolean;

  constructor() { }

  writeValue(value: QuestionControl): void {
    if (value !== undefined) {
      this.question = value;
    }
  }

  propagateChange = (_: any) => { };

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() { }

  setDisabledState?(isDisabled: boolean): void {
  }



  ngOnInit() {
    this.question.selectedType = this.questionTypes[0];
  }

  typeChanged() {
    this.isFocusInsideComponent = true;
    this.isComponentClicked = true;

  }
  isFocusInsideComponent = false;
  isComponentClicked = false;

  @HostListener('click')
  clickInside() {
    this.isFocusInsideComponent = true;
    this.isComponentClicked = true;
  }

  @HostListener('document:click')
  clickout() {
    if (!this.isFocusInsideComponent && this.isComponentClicked) {
      // do the heavy process

      this.isComponentClicked = false;
    }
    this.isFocusInsideComponent = false;
  }

  copy() {
    this.onCopy.emit(this.question);
  }

  remove() {
    this.onDelete.emit();
  }
}
