import { Pipe, PipeTransform } from '@angular/core';
import { Router  } from '@angular/router';

@Pipe({
  name: 'searchPipe'
})
export class SearchPipe implements PipeTransform {
  constructor(private router: Router ) {
  }
  transform(items: any[], filterQuery: any){
 
}
}
