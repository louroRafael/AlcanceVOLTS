export enum UserType {
    Administrador = 1,
    Voluntario = 2
}

export const UserTypeLabelMapping = [
    { value: UserType.Administrador, label: "Administrador"},
    { value: UserType.Voluntario, label: "Voluntário"}
];