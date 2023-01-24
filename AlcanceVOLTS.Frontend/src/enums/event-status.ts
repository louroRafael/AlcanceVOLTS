export enum EventStatus {
    Agendado = 1,
    Andamento = 2,
    Finalizado = 3,
    Adiado = 4,
    Cancelado = 5
}

export const EventStatusLabelMapping = [
    { value: EventStatus.Agendado, label: "Agendado"},
    { value: EventStatus.Andamento, label: "Em Andamento"},
    { value: EventStatus.Finalizado, label: "Finalizado"},
    { value: EventStatus.Adiado, label: "Adiado"},
    { value: EventStatus.Cancelado, label: "Cancelado"},
];