import {Subject} from 'rxjs/Subject';
import {BenefitsByCategory} from '../../models/benefits-by-category.model';
export class BenefitsByCqategoryService {
  benefits: BenefitsByCategory[][] = [
    [
      new BenefitsByCategory(
        'ספטמבר במונטנגרו',
        '/assets/img/montenegro.jpg',
        2199,
        2899,
        this.calculateDiscount( 2199 , 2899),
        'מסלול בן 7/8 ימים ע"ב חצי פנסיון, כולל ' +
        'טיסות, מלון על קו החוף, מדריך וסיורים' +
        ' ',
        '05.01.18',
        'Jan 5, 2018 15:37:25'
      ),
      new BenefitsByCategory(
        'בטן-גב ביוון',
        '/assets/img/vacations/greece.jpg',
        1299,
        1799,
        this.calculateDiscount( 1299 , 1799),
        'חבילת נופש הכוללת טיסות, העברות ו-3/4 ' +
        'לילות במלון ע"ב חצי פנסיון' +
        ' ',
        '12.12.17',
        'Dec 12, 2017 12:37:25'
      ),
      new BenefitsByCategory(
        'חופשה חלומית בונציה',
        '/assets/img/vacations/venice.jpg',
        3399,
        4899,
        this.calculateDiscount( 3399 , 4899),
        'חבילה הכוללת טיסות אל על ו-3/5 לילות ' +
        'במלון לבחירה ע"ב ארוחת בוקר' +
        ' ',
        '05.01.18',
        'Jan 5, 2018 15:37:25'
      ),
    ],
    [
      new BenefitsByCategory(
        'בואו לגלות את זנזיבר',
        '/assets/img/vacations/zanzibar.jpg',
        3209,
        3899,
        this.calculateDiscount( 3209 , 3899),
        'חבילת נופש הכוללת טיסות ישירות, העברות' +
        'ו-5/7 לילות במלון מומלץ ע"ב חצי פנסיון',
        '05.01.18',
        'Jan 5, 2018 15:37:25'
      ),
      new BenefitsByCategory(
        'סופ"ש בפראג הקסומה',
        '/assets/img/vacations/prague.jpg',
        1199,
        1499,
        this.calculateDiscount( 1199 , 1499),
        'לבחירה ממגוון מלונות 3-5 כוכבים במרכז העיר ' +
        'ע"ב חצי פנסיון, כולל טיסות בתאריכים משתנים',
        '17.01.18',
        'Jan 17, 2018 10:37:25'
      ),
      new BenefitsByCategory(
        'חופשת סקי בבנסקו',
        '/assets/img/vacations/ski.jpg',
        2868,
        3199,
        this.calculateDiscount( 2868 , 3199),
        'חבילת נופש הכוללת טיסות, העברות, סקי פס' +
        'מלון על קו החוף, מדריך וסיורים, החל מ-3,146 ₪ לאדם!',
        '12.10.17',
        'Jan 5, 2018 15:37:25'
      ),
    ],
    [
      new BenefitsByCategory(
        'טיול למרוקו הצבעונית',
        '/assets/img/vacations/morocco.jpg',
        4325,
        4459,
        this.calculateDiscount( 4325 , 4459),
        'מסלול בן 8 ימים כולל טיסות' +
        ' מלונות, ארוחות, מדריך וסיורים' +
        ' ',
        '12.10.17',
        'Jan 5, 2018 15:37:25'
      ),
      new BenefitsByCategory(
        'טיול מאורגן ללונדון ',
        '/assets/img/vacations/london.jpg',
        4733,
        4999,
        this.calculateDiscount( 4733 , 4999),
        'מסלול בן 7/8 ימים ע"ב חצי פנסיון,  ' +
        'כולל טיסות, מלונות, ארוחות, מדריך וסיורים' +
        ' ',
        '12.10.17',
        'Jan 5, 2018 15:37:25'
      ),
      new BenefitsByCategory(
        'טיול מאורגן ללונדון ',
        '/assets/img/vacations/london.jpg',
        4733,
        4999,
        this.calculateDiscount( 4733 , 4999),
        'מסלול בן 7/8 ימים ע"ב חצי פנסיון,  ' +
        'כולל טיסות, מלונות, ארוחות, מדריך וסיורים' +
        ' ',
        '12.10.17',
        'Jan 5, 2018 15:37:25'
      ),
    ]

  ];
  expireSubject = new Subject();
  getBenefits() {
    return this.benefits.slice();
  }
  calculateDiscount(ourPrice: number, normalPrice: number) {
    return ( Math.round((ourPrice / normalPrice) * 100));
  }

}
