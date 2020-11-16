import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { User } from '../_models/user';


@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<User>;
    public user: Observable<User>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): User {
        return this.userSubject.value;
    }

    login(username, password) {
        debugger;
        return this.http.post<User>(`${environment.apiUrl}/authenticate/signin`, { username, password })        
            .pipe(map(user => {
                debugger;

                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    register(id: number, params) {
        return this.http.post(`${environment.apiUrl}/user/register/${id}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
                if (id.toString() ==  this.userValue.UserId) {
                    // update local storage
                    const user = { ...this.userValue, ...params };
                    localStorage.setItem('user', JSON.stringify(user));

                    // publish updated user to subscribers
                    this.userSubject.next(user);
                }
                return x;
            }));
    }

    registerAnonymous(params) {
        return this.http.post(`${environment.apiUrl}/authenticate/registerAnonymous`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
                    const user = { ...this.userValue, ...params };
                    // publish updated user to subscribers
                    this.userSubject.next(user);               
                return x;
            }));
    }

    getAll() {
        return this.http.get<User[]>(`${environment.apiUrl}/user`);
    }

    getById(id: number) {
        return this.http.get<User>(`${environment.apiUrl}/user/${id}`);
    }

    update(id: number, params) {
        return this.http.put(`${environment.apiUrl}/user/${id}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
                if (id.toString() == this.userValue.UserId) {
                    // update local storage
                    const user = { ...this.userValue, ...params };
                    localStorage.setItem('user', JSON.stringify(user));

                    // publish updated user to subscribers
                    this.userSubject.next(user);
                }
                return x;
            }));
    }

    delete(id: string) {
        return this.http.delete(`${environment.apiUrl}/user/${id}`)
            .pipe(map(x => {
                // auto logout if the logged in user deleted their own record
                if (id == this.userValue.UserId) {
                    this.logout();
                }
                return x;
            }));
    }
}