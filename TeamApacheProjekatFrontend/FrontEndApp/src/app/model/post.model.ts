import { Label } from "./label.model"
import { postUser } from "./postUser.model"

export class Post {
    id: number
    text: string
    createdTime: string
    postLabels: Label[]
    user: postUser
    rate: number
    constructor(id: number, text: string, createdTime: string, labels: Label[], User: postUser) {
        this.text = text
        this.id = id
        this.createdTime = createdTime
        this.postLabels = labels 
        this.user = User
        this.rate = 0
    }
}