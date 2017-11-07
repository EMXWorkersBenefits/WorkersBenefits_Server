import {AfterViewInit, Component, ElementRef, OnInit} from '@angular/core';
import {ModalService} from '../modal.service';

@Component({
  selector: 'app-popup-modal',
  templateUrl: './popup-modal.component.html',
  styleUrls: ['./popup-modal.component.css']
})
export class PopupModalComponent implements OnInit, AfterViewInit {
  modal;
  // Get the button that opens the modal
  btn = document.getElementById('myBtn');

// Get the <span> element that closes the modal
  span = document.getElementsByClassName('close')[0];
  constructor(
    private myElement: ElementRef,
    private modalService: ModalService ) {
  }

  ngOnInit() {
  }
  ngAfterViewInit() {
    this.modal = this.myElement.nativeElement.querySelector('div');
  }

  // When the user clicks on the button, open the modal
  onclickOpen() {
    this.modal.style.display = 'block';
}

// When the user clicks on <span> (x), close the modal
  onclickClose = function() {
  this.modal.style.display = 'none';
};

  signup() {
    this.modal.style.display = 'none';
    this.modalService.status.next('password');
  }

// When the user clicks anywhere outside of the modal, close it
  onclickOutside(event) {
  // if (event.target === this.modal) {
  //   // this.modal.style.display = 'none';
  // }
}
}
