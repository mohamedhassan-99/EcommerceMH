import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { productItem } from '../models/product-list-item.model';
import { CreateProductModel } from '../models/product-create.model';
import { UpdateProductModel } from '../models/product-update.model';
import { product } from '../models/product.model';
import { productBrand } from '../models/product-brand.model';
import { productCategory } from '../models/product-category.model';
@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl: string = "https://localhost:7040/Product";
  constructor(private _http: HttpClient) {}

  
  createProduct(productInput: CreateProductModel): Observable<string> {
    return this._http.post<string>(`${this.baseUrl}/CreateProduct`, productInput);
  }

  getAllProducts(): Observable<productItem[]> {
    return this._http.get<productItem[]>(`${this.baseUrl}/GetAllProducts`);
  }

  getProductCategories(productId: string): Observable<productCategory[]> {
    return this._http.get<productCategory[]>(`${this.baseUrl}/GetProductCategories?productId=${productId}`);
  }

  getProduct(productId: string): Observable<product> {
    return this._http.get<product>(`${this.baseUrl}/GetProduct?productId=${productId}`);
  }

  getProductBrand(productId: string): Observable<productBrand> {
    return this._http.get<productBrand>(`${this.baseUrl}/GetProductBrand?productId=${productId}`);
  }

  updateProduct(updateProductModel: UpdateProductModel): Observable<string> {
    return this._http.put<string>(`${this.baseUrl}/UpdateProduct`, updateProductModel);
  }

  deleteProduct(productId: string): Observable<string> {
    return this._http.delete<string>(`${this.baseUrl}/DeleteProduct?productId=${productId}`);
  }
}