import { Component } from '@angular/core';

import { MENU_ITEMS } from './pages-menu';
import { NbMediaBreakpointsService, NbMenuService, NbSidebarService, NbThemeService } from '@nebular/theme';
import { HeaderComponent } from "../@theme/components/header/header.component";
@Component({
  providers:[HeaderComponent],
  selector: 'ngx-pages',
  styleUrls: ['pages.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu autoCollapse="true" [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PagesComponent {


constructor(private sidebarService: NbSidebarService,
  private menuService: NbMenuService,
  private themeService: NbThemeService,
  private breakpointService: NbMediaBreakpointsService,private headercomponenet:HeaderComponent){}
  menu = MENU_ITEMS;
  ngOnInit(){
    this.callExapndMenu();
  }

  public callExapndMenu(){
this.headercomponenet.toggleSidebarVBM();
  }

  }

  
  
