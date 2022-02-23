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
        int tempArrayCount = default;
        int tempKeyExternalDictionary = default;
        int tempKeyInternalDictionary = default;
        Dictionary<int, Dictionary<int, List<string>>> fullNameDictionary = new Dictionary<int, Dictionary<int, List<string>>>();       
        public void AddToSearch(List<FullName> fullNames)
        {
            tempArrayCount = fullNames.Count;
            for (int i = 0; i < tempArrayCount; i++)
            {
                tempKeyExternalDictionary = fullNames[i].ToString()[0].GetHashCode();
                tempKeyInternalDictionary = fullNames[i].ToString()[1].GetHashCode();

                if (fullNameDictionary.ContainsKey(tempKeyExternalDictionary))
                {
                    if (fullNameDictionary[tempKeyExternalDictionary].ContainsKey(tempKeyInternalDictionary))
                    {
                        fullNameDictionary[tempKeyExternalDictionary][tempKeyInternalDictionary].Add(fullNames[i].ToString());
                    }
                    else
                    {
                        fullNameDictionary[tempKeyExternalDictionary].Add(tempKeyInternalDictionary, new List<string>() { fullNames[i].ToString() });
                    }
                }
                else
                {
                    fullNameDictionary.Add(tempKeyExternalDictionary, new Dictionary<int, List<string>>());
                    fullNameDictionary[tempKeyExternalDictionary].Add(tempKeyInternalDictionary, new List<string>() { fullNames[i].ToString() });
                }
            }
        }
        public List<string> Search(string prefix)
        {
           var outputFullNameList = new List<string>();
            if (prefix.Length > 100)
            {
                throw new ArgumentException("Long request name.");
            }
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Empty request.");
            }

            tempKeyExternalDictionary = prefix[0].GetHashCode();
            if (prefix.Length > 1)
            {
                tempKeyInternalDictionary = prefix[1].GetHashCode();
                if (fullNameDictionary.ContainsKey(tempKeyExternalDictionary))
                {

                    if (fullNameDictionary[tempKeyExternalDictionary].ContainsKey(tempKeyInternalDictionary))
                    {

                        tempArrayCount = fullNameDictionary[tempKeyExternalDictionary][tempKeyInternalDictionary].Count;
                        for (int i = 0; i < tempArrayCount; i++)
                        {
                            try
                            {
                                if (fullNameDictionary[tempKeyExternalDictionary][tempKeyInternalDictionary][i].StartsWith(prefix))
                                {
                                    outputFullNameList.Add(fullNameDictionary[tempKeyExternalDictionary][tempKeyInternalDictionary][i]);
                                }
                            }
                            catch (System.ArgumentOutOfRangeException)
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            else
            {
                int countArray = fullNameDictionary[tempKeyExternalDictionary].Count;
                List<int> keyInternalDictionary = new List<int>(fullNameDictionary[tempKeyExternalDictionary].Keys);
                for (int i = 0; i < countArray; i++)
                {
                    if (fullNameDictionary[tempKeyExternalDictionary].ContainsKey(keyInternalDictionary[i]))
                    {
                        for (int j = 0; j < fullNameDictionary[tempKeyExternalDictionary][keyInternalDictionary[i]].Count; j++)
                        {
                            outputFullNameList.Add(fullNameDictionary[tempKeyExternalDictionary][keyInternalDictionary[i]][j]);
                        }
                    }
                }
            }
            return outputFullNameList;
        }
    }
}