using System;
using System.Text;
using System.Collections.Generic;

namespace AutoComplete
{
    public struct FullName
    {
        internal string stringFullName;
        private int fullNameHash;
        public string Name;
        public string Surname;
        public string Patronymic;
        public override string ToString()
        {
            stringFullName = string.Join(" ", Surname?.Trim(), Name?.Trim(), Patronymic?.Trim()).Trim();
            return stringFullName;
        }
        public int GetHash()
        {
            if (stringFullName == null)
            {
                stringFullName = GetFullNameString();
            }
            if (fullNameHash == 0)
            {
                fullNameHash = stringFullName[0].GetHashCode();
            }
            return fullNameHash;
        }
        public string GetFullNameString()
        {
            if (stringFullName == null)
            {
                stringFullName = ToString();
            }
            return stringFullName;
        }
    }
    public class AutoCompleter
    {
        int tempArrayCount = default;
        int tempKey = default;
        Dictionary<int, List<string>> fullNameDictionary = new Dictionary<int, List<string>>();
        List<string> outputFullNameList = new List<string>();
        public void AddToSearch(List<FullName> fullNames)
        {
            tempArrayCount = fullNames.Count;
            for (int i = 0; i < tempArrayCount; i++)
            {
                tempKey = fullNames[i].GetHash();
                if (fullNameDictionary.ContainsKey(tempKey))
                {
                    fullNameDictionary[tempKey].Add(fullNames[i].GetFullNameString());
                }
                else
                {
                    fullNameDictionary.Add(tempKey, new List<string>() { fullNames[i].GetFullNameString() });
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
            tempKey = prefix[0].GetHashCode();
            outputFullNameList = new List<string>();
            if (fullNameDictionary.ContainsKey(tempKey))
            {
                tempArrayCount = fullNameDictionary[tempKey].Count;
                for (int i = 0; i < tempArrayCount; i++)
                {
                    try
                    {
                        if (fullNameDictionary[tempKey][i].StartsWith(prefix))
                        {
                            outputFullNameList.Add(fullNameDictionary[tempKey][i]);
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                }
            }
            return outputFullNameList;
        }
    }
}