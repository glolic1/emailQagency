import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Importance } from 'src/models/Importance';
import { RestService } from 'src/services/rest.service';

@Component({
  selector: 'app-email-add',
  templateUrl: './email-add.component.html',
  styleUrls: ['./email-add.component.scss']
})
export class EmailAddComponent {
  public fg!: FormGroup;
  public emailFrom = new FormControl('');
  public emailTo = new FormControl('');
  public emailCC = new FormControl('');
  public emailSubject = new FormControl('');
  public importanceId = new FormControl('');
  public emailContent = new FormControl('');

  public importanceLevels!: any;

  constructor(public restService: RestService, 
    private confirmationService: ConfirmationService, 
    private messageService: MessageService) { }

  public ngOnInit() {
    this.fg = new FormGroup ({
      emailFrom: this.emailFrom,
      emailTo: this.emailTo,
      emailCC: this.emailCC,
      emailSubject: this.emailSubject,
      importanceId: this.importanceId,
      emailContent: this.emailContent
    });

    this.restService.getImportanceLevels().subscribe(val => {
      this.importanceLevels = val;
    });
  }

  public addEmail(): void {
    this.restService.addEmail(this.fg.value).subscribe(val => {
      this.messageService.add({severity:'success', summary: 'Success', detail: 'Successfully added email!'});
    });
  }

  public cancel(event: any): void {
    this.confirmationService.confirm({
      target: event.target,
      message: "Are you sure that you want to cancel?",
      icon: "pi pi-exclamation-triangle",
      accept: () => {
        //Code if 'Yes' is pressed
      },
      reject: () => {
        //Code if 'No' is pressed
      }
    });
  }
}
