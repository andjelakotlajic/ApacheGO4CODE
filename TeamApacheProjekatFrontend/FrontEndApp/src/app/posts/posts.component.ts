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
  showCommentFormForPost: number | null = null; 
  newComment: string= ''; 

  constructor(private postService: PostService){}

  ngOnInit(){
    this.postService.getPosts().subscribe({
      next: (data) =>{
        console.log(data);

        this.posts = data;
      }
    })
  }
  showCommentForm(post_id: number) {
    this.showCommentFormForPost = post_id;
  }
  addComment(postId:number){
    const commentData = {
      postId: postId,
      text: this.newComment
    };
    this.postService.addComment(commentData).subscribe({
      next: (response) => {
        console.log('Komentar je uspešno dodat:', response);
        // Osvježite listu postova nakon dodavanja komentara
        this.postService.getPosts().subscribe({
          next: (data) => {
            this.posts = data;
          }
        });
      },
      error: (error: any) => {
        console.error('Došlo je do greške prilikom dodavanja komentara:', error);
      }
    });
        
        this.newComment = "";
        this.showCommentFormForPost = null;
  }
}
