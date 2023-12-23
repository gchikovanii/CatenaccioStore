import { Component } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { AddCategoryDialogComponent } from './add-category-dialog/add-category-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { UpdateCategoryDialogComponent } from './update-category-dialog/update-category-dialog.component';

@Component({
  selector: 'app-panel-category',
  templateUrl: './panel-category.component.html',
  styleUrl: './panel-category.component.css'
})
export class PanelCategoryComponent {
  categories: any[] = [];
  newCategoryName: string = ''; 

  constructor(private categoryService: CategoryService, private dialog: MatDialog) {}  // Inject MatDialog

  ngOnInit() {
    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }
  openAddCategoryDialog() {
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '400px',
      data: { categoryName: '' }, 
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.addCategory(result.categoryName);
      }
    });
  }

  addCategory(categoryName: string) {
    this.categoryService.addCategory({ name: categoryName }).subscribe(() => {
      this.loadCategories();
      this.newCategoryName = '';
    });
  }

  openUpdateCategoryDialog(category: any) {
    const dialogRef = this.dialog.open(UpdateCategoryDialogComponent, {
      width: '400px',
      data: { categoryId: category.id, categoryName: category.name, newCategoryName: this.newCategoryName },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.updateCategory(result.categoryName, result.newCategoryName);
      }
    });
  }

  updateCategory(categoryName: string, newCategoryName: string) {
    this.categoryService.updateCategory(categoryName, newCategoryName).subscribe(() => {
      this.loadCategories();
    });
  }


  deleteCategory(categoryName: string) {
    this.categoryService.deleteCategory(categoryName).subscribe(() => {
      this.loadCategories();
    });
  }

  private loadCategories() {
    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }
}