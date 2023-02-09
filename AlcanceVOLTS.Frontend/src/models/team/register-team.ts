import { TeamArea } from "./team-area";

export class RegisterTeam {
    public id: string;
    public name: string;
    public dynamic: boolean;
    public eventId: string;
    public teamAreas: TeamArea[];
}