import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Contants } from '../utils/contants';

@Pipe({
  name: 'DateTimeFormat',
  standalone: true,
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {
  override transform(value: any, args?: any): any {
    return super.transform(value, Contants.DATE_TIME_FMT);
  }
}
