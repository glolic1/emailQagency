import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Email';

  public items!: MenuItem[];
  public activeItem!: MenuItem;

  public ngOnInit() {
    this.items = [
      { label: 'Send email', icon: 'pi pi-fw pi-home', routerLink: 'add' },
      { label: 'History of emails', icon: 'pi pi-fw pi-calendar', routerLink: 'history' }
    ];

    this.activeItem = this.items[0];
  }
}
