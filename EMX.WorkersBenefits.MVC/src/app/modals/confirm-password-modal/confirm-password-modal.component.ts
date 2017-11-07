import {AfterViewInit, Component, ElementRef, OnInit} from '@angular/core';
import {ModalService} from '../modal.service';

@Component({
  selector: 'app-confirm-password-modal',
  templateUrl: './confirm-password-modal.component.html',
  styleUrls: ['./confirm-password-modal.component.css']
})
export class ConfirmPasswordModalComponent implements OnInit, AfterViewInit {
  modal;

  constructor(
    private modalService: ModalService,
    private myElement: ElementRef) {}

  ngOnInit() {
    this.modalService.status.subscribe(
      (status: string) => {
        if (status === 'password') {
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

  signup() {
    this.modal.style.display = 'none';
    this.modalService.status.next('mailPassword');
  }
}
