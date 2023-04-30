export class CreateProductModel {
    constructor(name : string, description: string,brandId: string,) {
        this.Name = name;
        this.Description = description;
        this.BrandId = brandId;
    }
    Name!: string | null;
    Description!: string | null;
    BrandId!: string | null;
}