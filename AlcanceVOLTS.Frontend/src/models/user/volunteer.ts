import { Team } from "../team/team";

export class Volunteer {
    constructor(
        public name: string,
        public email: string,
    ) {}

    public button: boolean;
    public tshirt: boolean;
    public wristband: boolean;
    public badge: boolean;
    public badgeLabel: string;
    public walkieTalkie: boolean;
    public walkieTalkieNumber: number;
    public checkIn: boolean;
    public teamLeader: boolean;
    public team: Team;
    public teamEdit: boolean = false;
}