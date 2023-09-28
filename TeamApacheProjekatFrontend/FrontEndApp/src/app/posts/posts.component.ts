import { Component } from '@angular/core';
import { PostService } from '../services/post.service';
import { Post } from '../model/post.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent {
  posts: Post[] = []
  constructor(private postService: PostService){}
  ngOnInit(){
    this.postService.getPosts().subscribe({
      next: (data) =>{
        console.log(data);

        this.posts = data;
      }
    })
  }
}
