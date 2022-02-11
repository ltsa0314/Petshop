export class User {
  Id: number;
  Type: String;
  UserName: string;
  FullName: string;
  Password: string;

  constructor() {
    this.Id = 0;
    this.Type = '';
    this.UserName = '';
    this.FullName = '';
    this.Password = '';
  }
}
