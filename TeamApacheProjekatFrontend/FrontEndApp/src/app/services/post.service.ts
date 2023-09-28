import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map } from 'rxjs';
import { CreatePost } from '../model/createpost.model';
import { Post } from '../model/post.model';
import { EditPost } from '../model/editpost.model';
import { Rate } from '../model/rate.model';


@Injectable({
  providedIn: 'root'
})
export class PostService {
  posts: Post[] = []
    constructor(private http: HttpClient) { }
    
  createPost(post: CreatePost) : Observable<boolean> {
    var url = 'http://localhost:5166/api/Post';
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.post<boolean>(url, post, {headers,responseType:'json'}).pipe(
      map(response => {
        return true
      }),
    );
  }
  getPosts() : Observable<Post[]> {
    this.posts = []
    var url = 'http://localhost:5166/api/Post/allPosts';
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.get<Post[]>(url, {headers,responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
            this.posts.push(new Post(element.id, element.text, element.createdTime, element.postLabels, element.user,element.views,element.comments))
          console.log(this.posts);
          });
       return this.posts
      }),
    );
  }

  addComment(data: { postId: number, text: string }): Observable<any> {
    const url = `http://localhost:5166/api/Comments`; // Primer URL-a za dodavanje komentara uz pretpostavku da postId određuje post
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
  })
    return this.http.post(url, data,{headers});
  }


  getUserPosts() : Observable<Post[]> {
    this.posts = []
    var url = 'http://localhost:5166/api/Post/user posts';
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.get<Post[]>(url, {headers,responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
            this.posts.push(new Post(element.id, element.text, element.createdTime, element.postLabels, element.user, element.views, element.comments))
       });
       return this.posts
      }),
    );
  }
  editPost(editPost: EditPost, postId: number) : Observable<boolean> {
    this.posts = []
    var url = 'http://localhost:5166/api/Post?postId='+postId;
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.put<boolean>(url, editPost, {headers,responseType:'json'}).pipe(
      map(response => {
        return true
      }),
    );
  }
  getAverageRate(postId: number) : Observable<number> {
    var url = 'http://localhost:5166/api/Post/GetRateAverage?postId='+postId;
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.post<number>(url, null, {headers}).pipe(
      map(response => {
        return response
      }),
    );
  }
  Rate(postId: number, rate: Rate) : Observable<boolean> {
    var url = 'http://localhost:5166/api/Post/AddRate?postId='+postId;
    const token = localStorage.getItem('authToken')
    const headers = new HttpHeaders({
        Authorization: `Bearer ${token}`
    })
    return this.http.post<boolean>(url, rate, {headers,responseType:'json'}).pipe(
      map(response => {
        return true
      }),
    );
  }
}