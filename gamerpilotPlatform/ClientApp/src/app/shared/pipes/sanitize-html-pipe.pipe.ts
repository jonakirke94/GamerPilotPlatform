import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

 // https://stackoverflow.com/questions/39681163/angular-2-sanitizing-html-stripped-some-content-with-div-id-this-is-bug-or-fe
@Pipe({
  name: 'sanitizeHtmlPipe'
})
export class SanitizeHtmlPipePipe implements PipeTransform {

  constructor(private _sanitizer: DomSanitizer) {
  }

  transform(v: string): SafeHtml {
    return this._sanitizer.bypassSecurityTrustHtml(v);
  }

}
