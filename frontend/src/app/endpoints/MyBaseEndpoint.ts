import {Observable} from "rxjs";

export interface MyBaseEndpoint<TRequest, TResponse>{
  akcija(request: TRequest): Observable<TResponse>;
}
