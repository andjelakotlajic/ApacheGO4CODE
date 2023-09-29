import { Component } from '@angular/core';
import { Post } from '../model/post.model';
import { PostService } from '../services/post.service';
import { EditPost } from '../model/editpost.model';
import { CommunicationService } from '../services/communication.service';

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
  constructor(private postService: PostService, private communicationService: CommunicationService){}
  ngOnInit(){
    this.postService.getUserPosts().subscribe({
      next: (data) =>{
        console.log(data)
        this.posts = data
      }
    })
    setTimeout(() => {
      this.posts.forEach(element =>{
        this.postService.getAverageRate(element.id).subscribe({
          next: (data) =>{
            element.rate = data
          },
          error: (data)=>{
            console.log('greska')
          }
        })
      })
    }, 300);
    this.communicationService.notifyParent()
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
  Delete(id: number){
    this.postService.deletePost(id).subscribe({
      next: (data) =>{
        this.ngOnInit()
      }
    })
  }
}