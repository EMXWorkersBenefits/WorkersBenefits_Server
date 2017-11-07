import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BenefitsByCategoryComponent } from './benefits-by-category.component';

describe('BenefitsByCategoryComponent', () => {
  let component: BenefitsByCategoryComponent;
  let fixture: ComponentFixture<BenefitsByCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BenefitsByCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitsByCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
