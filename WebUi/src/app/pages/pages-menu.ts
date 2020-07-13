import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'E-commerce',
    icon: 'shopping-cart-outline',
    link: '/pages/dashboard',
    home: true,
  },
  {
    title: 'IoT Dashboard',
    icon: 'home-outline',
    link: '/pages/iot-dashboard',
  },
  // {
  //   title: 'FEATURES',
  //   group: true,
  // },
  {
    title: 'Layout',
    icon: 'layout-outline',
    children: [
      {
        title: 'Stepper',
        icon: 'layout-outline',
        link: '/pages/layout/stepper',
      },
      {
        title: 'List',
        icon: 'layout-outline',
        link: '/pages/layout/list',
      },
      {
        title: 'Infinite List',
        icon: 'layout-outline',
        link: '/pages/layout/infinite-list',
      },
      {
        title: 'Accordion',
        icon: 'layout-outline',
        link: '/pages/layout/accordion',
      },
      {
        title: 'Tabs',
        pathMatch: 'prefix',
        icon: 'layout-outline',
        link: '/pages/layout/tabs',
      },
    ],
  },
  {
    title: 'Forms',
    icon: 'edit-2-outline',
    children: [
      {
        title: 'Form Inputs',
        icon: 'edit-2-outline',
        link: '/pages/forms/inputs',
      },
      {
        title: 'Form Layouts',
        icon: 'edit-2-outline',
        link: '/pages/forms/layouts',
      },
      {
        title: 'Buttons',
        icon: 'edit-2-outline',
        link: '/pages/forms/buttons',
      },
      {
        title: 'Datepicker',
        icon: 'edit-2-outline',
        link: '/pages/forms/datepicker',
      },
    ],
  },
  {
    title: 'UI',
    icon: 'keypad-outline',
    link: '/pages/ui-features',
    children: [
      {
        title: 'Grid',
        icon: 'keypad-outline',
        link: '/pages/ui-features/grid',
      },
      {
        title: 'Icons',
        icon: 'keypad-outline',
        link: '/pages/ui-features/icons',
      },
      {
        title: 'Typography',
        icon: 'keypad-outline',
        link: '/pages/ui-features/typography',
      },
      {
        title: 'Animated Searches',
        icon: 'keypad-outline',
        link: '/pages/ui-features/search-fields',
      },
    ],
  },
  {
    title: 'Modals',
    icon: 'browser-outline',
    children: [
      {
        title: 'Dialog',
        icon: 'browser-outline',
        link: '/pages/modal-overlays/dialog',
      },
      {
        title: 'Window',
        icon: 'browser-outline',
        link: '/pages/modal-overlays/window',
      },
      {
        title: 'Popover',
        icon: 'browser-outline',
        link: '/pages/modal-overlays/popover',
      },
      {
        title: 'Toastr',
        icon: 'browser-outline',
        link: '/pages/modal-overlays/toastr',
      },
      {
        title: 'Tooltip',
        icon: 'browser-outline',
        link: '/pages/modal-overlays/tooltip',
      },
    ],
  },
  {
    title: 'Extra',
    icon: 'message-circle-outline',
    children: [
      {
        title: 'Calendar',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/calendar',
      },
      // {
      //   title: 'IslamicCalendar',
      //   icon: 'message-circle-outline',
      //   link: '@theme/layouts/datepicker-islamiccivil',
      // },
      {
        title: 'Progress Bar',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/progress-bar',
      },
      {
        title: 'Spinner',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/spinner',
      },
      {
        title: 'Alert',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/alert',
      },
      {
        title: 'Calendar Kit',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/calendar-kit',
      },
      {
        title: 'Chat',
        icon: 'message-circle-outline',
        link: '/pages/extra-components/chat',
      },
    ],
  },
  {
    title: 'Maps',
    icon: 'map-outline',
    children: [
      {
        title: 'Google Maps',
        icon: 'map-outline',
        link: '/pages/maps/gmaps',
      },
      {
        title: 'Leaflet Maps',
        icon: 'map-outline',
        link: '/pages/maps/leaflet',
      },
      {
        title: 'Bubble Maps',
        icon: 'map-outline',
        link: '/pages/maps/bubble',
      },
      {
        title: 'Search Maps',
        icon: 'map-outline',
        link: '/pages/maps/searchmap',
      },
    ],
  },
  {
    title: 'Charts',
    icon: 'pie-chart-outline',
    children: [
      {
        title: 'Echarts',
        icon: 'pie-chart-outline',
        link: '/pages/charts/echarts',
      },
      {
        title: 'Charts.js',
        icon: 'pie-chart-outline',
        link: '/pages/charts/chartjs',
      },
      {
        title: 'D3',
        icon: 'pie-chart-outline',
        link: '/pages/charts/d3',
      },
    ],
  },
  {
    title: 'Editors',
    icon: 'text-outline',
    children: [
      {
        title: 'TinyMCE',
        icon: 'text-outline',
        link: '/pages/editors/tinymce',
      },
      {
        title: 'CKEditor',
        icon: 'text-outline',
        link: '/pages/editors/ckeditor',
      },
    ],
  },
  {
    title: 'Tables',
    icon: 'grid-outline',
    children: [
      {
        title: 'Smart Table',
        icon: 'grid-outline',
        link: '/pages/tables/smart-table',
      },
      {
        title: 'Tree Grid',
        icon: 'grid-outline',
        link: '/pages/tables/tree-grid',
      },
    ],
  },
  {
    title: 'Misc',
    icon: 'shuffle-2-outline',
    children: [
      {
        title: '404',
        icon: 'shuffle-2-outline',
        link: '/pages/miscellaneous/404',
      },
    ],
  },
  {
    title: 'Auth',
    icon: 'lock-outline',
    children: [
      {
        title: 'Login',
        icon: 'lock-outline',
        link: '/auth/login',
      },
      {
        title: 'Register',
        icon: 'lock-outline',
        link: '/auth/register',
      },
      {
        title: 'Request Password',
        icon: 'lock-outline',
        link: '/auth/request-password',
      },
      {
        title: 'Reset Password',
        icon: 'lock-outline',
        link: '/auth/reset-password',
      },
    ],
  },
];
