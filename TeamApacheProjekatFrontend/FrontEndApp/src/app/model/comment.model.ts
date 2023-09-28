export class Comment {
    id: number
    text: string
    userId: number
    postId: number
    username:string

    constructor( id: number,
        text: string,
        userId: number,
        postId: number,username:string){
            this.id=id;
            this.text=text;
            this.postId=postId;
            this.userId=userId
            this.username=username
        }

}
