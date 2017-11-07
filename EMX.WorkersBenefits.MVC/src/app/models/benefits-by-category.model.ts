export class BenefitsByCategory {
  public title: string;
  public image: string;
  public ourPrice: number;
  public normalPrice: number;
  public discount: number;
  public shortDesc: string;
  public endDate: string;
  public expires: string;
  constructor (
    title: string,
    image: string,
    ourPrice: number,
    normalPrice: number,
    discount: number,
    shortDesc: string,
    endDate: string,
    expires: string) {
    this.title = title;
    this.image = image;
    this.ourPrice = ourPrice;
    this.normalPrice = normalPrice;
    this.discount = discount;
    this.shortDesc = shortDesc;
    this.endDate = endDate;
    this.expires = expires;
  }


}
