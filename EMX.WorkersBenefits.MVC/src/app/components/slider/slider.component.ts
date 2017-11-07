import {AfterViewInit, Component, ContentChildren, OnInit, QueryList} from '@angular/core';
import {Description} from '../../models/description.model';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit, AfterViewInit {
  @ContentChildren('frame') children: QueryList<any[]>;
  index = 0;
  isPlaying = false;
  timeout;
  delay = 4000;
  frames = [
    { img: '/assets/img/food.jpg',
      description: new Description('ארוחה זוגית במסעדת ברנזה התל אביבית במתחם שרונה',
        'מסעדת ברנזה של המסעדן הראל בלו משיקה תפריט קיץ חדש ומציעה ארוחה זוגית בת 8 מנות',
        39)
    },
    { img: '/assets/img/gym.jpg',
      description: new Description('מנוי שנתי למגוון חדרי כושר ברחבי הארץ',
        'מנוי שנתי לחדרי הכושר המובילים בארץ בהנחות של עד כ- 40%',
        299),
    },
    { img: '/assets/img/montenegro.jpg',
      description: new Description('ספטמבר במונטנגרו',
        'חבילת נופש הכוללת טיסות הלוך וחזור ו-4 לילות במלון לבחירה ע"ב חצי פנסיון ',
        2999)
    },
  ];

  ngOnInit() {
    this.play();
  }
  ngAfterViewInit() {
  }

  selectFrame(index: number) {
    this.index = index;
  }
  play () {
    this.isPlaying = true;
    this.timeout = setTimeout(this.slide.bind(this), this.delay);
  }
  slide () {
    if (this.isPlaying) {
      this.forward();
      this.timeout = setTimeout(this.slide.bind(this), this.delay);
    }
  }
  forward () {
    this.index = ((this.index + 1) === this.frames.length) ? 0 : (this.index + 1);
  }
  backword () {
    console.log('length: ', this.frames.length);
    if (this.index === 0) {console.log('yes');
    }
    this.index = this.index === 0 ? (this.frames.length - 1) : this.index - 1;
  }
}








