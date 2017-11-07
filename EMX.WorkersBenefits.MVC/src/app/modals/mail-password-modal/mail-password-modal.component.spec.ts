import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MailPasswordModalComponent } from './mail-password-modal.component';

describe('MailPasswordModalComponent', () => {
  let component: MailPasswordModalComponent;
  let fixture: ComponentFixture<MailPasswordModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MailPasswordModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MailPasswordModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
