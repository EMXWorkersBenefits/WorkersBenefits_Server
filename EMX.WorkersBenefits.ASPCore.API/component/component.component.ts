import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-component',
    templateUrl: './component.component.html',
    styleUrls: ['./component.component.scss']
})
/** component component*/
export class ComponentComponent implements OnInit
{
    /** component ctor */
    constructor() { }

    /** Called by Angular after component component initialized */
    ngOnInit(): void { }
}