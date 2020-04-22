using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> emailPerson;
    private Dictionary<string, SortedDictionary<string, Person>> domainEmailPerson;
    private Dictionary<string, SortedDictionary<string, Person>> nameTownEmailPerson;
    private OrderedDictionary<int, SortedDictionary<string, Person>> ageEmailPerson;
    private OrderedDictionary<int, Dictionary<string, SortedDictionary<string, Person>>> ageTownEmailPerson;

    public PersonCollection()
    {
        this.emailPerson = new Dictionary<string, Person>();
        this.domainEmailPerson = new Dictionary<string, SortedDictionary<string, Person>>();
        this.nameTownEmailPerson = new Dictionary<string, SortedDictionary<string, Person>>();
        this.ageEmailPerson = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        this.ageTownEmailPerson = new OrderedDictionary<int, Dictionary<string, SortedDictionary<string, Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.emailPerson.ContainsKey(email)) return false;
        var person = new Person(email, name, age, town);
        this.emailPerson.Add(email, person);
        AddByDomain(email, person, this.domainEmailPerson);
        AddByNameTown(email, person, this.nameTownEmailPerson);
        AddByAge(email, person, this.ageEmailPerson);
        AddByAgeTown(email, person, this.ageTownEmailPerson);
        return true;
    }

    private void AddByAgeTown(string email, Person person, OrderedDictionary<int, Dictionary<string, SortedDictionary<string, Person>>> ageTownEmailPerson)
    {
        if (!ageTownEmailPerson.ContainsKey(person.Age))
        {
            ageTownEmailPerson[person.Age] = new Dictionary<string, SortedDictionary<string, Person>>();
        }

        if (!ageTownEmailPerson[person.Age].ContainsKey(person.Town))
        {
            ageTownEmailPerson[person.Age][person.Town] = new SortedDictionary<string, Person>();
        }

        ageTownEmailPerson[person.Age][person.Town].Add(email, person);
    }

    private void AddByAge(string email, Person person, OrderedDictionary<int, SortedDictionary<string, Person>> ageEmailPerson)
    {
        if (!ageEmailPerson.ContainsKey(person.Age))
        {
            ageEmailPerson[person.Age] = new SortedDictionary<string, Person>();
        }

        ageEmailPerson[person.Age].Add(email, person);
    }

    private void AddByNameTown(string email, Person person, Dictionary<string, SortedDictionary<string, Person>> nameTownEmailPerson)
    {
        var nameTownStr = string.Concat(person.Name, ",", person.Town);
        if (!nameTownEmailPerson.ContainsKey(nameTownStr))
        {
            nameTownEmailPerson[nameTownStr] = new SortedDictionary<string, Person>();
        }

        nameTownEmailPerson[nameTownStr].Add(email, person);
    }

    private void AddByDomain(string email, Person person, Dictionary<string, SortedDictionary<string, Person>> domainEmailPerson)
    {
        var domain = email.Split('@')[1];
        if (!domainEmailPerson.ContainsKey(domain))
        {
            domainEmailPerson[domain] = new SortedDictionary<string, Person>();
        }
        domainEmailPerson[domain].Add(email, person);
    }

    public int Count
    {
        get
        {
            return this.emailPerson.Count;
        }
    }

    public Person FindPerson(string email)
    {
        this.emailPerson.TryGetValue(email, out var person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        if (!this.emailPerson.ContainsKey(email)) return false;
        var person = this.emailPerson[email];
        this.emailPerson.Remove(email);

        var domain = email.Split('@')[1];
        var nameTownStr = string.Concat(person.Name, ",", person.Town);
        this.domainEmailPerson[domain].Remove(email);
        this.nameTownEmailPerson[nameTownStr].Remove(email);
        this.ageEmailPerson[person.Age].Remove(email);
        this.ageTownEmailPerson[person.Age][person.Town].Remove(email);

        return true;
    }

    public IEnumerable<Person> FindPeople(string emailDomain)
    {
        this.domainEmailPerson.TryGetValue(emailDomain, out var emailPerson);
        if (emailPerson == null) return new List<Person>();

        return emailPerson.Values;
    }

    public IEnumerable<Person> FindPeople(string name, string town)
    {
        var nameTownStr = string.Concat(name, ",", town);
        this.nameTownEmailPerson.TryGetValue(nameTownStr, out var emailPerson);
        if (emailPerson == null) return new List<Person>();
        return emailPerson.Values;
    }

    public IEnumerable<Person> FindPeople(int startAge, int endAge)
    {
        
        var ageEmailPersonResult = this.ageEmailPerson.Range(startAge, true, endAge, true);

        var people = new List<Person>();
        foreach (var ageEmailPerson in ageEmailPersonResult)
        {
            foreach (var emailPerson in ageEmailPerson.Value)
            {
                people.Add(emailPerson.Value);
            }
        }

        return people;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        
        var people = new List<Person>();
        var ageTownEmailPersonResult = this.ageTownEmailPerson.Range(startAge, true, endAge, true);
        foreach (var townEmailPerson in ageTownEmailPersonResult.Values)
        {
            if (townEmailPerson.ContainsKey(town))
            {
                foreach (var person in townEmailPerson[town].Values)
                {
                    people.Add(person);
                }
            }
        }

        return people;
    }
}
