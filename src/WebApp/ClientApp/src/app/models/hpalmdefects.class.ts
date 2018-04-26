  export class Value {
      value: string;
      ReferenceValue: string;
  }

  export class Field {
      Name: string;
      values: Value[];
  }

  export class Entity {
      Fields: Field[];
      Type: string;
      childrencount: number;
  }

  export class RootObject {
      entities: Entity[];
      TotalResults: number;
  }

