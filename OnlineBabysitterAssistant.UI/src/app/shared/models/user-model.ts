import { ChildModel } from "./chlld-model"

export interface UserModel{
    id: number,
    name: string,
    address: string,
    email: string,
    phoneNumber: string
}

export interface BabysitterModel{
    id: number,
    name: string,
    address: string,
    email: string,
    phoneNumber: string,
    isConnectedToParent: boolean,
    parents: UserModel[],
    children: ChildModel[]
}

export interface UpdateUserInfo{
    name: string,
    address: string,
    email: string,
    phoneNumber: string
}