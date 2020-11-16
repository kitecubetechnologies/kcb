import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService } from '../_services/account.service';
import { AlertService } from '../_services/alert.service';


@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form: FormGroup;
    id: number;
    isAddMode: boolean;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        
        // password not required in edit mode
        const passwordValidators = [Validators.minLength(6)];
        if (this.isAddMode) {
            passwordValidators.push(Validators.required);
        }

        this.form = this.formBuilder.group({
            FirstName: ['', Validators.required],
            MiddleName: ['', ''],
            LastName: ['', Validators.required],
            UserName: ['', Validators.required],
            EmailAddress: ['', Validators.required],
            PhoneNo: ['', ''],
            Password: ['', passwordValidators],
            IsActive: true,
        });

        if (!this.isAddMode) {
            this.accountService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.f.FirstName.setValue(x.FirstName);
                    this.f.MiddleName.setValue(x.MiddleName);
                    this.f.LastName.setValue(x.LastName);
                    this.f.UserName.setValue(x.UserName);
                    this.f.EmailAddress.setValue(x.EmailAddress);
                    this.f.PhoneNo.setValue(x.PhoneNo);
                    this.f.IsActive.setValue(x.IsActive);
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;

        let  messageValue = 'User added successfully';
        if (!this.isAddMode) 
            messageValue = 'Update successful';

        this.registerUser(messageValue);

        // if (this.isAddMode) {
        //     this.createUser();
        // } else {
        //     this.updateUser();
        // }
    }

    private registerUser(msg: string ){
      
        this.accountService.register(this.id, this.form.value)
            .pipe(first())
            .subscribe(
                data => {

                    this.alertService.success(msg, { keepAfterRouteChange: true });
                    this.router.navigate(['..', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }    

    private updateUser() {
        this.accountService.update(this.id, this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update successful', { keepAfterRouteChange: true });
                    this.router.navigate(['..', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}