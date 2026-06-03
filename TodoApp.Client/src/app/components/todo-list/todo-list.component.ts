import {Component, OnInit, signal, inject} from '@angular/core';
import {TodoService} from '../../services/todo.service';
import {Todo} from '../../models/todo.model';

@Component({
  selector: 'app-todo-list',
  imports: [],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css',
})
export class TodoListComponent implements OnInit {
  private todoService = inject(TodoService);
  todos = signal<Todo[]>([]);

  ngOnInit() {
    this.todoService.getTodos().subscribe({
      next: (data) => this.todos.set(data),
      error: (err) => console.error('Failed to load todos list', err)
    });
  }

  delete(id: string) {

  }
}
