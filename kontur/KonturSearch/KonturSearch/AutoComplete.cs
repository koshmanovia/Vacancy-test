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
            if (Name == null && Patronymic != null)
            {
                return string.Join(" ", Surname?.Trim(), Patronymic?.Trim()).Trim();
            }
            else
            {
                return string.Join(" ", Surname?.Trim(), Name?.Trim(), Patronymic?.Trim()).Trim();
            }           
        }
    }
    public class AutoCompleter
    {
        List<string> listForSearching = new List<string>();
        List<string> outputFullNameList = new List<string>();
        public void AddToSearch(List<FullName> fullNames)
        {
            for (int i = 0; i < fullNames.Count; i++)
            {
                listForSearching.Add(fullNames[i].ToString());                
            }
        }
        public List<string> Search(string prefix)
        {

            if (prefix.Length > 101)
            {
                throw new ArgumentException("Long request name.");
            }
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Empty request.");
            }
            for (int i = 0; i < listForSearching.Count; i++)
            {
                if (prefix.Contains(listForSearching[i].Substring(0, prefix.Length)))
                {
                    outputFullNameList.Add(listForSearching[i]);
                }
            }
            return outputFullNameList;
        }
    }    
}
