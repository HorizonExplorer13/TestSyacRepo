import { OrderProductsDTO } from "../AuxInterfaces/OrderProductsDTO";

export interface createPurchesOrder{
     clientName:string | null;
     clientDocument:string | null; 
     clientAddrees:string | null;
     orderProducts: OrderProductsDTO[];
     deliveryAddress:string | null;
     totalValue:string | null;
}