import { EventFrequency } from "src/enums/event-frequency";
import { EventStatus } from "src/enums/event-status";

export class Event {
    public id: string;
    public name: string;
    public observation: string;
    public initialDate: string;
    public finalDate: string;
    public button: string;
    public tshirt: string;
    public status: EventStatus;
}