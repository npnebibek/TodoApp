import {Component, OnInit, signal, inject, DestroyRef} from '@angular/core';
import {ReactiveFormsModule, FormControl, Validators} from '@angular/forms';
import {takeUntilDestroyed} from '@angular/core/rxjs-interop';
import {TodoService} from '../../services/todo.service';
import {Todo} from '../../models/todo.model';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css',
})
export class TodoListComponent implements OnInit {
  private todoService = inject(TodoService);
  private destroyRef = inject(DestroyRef);
  todos = signal<Todo[]>([]);
  newTodoTitle = new FormControl('', [Validators.required, Validators.minLength(3)]);

  ngOnInit() {
    this.todoService.getTodos()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (data) => this.todos.set(data),
        error: (err) => console.error('Failed to load todos', err),
      });
  }

  add() {
    if (this.newTodoTitle.valid) {
      const newTodo: Todo = {
        title: this.newTodoTitle.value ?? '',
        isCompleted: false,
      };

      this.todoService.addTodo(newTodo)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe({
          next: (savedTodo) => {
            this.todos.update(list => [...list, savedTodo]);
            this.newTodoTitle.reset();
          },
          error: (err) => console.error('Failed to add todo', err),
        });
    }
  }

  delete(id: string) {
    this.todoService.deleteTodo(id)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => this.todos.update(list => list.filter(t => t.id !== id)),
        error: (err) => console.error('Failed to delete todo', err),
      });
  }

  toggleComplete(todo: Todo) {
    const updatedTodo = {...todo, isCompleted: !todo.isCompleted};

    this.todoService.updateTodo(updatedTodo)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => this.todos.update(list =>
          list.map(t => t.id === todo.id ? updatedTodo : t)
        ),
        error: (err) => console.error('Failed to update todo', err),
      });
  }
}
