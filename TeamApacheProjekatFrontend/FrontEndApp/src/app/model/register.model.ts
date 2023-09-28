export class Register {
    username: string
    firstName: string
    lastName: string
    email: string
    password: string
    constructor(username: string, firstName: string, lastName: string, mail: string, password: string) {
        this.username = username
        this.firstName = firstName
        this.lastName = lastName
        this.email = firstName
        this.password = password
    }
}