import { EventStatus } from "src/enums/event-status";
import { Period } from "./period";

export class RegisterEvent {
    public id: string;
    public name: string;
    public observation: string;
    public initialDate: Date;
    public finalDate: Date;
    public button: boolean;
    public tshirt: boolean;
    public status: EventStatus;
    public periodsQuantity: number;
    public periods: Period[];
}