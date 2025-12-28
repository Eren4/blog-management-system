import { Component, signal, inject, OnInit } from '@angular/core';
import { AbstractControl, ReactiveFormsModule } from '@angular/forms';
import { PostApi } from '../../DataAccess/post-api';
import { PostResponseModel } from '../../Models/Posts/PostResponseModel';
import { createPostForm, toCreatePostRequest } from '../../Validations/Posts/CreatePostFormFactory';
import { updatePostForm, toUpdatePostRequest } from '../../Validations/Posts/UpdatePostFormFactory';
import { PublishState } from '../../Models/Posts/PublishState';

@Component({
  selector: 'app-post-operation',
  imports: [ReactiveFormsModule],
  templateUrl: './post-operation.html',
  styleUrl: './post-operation.css',
})
export class PostOperation {
  private postAPI = inject(PostApi);

  protected posts = signal<PostResponseModel[]>([]);
  protected selectedPost = signal<PostResponseModel | null>(null);

  protected PublishState = PublishState;
  protected publishStates = signal<PublishState[]>([
    PublishState.Draft,
    PublishState.Published
  ]);

  // UI state formlarımız
  protected createForm = createPostForm();
  protected updateForm = updatePostForm();

  private async refreshPosts(): Promise<void> {
    try {
      const values = await this.postAPI.getAll();
      this.posts.set(values);
    }
    catch(error) {
      console.log("Gönderi listesi alınamadı:", error);
    }
  }

  async ngOnInit(): Promise<void> {
    await this.refreshPosts();
  }

  // Create işlemleri
  async onCreate(): Promise<void> {
    if(this.createForm.invalid) {
      this.createForm.markAllAsTouched();
      return;
    }

    const req = toCreatePostRequest(this.createForm);

    await this.postAPI.create(req);

    this.createForm.reset();

    await this.refreshPosts();
  }

  // Update işlemleri
  startUpdate(post: PostResponseModel) {
    this.selectedPost.set(post);

    this.updateForm.patchValue({
      id: post.id,
      title: post.title,
      content: post.content,
      excerpt: post.excerpt,
      publishState: post.publishState
    },
    { emitEvent: false }
  );
  }

  cancelUpdate() {
    this.selectedPost.set(null);
    this.updateForm.reset({ id: 0, title: '', content: '', excerpt: '', publishState: null});
  }

  async onUpdate() {
    if(this.updateForm.invalid) {
      this.updateForm.markAllAsTouched();
      return;
    }

    const req = toUpdatePostRequest(this.updateForm);

    await this.postAPI.update(req);

    this.cancelUpdate();

    await this.refreshPosts();
  }

  // Delete
  async onDelete(id: number): Promise<void> {
    const confirmDelete = window.confirm(`Id'si ${id} olan gönderiyi silmek istediğinize emin misiniz?`);

    if(!confirmDelete)
      return;

    try {
      const message = await this.postAPI.deleteById(id);
      console.log('Delete mesajı', message);

      this.posts.update((x) => x.filter((p) => p.id !== id));

      const selected = this.selectedPost();
      if(selected && selected.id === id) {
        this.selectedPost.set(null);
      }
    } catch (error) {
      console.log(error);
    }
  }

  protected labels: Record<string, string> = {
    title: 'Gönderi Başlığı',
    content: 'İçerik',
    excerpt: 'Alıntı',
    publishState: 'Yayımlanma durumu',
    id: 'ID'
  };

  protected getErrorMessage(control: AbstractControl | null, label='Bu alan'): string | null {
    if(!control || (!control.touched && !control.dirty) || !control.invalid)
      return null;

    else if(control.hasError('required'))
      return `${label} zorunludur`;

    else if(control.hasError('minlength')) {
      const e = control.getError('minlength'); // requiredlength, actualLength
      return `${label} en az ${e.requiredLength} karakter olmalıdır`;
    }
    else if(control.hasError('maxlength')) {
      const e = control.getError('maxlength');
      return `${label} en fazla ${e.requiredLength} karakter olmalıdır`;
    }

    return `${label} geçersiz`;
  }

  protected getErrorMessageByName(form: { controls: Record<string, AbstractControl> }, controlName: string):
  string | null {
    const control = form.controls[controlName];
    const label = this.labels[controlName] ?? controlName;

    return this.getErrorMessage(control, label);
  }
}
