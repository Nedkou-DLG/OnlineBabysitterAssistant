import { UserType } from "./user-type";

export interface RegisterUser {
    name: string,
    address?: string,
    phoneNumber: string,
    userName: string,
    password: string,
    email: string,
    type: UserType
}