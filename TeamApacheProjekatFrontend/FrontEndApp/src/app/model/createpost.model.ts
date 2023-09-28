import { Label } from "./label.model"

export class CreatePost {
    text: string
    labels: Label[]
    constructor(text: string, labels: Label[]) {
        this.text = text
        this.labels = labels
    }
}