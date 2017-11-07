import {AfterViewInit, Component, ElementRef, OnInit} from '@angular/core';
import {ModalService} from '../modal.service';


@Component({
  selector: 'app-success-modal',
  templateUrl: './success-modal.component.html',
  styleUrls: ['./success-modal.component.css']
})
export class SuccessModalComponent implements OnInit, AfterViewInit {
  modal;

  constructor(
    private modalService: ModalService,
    private myElement: ElementRef) {}

  ngOnInit() {
    this.modalService.status.subscribe(
      (status: string) => {
        if (status === 'success') {
          this.onclickOpen();
        }
      });
  }

  ngAfterViewInit() {
    this.modal = this.myElement.nativeElement.querySelector('div');
  }

  // When the user clicks on the button, open the modal
  onclickOpen() {
    this.modal.style.display = 'block';
  }

  // When the user clicks on <span> (x), close the modal
  onclickClose() {
    this.modal.style.display = 'none';
  };
}
