using System.Globalization;


namespace EisenhowerConsoleApp
{
    class Program
    {
        static TodoMatrix matrix = new TodoMatrix();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Matryca Eisenhowera");
                Console.WriteLine("====================");
                Console.WriteLine(matrix);
                Console.WriteLine("====================");
                Console.WriteLine("1. Dodaj zadanie do IU");
                Console.WriteLine("2. Dodaj zadanie do IN");
                Console.WriteLine("3. Dodaj zadanie do NU");
                Console.WriteLine("4. Dodaj zadanie do NN");
                Console.WriteLine("5. Oznacz zadanie jako wykonane");
                Console.WriteLine("6. Usuń zadanie");
                Console.WriteLine("====================");
                Console.Write("Wybierz (1/2/3/4/5/6: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTaskToQuarter("IU");
                        break;
                    case "2":
                        AddTaskToQuarter("IN");
                        break;
                    case "3":
                        AddTaskToQuarter("NU");
                        break;
                    case "4":
                        AddTaskToQuarter("NN");
                        break;
                    case "5":
                        MarkTaskAsDone();
                        break;
                    case "6":
                        RemoveTaskFromQuarter();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wciśnij Enter, aby kontynuować.");
                        Console.ReadLine();
                        break;
                }
            }
        }


        static void AddTaskToQuarter(string quarter)
        {
            Console.Clear();
            Console.Write($"Podaj tytuł zadania ({quarter}): ");
            string title = Console.ReadLine();

            Console.Write("Podaj termin zadania (d-M): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "d-M", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deadline))
            {
                Console.Write("Czy zadanie jest ważne (T/N)? ");
                bool isImportant = Console.ReadLine().Equals("T", StringComparison.OrdinalIgnoreCase); //Jeśli t to true

                matrix.AddItem(title, deadline, isImportant, quarter);
                Console.WriteLine($"Zadanie zostało dodane do kwadrantu {quarter}. Wciśnij Enter, aby kontynuować.");
                Console.ReadLine();
            }
            else
            {
   
                Console.WriteLine("Nieprawidłowy format daty. Wciśnij Enter, aby kontynuować.");
                Console.ReadLine();
            }
        }


        static void MarkTaskAsDone()
        {
            Console.Clear();
            Console.WriteLine("Oznacz zadanie jako wykonane");

            var items = matrix.GetItems();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }

            Console.Write("Podaj numer zadania do oznaczenia jako wykonane (1/2/3): ");

            // Sprawdzenie, czy wprowadzona linia tekstowa jest liczbą całkowitą i czy jest w odpowiednim zakresie.
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= items.Count)
            {
                TodoItem item = items[taskNumber - 1];

                item.MarkAsDone();

                Console.WriteLine($"Zadanie '{item.Title}' zostało oznaczone jako wykonane.");
            }

            else
            {
                Console.WriteLine("Nieprawidłowy numer zadania lub zadanie nie istnieje.");
            }

            Console.WriteLine("Wciśnij Enter, aby kontynuować.");
            Console.ReadLine();
        }

        static void RemoveTaskFromQuarter()
        {
            
            Console.Clear();

           
            Console.WriteLine("Usuń zadanie z kwadrantu");

            Console.WriteLine("Wybierz kwadrant (IU/IN/NU/NN): ");
            string quarter = Console.ReadLine();


            Console.WriteLine("Wybierz numer zadania do usunięcia:");

            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {

                var quarterObject = matrix.GetQuarter(quarter);
                if (quarterObject != null)
                {
                    
                    quarterObject.RemoveItem(taskNumber - 1);

                    
                    Console.WriteLine($"Zadanie zostało usunięte z kwadrantu {quarter}.");
                }
                else
                {
                    
                    Console.WriteLine("Nieprawidłowy kwadrant.");
                }
            }
            else
            {

                Console.WriteLine("Nieprawidłowy numer zadania.");
            }

            
            Console.WriteLine("Wciśnij Enter, aby kontynuować.");
            Console.ReadLine();
        }

    }
}
