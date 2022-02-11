export class Product {
  Id: number;
  Code: string;
  Name: string;
  Description: string;
  Price: number;
  Image: string;

  constructor() {
    this.Id = 0;
    this.Code = '';
    this.Name = '';
    this.Description = '';
    this.Price = 0;
    this.Image = '';
  }
}
