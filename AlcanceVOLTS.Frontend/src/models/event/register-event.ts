import { EventFrequency } from "src/enums/event-frequency";
import { EventStatus } from "src/enums/event-status";

export class RegisterEvent {
    public id: string;
    public name: string;
    public observation: string;
    public initialDate: Date;
    public finalDateFormControl: Date;
    public snackFormControl: boolean;
    public buttonFormControl: boolean;
    public recurrentFormControl: boolean;
    public frequencyFormControl: EventFrequency;
    public statusFormControl: EventStatus;
}