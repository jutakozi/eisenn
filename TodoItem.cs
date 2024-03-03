public class TodoItem
{
    public string Quarter { get; set; }

    public string Title { get; set; }

    public DateTime Deadline { get; set; }

    public bool IsImportant { get; set; }

    public bool IsDone { get; set; }

    public TodoItem(string title, DateTime deadline, bool isImportant, string quarter)
    {
        Title = title;
        Deadline = deadline;
        IsImportant = isImportant;
        Quarter = quarter;
        IsDone = false; 
    }

    public void MarkAsDone()
    {
        IsDone = true;
    }

    public override string ToString()
    {
        string status = IsImportant ? "Ważne" : "Nieważne";
        string done = IsDone ? " (Wykonane)" : "";

    //"Tytuł zadania (Status) - Deadline: Dzień-Miesiąc (Opcjonalne: (Wykonane))"
        return $"{Title} ({status}) - Deadline: {Deadline.ToString("d-M")} {done}";
    }
}

