import { Component, OnInit } from '@angular/core';
import {BenefitsByCategory} from '../../models/benefits-by-category.model';
import {BenefitsByCqategoryService} from './benefits-by-category.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-benefits-by-category',
  templateUrl: './benefits-by-category.component.html',
  styleUrls: ['./benefits-by-category.component.css']
})
export class BenefitsByCategoryComponent implements OnInit {
  category: string;
  benefits: BenefitsByCategory[][];
  sortByPriceVal: number;

  constructor(private benefitsService: BenefitsByCqategoryService, private route: ActivatedRoute) { }

  ngOnInit() {
      this.category = (this.route.snapshot.params['category']).toString();
      this.benefits = this.benefitsService.getBenefits();
      this.startTimer();
      // this.subscribeToTimer();
      this.benefitsService.expireSubject.subscribe(
      (now: number) => {
          for (let i = 0 ; i < this.benefits.length; i++ ) {
            for ( let j = 0 ; j < this.benefits[i].length; j ++ ) {
              const expiresDate = new Date(this.benefits[i][j].endDate).getTime();
              const distance = expiresDate - now;
              // If the count down is finished, write some text
              if (distance < 0) {
                // clearInterval(x);
                this.benefits[i][j].expires = 'EXPIRED';
              }

              // Time calculations for days, hours, minutes and seconds
              const days = Math.floor(distance / (1000 * 60 * 60 * 24));
              const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
              const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
              this.benefits[i][j].expires = days + ' ימים ' + hours + ' שעות ו ' + minutes + ' דקות ';
            }
          }
      }
    );
  }

  startTimer() {
    const x = setInterval(() => {
      const now = new Date().getTime();
      this.benefitsService.expireSubject.next(now);
    }, 6000);
  };

  outputUpdate(vol) {
    console.log(vol);
    // this.sortByPriceVal = (<HTMLInputElement>document.getElementById('volume')).value = vol;
  };

}
