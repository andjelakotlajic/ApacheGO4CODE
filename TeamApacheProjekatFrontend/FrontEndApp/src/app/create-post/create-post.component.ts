import { Component } from '@angular/core';
import { PostService } from '../services/post.service';
import { CreatePost } from '../model/createpost.model';
import { Label } from '../model/label.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent {
  labels: string[] = []
  labelText: string = ""
  postText: string = ""
  constructor(private postService: PostService, private router: Router){}
  AddLabel(){
    this.labels.push(this.labelText)
    this.labelText = ""
  }
  SavePost(){
    let labelsToSend : Label[] = []
    for(let i=0; i<this.labels.length; i++){
      labelsToSend.push(new Label(this.labels[i]))
    }
    let post : CreatePost = new CreatePost(this.postText, labelsToSend)
    this.postService.createPost(post).subscribe({
      next: (data) => {
        alert('post created')
        this.router.navigate(['/posts']);
      },
      error: (data) => {
        alert('post created')
        this.router.navigate(['/posts']);
      }
    })
  }
}
