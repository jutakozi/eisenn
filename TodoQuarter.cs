public class TodoQuarter
{
    public string Name { get; private set; }

    private List<TodoItem> TodoItems { get; set; }

    public TodoQuarter(string name)
    {
        Name = name;
        TodoItems = new List<TodoItem>();
    }

    public void AddItem(string title, DateTime deadline, bool isImportant)
    {
        if (deadline < DateTime.Now)
        {
            throw new ArgumentException("Nie można dodać zadania z przeszłym terminem.");
        }

        foreach (var item in TodoItems)
        {
            if (item.Deadline == deadline)
            {
                throw new ArgumentException("Nie można dodać zadania z tym samym terminem.");
            }
        }

        var newItem = new TodoItem(title, deadline, isImportant, Name);
        TodoItems.Add(newItem);
    }

    public void RemoveItem(int index)
    {
        // Sprawdzamy, czy podany indeks mieści się w zakresie listy zadań.
        if (index >= 0 && index < TodoItems.Count)
        {
            TodoItems.RemoveAt(index);
        }
    }

    public TodoItem GetItem(int index)
    {
        // czy podany indeks mieści się w zakresie listy zadań.
        if (index >= 0 && index < TodoItems.Count)
        {
            return TodoItems[index];
        }
        return null;
    }

    public List<TodoItem> GetItems()
    {
        return TodoItems;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < TodoItems.Count; i++)
        {
            result += $"{i + 1}. {TodoItems[i]}\n";
        }
        return result;
    }
}
