using System;


class Program
{
    static void Main(string[] args) 
    {
        BirthdayList birthdayList = new BirthdayList();

        // Если файл уже существует, загрузить данные из него
        if (File.Exists("birthday_list.txt"))
        {
            using (StreamReader reader = new StreamReader("birthday_list.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    DateTime birthday = DateTime.Parse(parts[1]);
                    birthdayList.AddPerson(new Person(name, birthday));
                }
            }
        }

        while (true)
        {
            Console.WriteLine("1. Показать все ДР");
            Console.WriteLine("2. Показать ближайшие ДР");
            Console.WriteLine("3. Добавить ДР");
            Console.WriteLine("4. Удалить ДР");
            Console.WriteLine("5. Редактировать ДР");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    birthdayList.ShowAll();
                    break;

                case "2":
                    birthdayList.ShowUpcoming();
                    break;

                case "3":
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();

                    Console.Write("День рождения (день): ");
                    int day = int.Parse(Console.ReadLine());

                    Console.Write("День рождения (месяц): ");
                    int month = int.Parse(Console.ReadLine());

                    DateTime birthday = new DateTime(DateTime.Now.Year, month, day);

                    birthdayList.AddPerson(new Person(name, birthday));

                    // Записать данные вфайл
                    using (StreamWriter writer = new StreamWriter("birthday_list.txt", true))
                    {
                        writer.WriteLine($"{name},{birthday.ToShortDateString()}");
                    }

                    break;

                case "4":
                    Console.Write("Имя: ");
                    string nameToDelete = Console.ReadLine();

                    Person personToDelete = birthdayList.GetPersonByName(nameToDelete);

                    if (personToDelete != null)
                    {
                        birthdayList.RemovePerson(personToDelete);

                        // Перезаписать данные в файле
                        using (StreamWriter writer = new StreamWriter("birthday_list.txt"))
                        {
                            foreach (Person person in birthdayList.GetPeople())
                            {
                                writer.WriteLine($"{person.Name},{person.Birthday.ToShortDateString()}");
                            }
                        }

                        Console.WriteLine("Запись удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Запись не найдена.");
                    }

                    break;

                case "5":
                    Console.Write("Имя: ");
                    string nameToEdit = Console.ReadLine();

                    Person personToEdit = birthdayList.GetPersonByName(nameToEdit);

                    if (personToEdit != null)
                    {
                        Console.Write("Новое имя: ");
                        string newName = Console.ReadLine();

                        Console.Write("Новый день рождения (день): ");
                        int newDay = int.Parse(Console.ReadLine());

                        Console.Write("Новый день рождения (месяц): ");
                        int newMonth = int.Parse(Console.ReadLine());

                        DateTime newBirthday = new DateTime(DateTime.Now.Year, newMonth, newDay);

                        birthdayList.EditPerson(personToEdit, newName, newBirthday);

                        // Перезаписать данные в файле
                        using (StreamWriter writer = new StreamWriter("birthday_list.txt"))
                        {
                            foreach (Person person in birthdayList.GetPeople())
                            {
                                writer.WriteLine($"{person.Name},{person.Birthday.ToShortDateString()}");
                            }
                        }

                        Console.WriteLine("Запись изменена.");
                    }
                    else
                    {
                        Console.WriteLine("Запись не найдена.");
                    }

                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }

            Console.WriteLine();
        }
    }
}



