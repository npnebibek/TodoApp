import {ComponentFixture, TestBed} from '@angular/core/testing';
import {TodoService} from '../../services/todo.service';
import {TodoListComponent} from './todo-list.component';
import {Todo} from '../../models/todo.model';
import {provideHttpClient} from '@angular/common/http';
import {vi} from 'vitest';
import {of} from 'rxjs';

const mockTodos: Todo[] = [
  {id: '1', title: 'Buy milk', isCompleted: false},
  {id: '2', title: 'Walk dog', isCompleted: true},
];

const mockTodoService = {
  getTodos: vi.fn().mockReturnValue(of(mockTodos)),
};

describe('TodoList', () => {
  let component: TodoListComponent;
  let fixture: ComponentFixture<TodoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TodoListComponent],
      providers: [
        provideHttpClient(),
        {provide: TodoService, useValue: mockTodoService}
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(TodoListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should load todos on init', () => {
    expect(mockTodoService.getTodos).toHaveBeenCalled();
  });
});
