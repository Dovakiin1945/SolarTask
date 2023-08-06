class BirthdayList
{
    private List<Person> people;

    public BirthdayList()
    {
        people = new List<Person>();
    }
    public Person GetPersonByName(string name)
    {
        return people.FirstOrDefault(p => p.Name == name);
    }
    public List<Person> GetPeople()
    {
        return people;
    }
    public void AddPerson(Person person)
    {
        people.Add(person);
    }

    public void RemovePerson(Person person)
    {
        people.Remove(person);
    }

    public void EditPerson(Person person, string name, DateTime birthday)
    {
        person.Name = name;
        person.Birthday = birthday;
    }

    public void ShowAll()
    {
        Console.WriteLine("Список всех ДР:");
        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }
    }

    public void ShowUpcoming()
    {
        Console.WriteLine("Список ближайших ДР:");
        DateTime now = DateTime.Now;
        List<Person> upcoming = people.Where(p => p.Birthday.Month >= now.Month && p.Birthday.Day >= now.Day).OrderBy(p => p.Birthday).ToList();
        foreach (Person person in upcoming)
        {
            Console.WriteLine(person);
        }
    }
}



