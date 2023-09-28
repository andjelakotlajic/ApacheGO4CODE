import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map } from 'rxjs';
import { CreatePost } from '../model/createpost.model';
import { Post } from '../model/post.model';
import { EditPost } from '../model/editpost.model';


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
            this.posts.push(new Post(element.id, element.text, element.createdTime, element.postLabels, element.user))
       });
       return this.posts
      }),
    );
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
            this.posts.push(new Post(element.id, element.text, element.createdTime, element.postLabels, element.user))
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
}