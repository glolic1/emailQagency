import { Component } from '@angular/core';
import { RestService } from 'src/services/rest.service';

@Component({
  selector: 'app-history-overview',
  templateUrl: './history-overview.component.html',
  styleUrls: ['./history-overview.component.scss']
})
export class HistoryOverviewComponent {
  emails: any;
  
  constructor(public restService: RestService) {

  }
  
  public ngOnInit() {
    this.restService.getEmails().subscribe(val => {
      this.emails = val;
    });
  }
}
