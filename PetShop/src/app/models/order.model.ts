import { OrderItem } from './order-item.model';

export class Order {
  Id: number;
  UserId: number;
  Date: Date;
  TotalAmount: number;
  OrderItems: OrderItem[];

  constructor() {
    this.Id = 0;
    this.UserId = 0;
    this.Date = new Date();
    this.TotalAmount = 0;
    this.OrderItems = [];
  }
}
