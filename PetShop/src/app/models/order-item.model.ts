export class OrderItem {
  OrderId: number;
  ProductId: number;
  Price: number;
  Count: number;
  TotalAmount: number;

  constructor() {
    this.OrderId = 0;
    this.ProductId = 0;
    this.Price = 0;
    this.Count = 0;
    this.TotalAmount = 0;
  }
}
