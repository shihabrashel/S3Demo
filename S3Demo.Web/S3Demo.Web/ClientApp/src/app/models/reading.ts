export class Reading {
  BuildingId: number;
  ObjectId: number;
  DataFieldId: number;
  Value: number;
  Timestamp: string;
  constructor() {
    this.BuildingId = 0;
    this.ObjectId = 0;
    this.DataFieldId = 0;
    this.Value = 0;
    this.Timestamp = '00:00';
  }
}
