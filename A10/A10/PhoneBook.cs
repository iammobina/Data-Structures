using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;
using System.Collections;

namespace A10
{
    //public class Contact
    //{
    //    public string Name;
    //    public int Number;

    //    public Contact(string name, int number)
    //    {
    //        Name = name;
    //        Number = number;
    //    }
    //}

    public class PhoneBook : Processor
    {
        public PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        //  protected List<Contact> PhoneBookList;
       // protected SortedDictionary<string, int> pp;
        //protected List<Tuple<string, int>> PhoneBookListy;
        //List<Dictionary<string, int>> PhoneBooky;
        // protected Dictionary<string, string> phony;
        // protected Dictionary<string, int> Phonebook;
        protected Dictionary<int, string> FinalPhoneBook;
        // protected Tuple<string, int>[] array;

        public string[] Solve(string[] commands)
        {
            //List<Dictionary<string, int>> PhoneBooky = new List<Dictionary<string, int>>();
            ////PhoneBookList = new List<Contact>(commands.Length);
            //pp = new SortedDictionary<string, int>();
            //phony = new Dictionary<string, string>(commands.Length);
            //Tuple<string, int>[] array = new Tuple<string, int>[100000000];
            //ArrayList al = new ArrayList();
            FinalPhoneBook = new Dictionary<int, string>(commands.Length);
            //PhoneBookListy = new List<Tuple<string, int>>(100000000);
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                //string number = (args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number)
        {
            // if (Phonebook.ContainsValue(number))
            // {
            //     var myKey = Phonebook.FirstOrDefault(x => x.Value == number).Key;
            // }
            //else Phonebook.Add(name, number);
            //string key;
            //for (int i = 0; i < PhoneBooky.Count; i++)
            //{
            //    if (PhoneBooky[i].TryGetValue(string input,out number))
            //    {
            //        string input = PhoneBooky[i].Keys;
            //    }
            //}
            //PhoneBookListy.Add(new Tuple<string, int>(name, number));
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i].Item2 == number)
            //    {
            //        return array[i].Item2;

            //    }
            //}
            //PhoneBookList.Add(new Contact(name, number));
            //if (PhoneBookListy.Where(t => t.Item2 == number).Any())
            //{
            //    var MyKey = PhoneBookListy.Select(t => t.Item2);
            //}

            //PhoneBookListy.Add(new Tuple<string, int>(name, number));//,new Tuple<string, int>(name,number));


            if (FinalPhoneBook.ContainsKey(number))
            {
                FinalPhoneBook[number]=name;
                return;
            }
            else
                FinalPhoneBook.Add(number, name);
        }

        public string Find(int number)
        {
            //if (PhoneBookListy.Where(t => t.Item2 == number).Any())
            //{
            //    var m = PhoneBookListy.Find(x => x.Item2 == number);
            //    return m.Item1;
            //}
            //else
            //    return "not found";

            if (FinalPhoneBook.ContainsKey(number))
            {
                string MyValue = FinalPhoneBook[number];
                return MyValue;
            }
            else
                return "not found";

        }

        public void Delete(int number)
        {
            //PhoneBookListy.RemoveAll(p => p.Item2 == number);
            //if (FinalPhoneBook.ContainsKey(number))
            //{
            //    var strKey = final.FirstOrDefault(x => x.Value == number).Key;
            //    phony.Remove(strKey);
            //}
            //for (int i = 0; i < PhoneBookListy.Count; i++)
            //{
            //    if (PhoneBookListy[i].Item2 == number)
            //    {
            //        PhoneBookListy.RemoveAt(i);
            //        return;
            //    }
            //}
            if (FinalPhoneBook.ContainsKey(number))
            {
                //var DeletedContact = FinalPhoneBook[number];
                FinalPhoneBook.Remove(number);
            }

        }

    }
}
