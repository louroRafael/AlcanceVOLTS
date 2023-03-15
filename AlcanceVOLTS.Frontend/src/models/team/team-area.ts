import { Period } from "../event/period";

export class TeamArea {
    teamId: string;
    areaId: string | null;
    areaName: string;
    periodId: string;
    
    period: Period | null;
}