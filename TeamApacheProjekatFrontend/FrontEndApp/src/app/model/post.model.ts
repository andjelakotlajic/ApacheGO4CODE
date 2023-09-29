import { Label } from "./label.model"
import { postUser } from "./postUser.model"
import { Comment } from "./comment.model"

export class Post {
    id: number
    text: string
    createdTime: string
    views:number
    postLabels: Label[]
    user: postUser
    rate: number
    comments:Comment[]
    date: Date
    constructor(id: number, text: string, createdTime: string, labels: Label[], User: postUser,views:number,comments:Comment[]) {
        this.text = text
        this.id = id
        this.createdTime = createdTime
        this.postLabels = labels 
        this.user = User
        this.rate = 0
        this.views=views
        this.comments=comments
        this.date = new Date(createdTime)
    }
}