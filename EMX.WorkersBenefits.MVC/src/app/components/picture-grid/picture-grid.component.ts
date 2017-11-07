import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-picture-grid',
  templateUrl: './picture-grid.component.html',
  styleUrls: ['./picture-grid.component.css']
})
export class PictureGridComponent implements OnInit {

  constructor(private  router: Router) { }

  ngOnInit() {
  }

  onByCategory(category: string) {
    this.router.navigate(['/benefits/' + category]);
  }

}
