import { Characteristic } from "./characteristic";
import { Image } from "./image";

export class Product {
  id: number;
  categoryId: number;
  name: string;
  price: number;
  stock: number;
  description: string;
  images: Image[];
  characteristics: Characteristic[];
  numPag: number;

}
