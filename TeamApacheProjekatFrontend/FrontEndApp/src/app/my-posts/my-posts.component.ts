import { Component } from '@angular/core';
import { Post } from '../model/post.model';
import { PostService } from '../services/post.service';
import { EditPost } from '../model/editpost.model';

@Component({
  selector: 'app-my-posts',
  templateUrl: './my-posts.component.html',
  styleUrls: ['./my-posts.component.css']
})
export class MyPostsComponent {
  posts: Post[] = []
  editPost: boolean = false
  idPostToEdit: number = 0
  editText: string = "" 
  constructor(private postService: PostService){}
  ngOnInit(){
    this.postService.getUserPosts().subscribe({
      next: (data) =>{
        console.log(data)
        this.posts = data
      }
    })
  }
  toggleEditPost(id: number, text: string){
    this.idPostToEdit = id
    this.editText = text
    this.editPost = !this.editPost
  }
  Edit(id: number){
    let editedPost: EditPost = new EditPost(this.editText)
    this.postService.editPost(editedPost, id).subscribe({
      next: (data) =>{
        this.ngOnInit()
      }
    })
    this.editPost = !this.editPost
  }

}
