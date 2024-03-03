public class TodoMatrix
{
    private Dictionary<string, TodoQuarter> TodoQuarters { get; set; }

    public TodoMatrix()
    {

        TodoQuarters = new Dictionary<string, TodoQuarter>
        {
            {"IU", new TodoQuarter("IU")},
            {"IN", new TodoQuarter("IN")},
            {"NU", new TodoQuarter("NU")},
            {"NN", new TodoQuarter("NN")}
        };
    }

    // Pobieranie wszystkich kwadrantów z ich nazwami.
    public Dictionary<string, TodoQuarter> GetQuarters()
    {
        return TodoQuarters;
    }

    // Pobieranie konkretnego kwadrantu na podstawie jego nazwy.
    public TodoQuarter GetQuarter(string status)
    {
        if (TodoQuarters.ContainsKey(status))
        {
            return TodoQuarters[status];
        }
        return null;
    }

    public void AddItem(string title, DateTime deadline, bool isImportant, string quarter)
    {
        if (TodoQuarters.ContainsKey(quarter))
        {
            TodoQuarters[quarter].AddItem(title, deadline, isImportant);
        }
        else
        {
            Console.WriteLine("Nieprawidłowy kwadrant. Zadanie nie zostało dodane.");
        }
    }

    public override string ToString()
    {
        string result = "";
        foreach (var quarter in TodoQuarters)
        {
            result += $"{quarter.Key}:\n{quarter.Value}\n";
        }
        return result;
    }


    public List<TodoItem> GetItems()
    {
        List<TodoItem> items = new List<TodoItem>();
        foreach (var quarter in TodoQuarters.Values)
        {
            items.AddRange(quarter.GetItems());
        }
        return items;
    }


    public void AddItemToQuarter(string title, DateTime deadline, bool isImportant, string quarter)
    {
        if (TodoQuarters.ContainsKey(quarter))
        {
            TodoQuarters[quarter].AddItem(title, deadline, isImportant);
        }
        else
        {
            Console.WriteLine("Nieprawidłowy kwadrant. Zadanie nie zostało dodane.");
        }
    }
}
