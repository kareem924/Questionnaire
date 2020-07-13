import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router} from '@angular/router';

//
import { NbLayoutDirectionService, NbLayoutDirection } from "@nebular/theme";
import { NbThemeService } from "@nebular/theme";
@Component({
  selector: "ngx-layout-switcher",
  templateUrl: "./layout-switcher.component.html",
  styleUrls: ["./layout-switcher.component.scss"],
})
export class LayoutSwitcherComponent implements OnInit {

  constructor(
    private router: Router,
    private themeService: NbThemeService,
    private directionService: NbLayoutDirectionService
  ) {}

  ngOnInit(): void {
  }
  enable(theme: string) {
    this.themeService.changeTheme(theme);
    this.router.navigate(['pages']);
  }
  hmtheme(){
    this.themeService.changeTheme('HM');
    this.router.navigate(['hm-layout/dashboard']);
  }
  // Run Rtl function
  get isRtl() {
    return this.directionService.isRtl();
  }
  toggleFlow() {
    const oppositeDirection = this.isRtl
      ? NbLayoutDirection.LTR
      : NbLayoutDirection.RTL;
    this.directionService.setDirection(oppositeDirection);
  }
 

}
