using System;
using System.Collections.Generic;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReturnLongerValue("test1", "test"));
            Console.WriteLine(ReturnLongerValue(5, 10));
            Console.WriteLine(ReturnLongerValue(true, false));

            GenericHelper<PersonModel> personHelper = new GenericHelper<PersonModel>();
            personHelper.ValidateItem(new PersonModel { FirstName = "TestValid", IsValid = true });
            personHelper.ValidateItem(new PersonModel { FirstName = "TestInvalid", IsValid = false });

            Console.ReadLine();
        }

        public static T ReturnLongerValue<T>(T value1, T value2)
        {
            if (value1.ToString().Length > value2.ToString().Length)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
    }

    public class GenericHelper<T>
        where T : IValidate
    {
        public List<T> ValidItems { get; set; } = new List<T>();
        public List<T> InvalidItems { get; set; } = new List<T>();

        public int MyProperty { get; set; }
        public void ValidateItem(T item)
        {
            if (item.IsValid == true)
            {
                ValidItems.Add(item);
            }
            else
            {
                InvalidItems.Add(item);
            }
        }
    }
    
    public class MyList<T>
    {
        private string[] stringArray = new string[0];
        private int[] intArray;

        public void Add<T>(T item)
        {
            System.Array targetArray = GetArray(item);

        }

        private System.Array GetArray<U>(U item)
        {
            Type nodeType = item.GetType();

            if (nodeType == typeof(string))
            {
                return stringArray;
            }
            else if (nodeType == typeof(Int32))
            {
                return intArray;
            }

            return new string[0];
        }



    }

    public class PetModel : IIdentity,IPet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public interface IPerson
    {

    }

    public interface IPet
    {

    }

    public class PersonModel : IValidate, IIdentity, IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsValid { get; set; }
    }

    public interface IValidate
    {
        bool IsValid { get; set; }
    }

    public interface IIdentity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
    }
}