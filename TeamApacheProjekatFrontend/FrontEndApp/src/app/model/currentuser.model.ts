export class CurrentUser {
    constructor(private _token: string, private _expiration:string){}
    get token() {
        return this._token;
    }
}
