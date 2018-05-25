declare module HPALMDefects {

  export interface Value {
      value: string;
      ReferenceValue: string;
  }

  export interface Field {
      Name: string;
      values: Value[];
  }

  export interface Entity {
      Fields: Field[];
      Type: string;
      childrencount: number;
  }

  export interface RootObject {
      entities: Entity[];
      TotalResults: number;
  }

}
