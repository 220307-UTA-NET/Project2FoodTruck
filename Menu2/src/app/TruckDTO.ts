import { Employee } from "./Employee";

export interface TruckDTO{
    date:any;
    menuID:number;
    employees: Employee[];
    location: string;
}