import { Component, OnDestroy, OnInit } from '@angular/core';
import { NbMediaBreakpointsService, NbMenuService, NbSidebarService, NbThemeService } from '@nebular/theme';
import { UserData } from '../../../@core/data/users';
import { LayoutService } from '../../../@core/utils';
import { map, takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

import { NbLayoutDirectionService, NbLayoutDirection } from '@nebular/theme';

@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, OnDestroy {
  
  innerWidth: any;
  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  user: any;

  // themes = [
  //   {
  //     value: 'default',
  //     name: 'Light',
  //   },
  //   {
  //     value: 'dark',
  //     name: 'Dark',
  //   },
  //   {
  //     value: 'cosmic',
  //     name: 'Cosmic',
  //   },
  //   {
  //     value: 'corporate',
  //     name: 'Corporate',
  //   },
  // ];

  // currentTheme = 'default';

  userMenu = [ { title: 'Profile' }, { title: 'Log out' } ];

  constructor(private sidebarService: NbSidebarService,
              private menuService: NbMenuService,
              private themeService: NbThemeService,
              private userService: UserData,
              private layoutService: LayoutService,
              private breakpointService: NbMediaBreakpointsService,
              private directionService: NbLayoutDirectionService ) {
                this.innerWidth = (window.screen.width);
  }
  // get isRtl() {
  //   return this.directionService.isRtl();
  // }

  // toggleFlow() {
  //   const oppositeDirection = this.isRtl
  //     ? NbLayoutDirection.LTR
  //     : NbLayoutDirection.RTL;
  //   this.dzirectionService.setDirection(oppositeDirection);
  // }
  ngOnInit() {

    // this.currentTheme = this.themeService.currentTheme;
    this.toggleSidebarVBM();
    this.userService.getUsers()
      .pipe(takeUntil(this.destroy$))
      .subscribe((users: any) => this.user = users.nick);

    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService.onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$),
      )
      .subscribe((isLessThanXl: boolean) => this.userPictureOnly = isLessThanXl);

    // this.themeService.onThemeChange()
    //   .pipe(
    //     map(({ name }) => name),
    //     takeUntil(this.destroy$),
    //   )
    //   .subscribe(themeName => this.currentTheme = themeName);
   

  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  // changeTheme(themeName: string) {
  //   this.themeService.changeTheme(themeName);
  // }


  toggleSidebar(): boolean {
    // this.vbmLogo = !this.vbmLogo;
    this.sidebarService.toggle(true, 'menu-sidebar');
    this.layoutService.changeLayoutSize();

    return false;
  }
  vbmLogo: boolean = true; //is closed
  toggleSidebarVBM(): boolean { 
    this.layoutService.changeLayoutSize();
    if(innerWidth > 1200 ){
      //collapse and expand is working if bigger than 1200px
      this.vbmLogo = !this.vbmLogo;
      this.sidebarService.toggle(true, 'menu-sidebar');
    }else{
      //expand is not working if less than 1200px for responsive..
      this.vbmLogo = true;
      this.sidebarService.collapse();
    }
    return false;
  }
  //VBM function

  // public toggleSidebarVBM() {
  //   this.vbmLogo = false; 
    
   


    // this.vbmLogo = !this.vbmLogo;
    // this.sidebarService.toggle(true, 'menu-sidebar');
    // this.sidebarService.expand('menu-sidebar');
    // this.layoutService.changeLayoutSize();

//  if(this.innerWidth > 768){ 
//   this.vbmLogo = false; 
//   this.sidebarService.expand('menu-sidebar');
//  }else{
//   this.vbmLogo = false;
//   this.sidebarService.compact('menu-sidebar');
//  }  
 
  // }

  navigateHome() {
    this.menuService.navigateHome();
    return false;
  }
}
