export class RecoveryTruck {
  alias: string;
  model: string;
  plate: string;
  id: string;
  createDate: Date;

  constructor(alias, model, plate, id = null, createdDate = null) {
    this.alias = alias;
    this.model = model;
    this.plate = plate;
    this.id = id;
    this.createDate = createdDate;
  }
}
