export enum enumRole {
    Administrator = "Administrator",
    Moderator = "Moderator",
    Producent = "Producent",
    Client = "Client"
}

export function getIndexOfEnumRole(role: string) {
    const enumRolesArray = Object.values(enumRole);
    const index = enumRolesArray.findIndex(value => value === role);
    return index;
}