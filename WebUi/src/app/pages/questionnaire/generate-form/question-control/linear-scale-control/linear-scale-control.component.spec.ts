/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LinearScaleControlComponent } from './linear-scale-control.component';

describe('LinearScaleControlComponent', () => {
  let component: LinearScaleControlComponent;
  let fixture: ComponentFixture<LinearScaleControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinearScaleControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinearScaleControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
