import { enumRole } from "../enums/role.enum";

export interface RegistrationRequest {
    username: string;
    mail: string;
    password: string;
    role: number;
}