import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditcardComponent } from './editcard.component';

describe('EditcardComponent', () => {
  let component: EditcardComponent;
  let fixture: ComponentFixture<EditcardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditcardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
