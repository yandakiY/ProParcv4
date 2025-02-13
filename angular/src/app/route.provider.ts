import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Dashboard',
        iconClass: 'fas fa-chart-simple',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/vehicules',
        name: 'Vehicules',
        iconClass: 'fas fa-car',
        layout: eLayoutType.application,
      },
      {
        path: '/maintenances',
        name: 'Maintenances',
        iconClass: 'fas fa-truck-monster',
        layout: eLayoutType.application,
      },
    ]);
  };
}
