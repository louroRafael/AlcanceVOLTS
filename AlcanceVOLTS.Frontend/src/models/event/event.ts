import { EventFrequency } from "src/enums/event-frequency";
import { EventStatus } from "src/enums/event-status";

export class Event {
    public id: string;
    public name: string;
    public observation: string;
    public initialDate: string;
    public finalDateFormControl: string;
    public snackFormControl: string;
    public buttonFormControl: string;
    public recurrentFormControl: string;
    public frequencyFormControl: EventFrequency;
    public statusFormControl: EventStatus;
}