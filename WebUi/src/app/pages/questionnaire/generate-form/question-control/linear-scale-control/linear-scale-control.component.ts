import { RatingValue } from './../../../models/question-control.model';
import { Component, OnInit, forwardRef, Input } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { QuestionType } from '../../../models/question-type.enum';

@Component({
    selector: 'ngx-linear-scale-control',
    templateUrl: './linear-scale-control.component.html',
    styleUrls: ['./linear-scale-control.component.scss'],
    providers: [{
        provide: NG_VALUE_ACCESSOR,
        useExisting: forwardRef(() => LinearScaleControlComponent),
        multi: true
    }]
})

export class LinearScaleControlComponent implements ControlValueAccessor, OnInit {

    rateValue: RatingValue = { from: 0, to: 2, fromLabel: '', toLabel: '' };
    @Input() type: QuestionType;

    constructor() { }

    writeValue(value: RatingValue): void {
        if (value !== undefined) {
            this.rateValue = value;
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
    }

}
