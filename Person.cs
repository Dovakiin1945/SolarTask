class Person
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }

    public Person(string name, DateTime birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Name} ({Birthday.ToShortDateString()})";
    }
}



