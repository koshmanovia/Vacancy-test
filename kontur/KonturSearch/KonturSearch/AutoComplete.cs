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
        string tempKey = default;
        Dictionary<string, List<string>> fullNameDictionary = new Dictionary<string, List<string>>();
        List<string> outputFullNameList = new List<string>();
        public void AddToSearch(List<FullName> fullNames)
        {
            for (int i = 0; i < fullNames.Count; i++)
            {
                tempKey = fullNames[i].ToString().Substring(0, 1);
                if (fullNameDictionary.ContainsKey(tempKey) != true)
                {
                    fullNameDictionary.Add(tempKey, new List<string>() { fullNames[i].ToString() });
                    Console.WriteLine("Значение добавлено ключа нет"); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                else
                {
                    fullNameDictionary[tempKey].Add(fullNames[i].ToString());
                    Console.WriteLine("Значение добавлено ключ есть"); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
        }
        public List<string> Search(string prefix)
        {
            tempKey = prefix.Substring(0, 1);
            Console.WriteLine(tempKey + " " + tempKey.Length); //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (prefix.Length > 101)
            {
                throw new ArgumentException("Long request name.");
            }
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Empty request.");
            }
            for (int i = 0; i < fullNameDictionary.Count; i++)
            { 
                if (fullNameDictionary.ContainsKey(tempKey))
                {
                    for (int j = 0; j < fullNameDictionary[tempKey].Count; j++)
                    {
                        if (fullNameDictionary[tempKey][j].Substring(0, prefix.Length) == prefix)
                        {
                            outputFullNameList.Add(fullNameDictionary[tempKey][j]);
                        }
                    }
                }
            }
            Console.WriteLine(outputFullNameList.Count);
            return outputFullNameList;
        }
    }
}