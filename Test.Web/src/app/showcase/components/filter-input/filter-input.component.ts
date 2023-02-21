import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-filter-input',
  templateUrl: './filter-input.component.html',
  styleUrls: ['./filter-input.component.scss']
})
export class FilterInputComponent {
  @Input() title = "";
  
  @Output() valueToSend = new EventEmitter<string>()

  timerId: number = 0;

  handleInput(e: Event) {
    const input = e.target! as  HTMLInputElement;
    console.log(input.value)
    
    if(this.timerId !== 0)
    {
      clearTimeout(this.timerId);
    }

    this.timerId = setTimeout(()=>{
     this.valueToSend.emit(input.value)
    }, 1000) as unknown as number;
  }
}
