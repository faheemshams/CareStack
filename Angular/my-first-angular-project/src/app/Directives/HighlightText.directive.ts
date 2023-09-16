import { Directive, ElementRef, OnInit } from "@angular/core"; 

@Directive({
    selector : 'appHighlightText',
})

export class HighlightTextDirective implements OnInit
{
    constructor(private element  : ElementRef)
    {

    }

    ngOnInit()
    {
        (<HTMLElement>this.element.nativeElement).style.backgroundColor = 'red';
    }
}