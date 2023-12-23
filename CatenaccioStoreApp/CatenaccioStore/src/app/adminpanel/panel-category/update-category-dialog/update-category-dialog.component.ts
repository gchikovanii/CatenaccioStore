import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-update-category-dialog',
  templateUrl: './update-category-dialog.component.html',
  styleUrl: './update-category-dialog.component.css'
})
export class UpdateCategoryDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<UpdateCategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { categoryName: string, newCategoryName: string }
  ) {}

  updateCategory() {
    this.dialogRef.close({ categoryName: this.data.categoryName, newCategoryName: this.data.newCategoryName });
  }
}
