using System.Text.Json;
//using System.Text.Json.Serialization;
namespace TODO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("todos.json"))
            {
                string json = r.ReadToEnd();
                List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(json);
                Console.WriteLine("Todos by userId:");
                int userId = 1;
                foreach (Todo todo in todos)
                {
                    if (todo.userId == userId)
                    {
                        Console.WriteLine(todo.title);
                    }
                }
                Todo newTodo = new Todo
                {
                    id = todos.Count + 1,
                    userId = 2,
                    title = "Clean the house",
                    completed = false
                };
                todos.Add(newTodo);
                int todoId = 2;
                Todo todoToEdit = todos.Find(todo => todo.id == todoId);
                if (todoToEdit != null)
                {
                    todoToEdit.title = "Wash the car";
                }
                int todoToDeleteId = 1;
                todos.RemoveAll(todo => todo.id == todoToDeleteId);
                string searchTerm = "run";
                List<Todo> matchingTodos = todos.FindAll(todo => todo.title.Contains(searchTerm));
                Console.WriteLine("Matching todos:");
                foreach (Todo todo in matchingTodos)
                {
                    Console.WriteLine(todo.title);
                }
                using (StreamWriter w = new StreamWriter("todos.json"))
                {
                    string updatedJson = JsonConvert.SerializeObject(todos);
                    w.Write(updatedJson);
                }

            }
        }
    }
}
