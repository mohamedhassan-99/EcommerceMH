import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProductService } from '../services/product.service.service';
import { CreateProductModel } from '../models/product-create.model';
import { UpdateProductModel } from '../models/product-update.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
  public isEdit: boolean;
  public productFormGroup!: FormGroup;
  public brands:{Id:string, Name:string}[] = [
  {Id: "55125622-b1f1-4a04-8e16-ce6d65fbe233", Name:"adfadfd"},
  {Id: "55125622-b1f1-4a04-8e16-ce6d65fbe233", Name:"adfadfd"},
  {Id: "55125622-b1f1-4a04-8e16-ce6d65fbe233", Name:"adfadfd"}];

  constructor(
    private _fb: FormBuilder,
    private _productService: ProductService,
    private _dialogRef: MatDialogRef<FormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { isEdit: boolean, id?: string }
    ) {
      this.isEdit = data.isEdit;
      this.prepareForm();
  }


  private prepareForm(): void {
    this.productFormGroup = this._fb.group({
      name: '',
      description: '',
      brandId: ''
    });

    if (this.isEdit) {
      this.productFormGroup.addControl('id', this._fb.control(this.data.id));
      this._productService.getProduct(this.data.id!).subscribe(product => {
        this.productFormGroup.patchValue(product);
      });
    }
  }

  
  public onFormSubmit(): void {
    const formData = this.productFormGroup.value;
    if (this.isEdit) {
      this.updateProduct(formData);
    } else {
      this.createProduct(formData);
    }
  }


  private createProduct(formData: any): void {
    const createdProduct = new CreateProductModel(formData.name, formData.description, formData.brandId);
    this._productService.createProduct(createdProduct).subscribe({
      next: () => {
        this._dialogRef.close(true);
        alert('Product created successfully.');
      },
      error: (err) => {
        alert('Something went wrong. Please check the logs.');
        console.log(err);
      }
    });
  }

  private updateProduct(formData: any): void {
    const updatedProduct = new UpdateProductModel(formData.id, formData.name, formData.description, formData.brandId);
    this._productService.updateProduct(updatedProduct).subscribe({
      next: () => {
        this._dialogRef.close(true);
        alert('Product updated successfully.');
      },
      error: (err) => {
        alert('Something went wrong. Please check the logs.');
        console.log(err);
      }
    });
  }
}
