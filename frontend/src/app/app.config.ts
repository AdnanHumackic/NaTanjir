import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {provideAnimations} from "@angular/platform-browser/animations";
import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {MyAuthInterceptor} from "./helper/my-auth-interceptor";

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideAnimations(),
    {provide: HTTP_INTERCEPTORS, useClass:MyAuthInterceptor, multi:true}]
};
