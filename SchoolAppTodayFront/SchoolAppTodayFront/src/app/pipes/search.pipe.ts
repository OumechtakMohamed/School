import { Pipe, PipeTransform } from '@angular/core';
import { Router  } from '@angular/router';

@Pipe({
  name: 'searchPipe'
})
export class SearchPipe implements PipeTransform {
  constructor(private router: Router ) {
  }
  transform(items: any[], filterQuery: any): any[] {
    if (!filterQuery) return items;
    switch (this.router.url) 
    { 
    case'/classes': 
    return items.filter(item => item.Label.toLowerCase().includes(filterQuery.toLowerCase()) || item.Code.toLowerCase().includes(filterQuery.toLowerCase()));
    break; 
    case'/subjects': 
    return items.filter(item => item.Label.toLowerCase().includes(filterQuery.toLowerCase()) || item.Code.toLowerCase().includes(filterQuery.toLowerCase()));
    break; 
    case'/students': 
    return items.filter(item => item.FirstName.toLowerCase().includes(filterQuery.toLowerCase()) || item.LastName.toLowerCase().includes(filterQuery.toLowerCase()) || item.Email.toLowerCase().includes(filterQuery.toLowerCase()) || item.Label.toLowerCase().includes(filterQuery.toLowerCase()));
    break;
    case'/teachers': 
    return items.filter(item => item.FirstName.toLowerCase().includes(filterQuery.toLowerCase()) || item.LastName.toLowerCase().includes(filterQuery.toLowerCase()) || item.Email.toLowerCase().includes(filterQuery.toLowerCase()) || item.Label.toLowerCase().includes(filterQuery.toLowerCase()));
    break;
  }
}
}
