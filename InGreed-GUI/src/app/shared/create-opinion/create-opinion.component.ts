import {Component, Inject, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';

@Component({
    selector: 'ingreedio-create-component',
    standalone: true,
    imports: [MatDialogModule, FormsModule, ReactiveFormsModule],
    templateUrl: './create-opinion.component.html',
    styleUrl: './create-opinion.component.scss'
  })
export class CreateOpinionComponent implements OnInit{

    createOpinionForm : FormGroup = this.fb.group({
        content: '',
        rating: '1'
    });

    constructor(
        private fb : FormBuilder,
        private dialogRef : MatDialogRef<CreateOpinionComponent>,
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
            content: this.createOpinionForm.get('content')?.value,
            rating: Number(this.createOpinionForm.get('rating')?.value)
        });
        
    }

}