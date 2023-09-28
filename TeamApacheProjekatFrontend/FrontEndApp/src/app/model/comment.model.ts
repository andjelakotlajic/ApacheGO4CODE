export class Comment {
    id?: number
    text?: string
    userId?: number
    postId?: number

    constructor( id: number,
        text: string,
        userId: number,
        postId: number){
            this.id=id;
            this.text=text;
            this.postId=postId;
            this.userId=userId
        }

}
