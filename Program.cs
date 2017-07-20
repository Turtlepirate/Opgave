using System;
using System.Collections.Generic;
using System.Text;

namespace CBrainOpgave
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> _childrenList = new List<Person>();
            List<Person> _childrenList2 = new List<Person>();
            _childrenList.Add(new Man(15, "Frank Junior", "Rangers", null));
            _childrenList2.Add(new Woman(30, "Dina", 15, null));
            _childrenList2.Add(new Woman(17, "Erika", 31, null));
            _childrenList.Add(new Man(18, "Steve Junior", "Steelers", null));

            Man Man2 = new Man( 32, "Frank", "Rangers", _childrenList);
            Woman woman1 = new Woman(55, "Mary", 32, _childrenList2);
           
            Console.WriteLine( Man2.GetName() + Man2.GetChildrenInfo());
            Console.WriteLine(woman1.GetName() + woman1.GetChildrenInfo());
            Console.WriteLine("Average age for " + woman1.Name + ": " + woman1.GetAverageAge());

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public List<Person> _Children;

        public Person()
        {
           
        }
        public virtual string GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + " ");
            return sb.ToString();
        }
        
        public virtual string GetChildrenInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Person p in _Children)
            {
                sb.AppendLine(" , " + p.GetName());
            }

            return sb.ToString();
        }

        public string GetAverageAge()
        {
            StringBuilder sb = new StringBuilder();
            int averageAge = 0;
            sb.Append(Name + " (age " + Age + ")");

            foreach (Person p in _Children)
            {
                sb.Append(", " + p.Name + " (age " + Age + ")");
                averageAge += p.Age;
            }

            averageAge = averageAge / _Children.Count + 1;
            sb.AppendLine(" Average: " + averageAge);
            return sb.ToString();  
        }
        
    }

    public class Man : Person 
    {
        public string FavTeam { get; set; }

        public Man(int age, string name, string favTeam, List<Person> _childrenList)
        {
            Name = name;
            Age = age;
            FavTeam = favTeam;
            _Children = _childrenList;
        }

        public override string GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.GetName() + "follows ");
            sb.Append(FavTeam);

            return sb.ToString();
        }

        public override string GetChildrenInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Person p in _Children)
            {
                sb.Append(" , " + p.GetName());
            }

            return sb.ToString();
        }
    }

    public class Woman : Person
    {
        public int ShoeSize { get; set; }

        public Woman(int age, string name, int shoeSize, List<Person> _childrenList)
        {
            Name = name;
            Age = age;
            ShoeSize = shoeSize;
            _Children = _childrenList;
        }

        public override string GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.GetName() + " size ");
            sb.Append(ShoeSize);

            return sb.ToString();
        }

        public override string GetChildrenInfo()
        {
            
            StringBuilder sb = new StringBuilder();

            foreach (Person p in _Children)
            {   
                sb.Append(" , " + p.GetName());       
            }

            return sb.ToString();
        }
    }


}