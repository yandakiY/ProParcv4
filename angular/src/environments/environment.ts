 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44371/',
  redirectUri: baseUrl,
  clientId: 'ProParcv4_App',
  responseType: 'code',
  scope: 'offline_access ProParcv4',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ProParcv4',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44371',
      rootNamespace: 'ProParcv4',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
