import {Injectable} from "@angular/core";
import {MyAuthService} from "../services/MyAuthService";
import {HttpHandler, HttpRequest} from "@angular/common/http";


@Injectable()

export class MyAuthInterceptor{

  constructor(private auth: MyAuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the auth token from the service.
    const authToken = this.auth.getAuthorizationToken()?.vrijednost??"";

    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({
      headers: req.headers.set('my-auth-token', authToken)
    });

    // send cloned request with header to the next handler.
    return next.handle(authReq);
  }
}
