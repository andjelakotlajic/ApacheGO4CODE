import { Component } from '@angular/core';
import { PostService } from '../services/post.service';
import { CreatePost } from '../model/createpost.model';
import { Label } from '../model/label.model';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent {
  labels: string[] = []
  labelText: string = ""
  postText: string = ""
  constructor(private postService: PostService, private router: Router,private http:  HttpClient){}
  AddLabel(){
    this.labels.push(this.labelText)
    this.labelText = ""
  }
  fileForm = new FormGroup({
    altText: new FormControl(''),
    description: new FormControl('')
  });
  fileToUpload: any;
  
  handleFileInput(e: any) {
    this.fileToUpload = e?.target?.files[0];
  }
  saveFileInfo()
  {
    debugger
    const formData: FormData = new FormData();
    formData.append('Id', "1");
    formData.append('Files', this.fileToUpload);
    formData.append('Name', this.fileForm.value.altText!);
    return this.http.post('http://localhost:5166/api/FileUpload', formData,
    {
      headers : new HttpHeaders()})
    .subscribe(() => alert("File uploaded"));
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
