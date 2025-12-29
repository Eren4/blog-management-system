import { Component, signal, inject, OnInit } from '@angular/core';
import { AbstractControl, ReactiveFormsModule } from '@angular/forms';
import { TagApi } from '../../DataAccess/tag-api';
import { TagResponseModel } from '../../Models/Tags/TagResponseModel';
import { createTagForm, toCreateTagRequest } from '../../Validations/Tags/CreateTagFormFactory';
import { updateTagForm, toUpdateTagRequest } from '../../Validations/Tags/UpdateTagFormFactory';

@Component({
  selector: 'app-tag-operation',
  imports: [ReactiveFormsModule],
  templateUrl: './tag-operation.html',
  styleUrl: './tag-operation.css',
})
export class TagOperation {
  private tagAPI = inject(TagApi);

  protected tags = signal<TagResponseModel[]>([]);
  protected selectedTag = signal<TagResponseModel | null>(null);

  // UI state formlarımız
  protected createForm = createTagForm();
  protected updateForm = updateTagForm();

  private async refreshTags(): Promise<void> {
    try {
      const values = await this.tagAPI.getAll();
      this.tags.set(values);
    }
    catch(error) {
      console.log("Etiket listesi alınamadı:", error);
    }
  }

  async ngOnInit(): Promise<void> {
    await this.refreshTags();
  }

  // Create işlemleri
  async onCreate(): Promise<void> {
    if(this.createForm.invalid) {
      this.createForm.markAllAsTouched();
      return;
    }

    const req = toCreateTagRequest(this.createForm);

    await this.tagAPI.create(req);

    this.createForm.reset();

    await this.refreshTags();
  }

  // Update işlemleri
  startUpdate(tag: TagResponseModel) {
    this.selectedTag.set(tag);

    this.updateForm.patchValue({
      id: tag.id,
      tagName: tag.tagName
    },
    { emitEvent: false }
  );
  }

  cancelUpdate() {
    this.selectedTag.set(null);
    this.updateForm.reset({ id: 0, tagName: ''});
  }

  async onUpdate() {
    if(this.updateForm.invalid) {
      this.updateForm.markAllAsTouched();
      return;
    }

    const req = toUpdateTagRequest(this.updateForm);

    await this.tagAPI.update(req);

    this.cancelUpdate();

    await this.refreshTags();
  }

  // Delete
  async onDelete(id: number): Promise<void> {
    const confirmDelete = window.confirm(`Id'si ${id} olan etiketi silmek istediğinize emin misiniz?`);

    if(!confirmDelete)
      return;

    try {
      const message = await this.tagAPI.deleteById(id);
      console.log('Delete mesajı', message);

      this.tags.update((x) => x.filter((t) => t.id !== id));

      const selected = this.selectedTag();
      if(selected && selected.id === id) {
        this.selectedTag.set(null);
      }
    } catch (error) {
      console.log(error);
    }
  }

  protected labels: Record<string, string> = {
    tagName: 'Etiket ismi',
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
