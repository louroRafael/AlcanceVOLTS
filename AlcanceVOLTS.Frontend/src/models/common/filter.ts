export class Filter {
    constructor(
        public generalSearch: string = "",
        public page: number = 1,
        public itemsPerPage: number = 10,
    ) {
    }
}