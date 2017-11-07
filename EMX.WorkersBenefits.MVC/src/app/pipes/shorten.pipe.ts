import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'shorten'
})
export class ShortenPipe implements PipeTransform {

  transform(value: any) {
    console.log(value.substr(0 , 10) + '...');
    return value.substr(0 , 20) + '...';
  }

}
