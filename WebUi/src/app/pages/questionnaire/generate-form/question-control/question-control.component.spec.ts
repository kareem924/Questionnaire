/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { QuestionControlComponent } from './question-control.component';

describe('QuestionControlComponent', () => {
    let component: QuestionControlComponent;
    let fixture: ComponentFixture<QuestionControlComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [QuestionControlComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(QuestionControlComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});