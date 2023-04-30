export class UpdateProductModel {
  /**
   *
   */
  constructor(id: string, name: string, description: string, brandId: string) {
    this.Id = id;
    this.Name = name;
    this.Description = description;
    this.BrandId = brandId;
  }
  
  Id!: string;
  Name!: string | null;
  Description!: string | null;
  BrandId!: string | null;
}
