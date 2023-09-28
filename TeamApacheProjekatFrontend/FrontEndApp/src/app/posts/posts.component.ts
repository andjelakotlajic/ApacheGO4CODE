import { Component } from '@angular/core';
import { PostService } from '../services/post.service';
import { Post } from '../model/post.model';
import { Rate } from '../model/rate.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent {
  posts: Post[] = []
  isShowRate: boolean = false
  rating: string = '1'
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
    }, 100);
  }
  RatePost(id: number){
    let rate: Rate = new Rate(Number(this.rating))
    this.postService.Rate(id, rate).subscribe({
      next: (data) =>{
        this.ngOnInit()
      },
      error: (data) =>{
        this.ngOnInit()
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
