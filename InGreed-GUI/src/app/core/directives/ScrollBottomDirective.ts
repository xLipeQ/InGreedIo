import { Directive, Output, EventEmitter, HostListener } from '@angular/core';
import { Subject, debounceTime, last } from 'rxjs';

@Directive({
    selector: '[appScrollBottom]',
    standalone: true
  })
  export class ScrollBottomDirective {
    @Output() scrollingFinished = new EventEmitter<void>();
    emitted = false;
    lastScrollHeight = 0;

    @HostListener("window:scroll", [])
    onScroll(): void {
      const windowHeight = window.innerHeight;
      const scrollHeight = document.documentElement.scrollHeight;
      const scrollTop = window.scrollY || window.pageYOffset || document.body.scrollTop + (document.documentElement && document.documentElement.scrollTop || 0);
      const distanceToBottom = scrollHeight - (windowHeight + scrollTop);

      if (distanceToBottom <= 100 && this.emitted == false) {
        this.emitted = true;
        this.scrollingFinished.emit();
      } else if (scrollHeight > this.lastScrollHeight){
        this.emitted = false;
      }

      this.lastScrollHeight = scrollHeight
    }
  }