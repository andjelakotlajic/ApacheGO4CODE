import { Label } from "./label.model"
import { postUser } from "./postUser.model"
import { Comment } from "@angular/compiler"

export class Post {
    id: number
    text: string
    createdTime: string
    views:number
    postLabels: Label[]
    user: postUser
    comments:Comment[]
    constructor(id: number, text: string, createdTime: string, labels: Label[], User: postUser,views:number,comments:Comment[]) {
        this.text = text
        this.id = id
        this.createdTime = createdTime
        this.postLabels = labels 
        this.user = User
        this.views=views
        this.comments=comments
    }
}