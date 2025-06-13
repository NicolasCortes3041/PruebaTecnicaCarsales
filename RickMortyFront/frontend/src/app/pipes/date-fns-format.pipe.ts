import { Pipe, PipeTransform } from '@angular/core';
import { format, parse } from 'date-fns';

@Pipe({
  name: 'dateFnsFormat',
  standalone: true
})
export class DateFnsFormatPipe implements PipeTransform {

  transform(value: string, outputFormat: string = 'dd/MM/yyyy'): string {
    if(!value) return '';

    try {
      const parsed = parse(value, 'MMMM d, yyyy', new Date());
      return format(parsed, outputFormat);
    } catch (error) {
      return value;
    }
  }

}
