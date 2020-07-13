import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutSwitcherComponent } from './layout-switcher.component';

describe('LayoutSwitcherComponent', () => {
  let component: LayoutSwitcherComponent;
  let fixture: ComponentFixture<LayoutSwitcherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutSwitcherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutSwitcherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
