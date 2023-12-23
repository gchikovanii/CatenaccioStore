import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PanelCategoryComponent } from '../panel-category.component';

@Component({
  selector: 'app-add-category-dialog',
  templateUrl: './add-category-dialog.component.html',
  styleUrl: './add-category-dialog.component.css'
})
export class AddCategoryDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<PanelCategoryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { categoryName: string }
  ) {}

  addCategory() {
    // You can perform additional validation or checks here before closing the dialog
    this.dialogRef.close({ categoryName: this.data.categoryName });
  }
}