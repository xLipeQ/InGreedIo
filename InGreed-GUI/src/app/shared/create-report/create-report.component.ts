import {Component, Inject, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';

@Component({
    selector: 'ingreedio-create-report',
    standalone: true,
    imports: [MatDialogModule, FormsModule, ReactiveFormsModule],
    templateUrl: './create-report.component.html',
    styleUrl: './create-report.component.scss'
  })
export class CreateReportComponent implements OnInit{

    createOpinionForm : FormGroup = this.fb.group({
        reason: '',
    });

    constructor(
        private fb : FormBuilder,
        private dialogRef : MatDialogRef<CreateReportComponent>,
        @Inject(MAT_DIALOG_DATA) public data: {name: string}) {
        
     }

    ngOnInit(): void {
    }

    close(){
        this.dialogRef.close({
            finished: false
        });
    }

    submit(){
        this.dialogRef.close({
            finished: true,
            reason: this.createOpinionForm.get('reason')?.value,
        });
        
    }

}