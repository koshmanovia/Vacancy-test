using System;
using System.Text;
using System.Collections.Generic;

namespace AutoComplete
{
    public struct FullName
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public override string ToString()
        {
            return string.Join(" ", Surname?.Trim(), Name?.Trim(), Patronymic?.Trim()).Trim();
        }
    }
    public class AutoCompleter
    {
        char tempKey = default;
        Dictionary<char, List<string>> fullNameDictionary = new Dictionary<char, List<string>>();
        List<string> outputFullNameList = new List<string>();
        public void AddToSearch(List<FullName> fullNames)
        {
            for (int i = 0; i < fullNames.Count; i++)
            {
                tempKey = fullNames[i].ToString().ToLower()[0];
                Console.WriteLine(tempKey);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (fullNameDictionary.ContainsKey(tempKey) != true)
                {
                    fullNameDictionary.Add(tempKey, new List<string>());
                    fullNameDictionary[tempKey].Add(fullNames[i].ToString());
                   // Console.WriteLine(fullNames[i].ToString());//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //Console.WriteLine("Значение добавлено ключа нет"); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                else
                {
                    fullNameDictionary[tempKey].Add(fullNames[i].ToString());
                   // Console.WriteLine(fullNames[i].ToString());//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                  // Console.WriteLine("Значение добавлено ключ есть"); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
        }
        public List<string> Search(string prefix)
        {           
            if (prefix.Length > 100)
            {
                throw new ArgumentException("Long request name.");
            }
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Empty request.");
            }
            tempKey = prefix.ToLower()[0];
            Console.WriteLine(tempKey); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (fullNameDictionary.ContainsKey(tempKey))
            {
                for (int i = 0; i < fullNameDictionary[tempKey].Count; i++)
                {
                    try
                    {
                        if (fullNameDictionary[tempKey][i].Substring(0, prefix.Length).ToLower() == prefix.ToLower())
                        {
                            outputFullNameList.Add(fullNameDictionary[tempKey][i]);
                            Console.WriteLine(fullNameDictionary[tempKey][i]);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                }
            }           
            Console.WriteLine(outputFullNameList.Count);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return outputFullNameList;
        }
    }
}