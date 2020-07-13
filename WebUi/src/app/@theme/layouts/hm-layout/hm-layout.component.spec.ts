import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HmLayoutComponent } from './hm-layout.component';

describe('HmLayoutComponent', () => {
  let component: HmLayoutComponent;
  let fixture: ComponentFixture<HmLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HmLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HmLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
