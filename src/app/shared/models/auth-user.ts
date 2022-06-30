import { UserType } from "./user-type";

export interface AuthUser{
    token: string,
    email: string,
    id: number,
    alias: string,
    expiration: Date,
    name: string,
    username: string,
    type: string,
}
//                 token: 'aisdnaksjdn,axmnczm',
        //                 isAdmin: true,
        //                 email: 'john.doe@gmail.com',
        //                 id: '12312323232',
        //                 alias: 'john.doe@gmail.com'.split('@')[0],
        //                 expiration: moment().add(1, 'days').toDate(),
        //                 fullName: 'John Doe'