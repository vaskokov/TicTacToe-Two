using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Excersise
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {

        public List<Person> FamilyMembers { get; set; }
        public void AddMember(Person newPerson)
        {
            this.FamilyMembers.Add(newPerson);
        }

        static Person OldestPerson(List<Person> family)
        {
            family = family.OrderByDescending(x => x.Age).ToList();

            foreach (var member in family)
            {
                return member;
            }
        }
    }


    internal class Program
    {

        static void Main(string[] args)
        {
            int numberOfPersons = int.Parse(Console.ReadLine());
            List<Person> family = new List<Person>();

            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person newPerson = new Person(name, age);

                family.Add(newPerson);
            }
            OldestPerson(family);

        }
        
    }
}