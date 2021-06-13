export interface Item {
    id?: string,
    title?: string,
    desc?: string,
    price?:number,
    stock?:number,
    user?:object,
    dateCreated?: number;
    dateUpdated?:number;
}