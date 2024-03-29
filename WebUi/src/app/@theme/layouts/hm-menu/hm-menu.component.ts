import { Component, ChangeDetectionStrategy } from "@angular/core";
import { NbMenuItem } from "@nebular/theme";

@Component({
  selector: "nb-menu-custom",
  templateUrl: "./hm-menu.component.html",
  // changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./hm-menu.component.scss"],
})
export class HmMenuComponent {
  items: NbMenuItem[] = [
    {
      title: 'E-commerce',
      link: '/pages/dashboard',
      home: true,
    },
    {
      title: 'IoT Dashboard',
      link: '/pages/iot-dashboard',
    },
    {
      title: 'Layout',
      children: [
        {
          title: 'Stepper',
          link: '/pages/layout/stepper',
        },
        {
          title: 'List',
          link: '/pages/layout/list',
        },
        {
          title: 'Infinite List',
          link: '/pages/layout/infinite-list',
        },
        {
          title: 'Accordion',
          link: '/pages/layout/accordion',
        },
        {
          title: 'Tabs',
          pathMatch: 'prefix',
          link: '/pages/layout/tabs',
        },
      ],
    },
    {
      title: 'Forms',
      children: [
        {
          title: 'Form Inputs',
          link: '/pages/forms/inputs',
        },
        {
          title: 'Form Layouts',
          link: '/pages/forms/layouts',
        },
        {
          title: 'Buttons',
          link: '/pages/forms/buttons',
        },
        {
          title: 'Datepicker',
          link: '/pages/forms/datepicker',
        },
      ],
    },
    {
      title: 'UI Features',
      link: '/pages/ui-features',
      children: [
        {
          title: 'Grid',
          link: '/pages/ui-features/grid',
        },
        {
          title: 'Icons',
          link: '/pages/ui-features/icons',
        },
        {
          title: 'Typography',
          link: '/pages/ui-features/typography',
        },
        {
          title: 'Animated Searches',
          link: '/pages/ui-features/search-fields',
        },
      ],
    },
    {
      title: 'Modal & Overlays',
      children: [
        {
          title: 'Dialog',
          link: '/pages/modal-overlays/dialog',
        },
        {
          title: 'Window',
          link: '/pages/modal-overlays/window',
        },
        {
          title: 'Popover',
          link: '/pages/modal-overlays/popover',
        },
        {
          title: 'Toastr',
          link: '/pages/modal-overlays/toastr',
        },
        {
          title: 'Tooltip',
          link: '/pages/modal-overlays/tooltip',
        },
      ],
    },
    {
      title: 'Extra Components',
      children: [
        {
          title: 'Calendar',
          link: '/pages/extra-components/calendar',
        },
        {
          title: 'Progress Bar',
          link: '/pages/extra-components/progress-bar',
        },
        {
          title: 'Spinner',
          link: '/pages/extra-components/spinner',
        },
        {
          title: 'Alert',
          link: '/pages/extra-components/alert',
        },
        {
          title: 'Calendar Kit',
          link: '/pages/extra-components/calendar-kit',
        },
        {
          title: 'Chat',
          link: '/pages/extra-components/chat',
        },
      ],
    },
    {
      title: 'Maps',
      children: [
        {
          title: 'Google Maps',
          link: '/pages/maps/gmaps',
        },
        {
          title: 'Leaflet Maps',
          link: '/pages/maps/leaflet',
        },
        {
          title: 'Bubble Maps',
          link: '/pages/maps/bubble',
        },
        {
          title: 'Search Maps',
          link: '/pages/maps/searchmap',
        },
      ],
    },
    {
      title: 'Charts',
      children: [
        {
          title: 'Echarts',
          link: '/pages/charts/echarts',
        },
        {
          title: 'Charts.js',
          link: '/pages/charts/chartjs',
        },
        {
          title: 'D3',
          link: '/pages/charts/d3',
        },
      ],
    },
    {
      title: 'Editors',
      children: [
        {
          title: 'TinyMCE',
          link: '/pages/editors/tinymce',
        },
        {
          title: 'CKEditor',
          link: '/pages/editors/ckeditor',
        },
      ],
    },
    {
      title: 'Tables & Data',
      children: [
        {
          title: 'Smart Table',
          link: '/pages/tables/smart-table',
        },
        {
          title: 'Tree Grid',
          link: '/pages/tables/tree-grid',
        },
      ],
    },
    {
      title: 'Miscellaneous',
      children: [
        {
          title: '404',
          link: '/pages/miscellaneous/404',
        },
      ],
    },
    {
      title: 'Auth',
      children: [
        {
          title: 'Login',
          link: '/auth/login',
        },
        {
          title: 'Register',
          link: '/auth/register',
        },
        {
          title: 'Request Password',
          link: '/auth/request-password',
        },
        {
          title: 'Reset Password',
          link: '/auth/reset-password',
        },
      ],
    },
  ];
}
