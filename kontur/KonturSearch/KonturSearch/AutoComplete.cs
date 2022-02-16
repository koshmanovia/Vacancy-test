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
    }
    public class AutoCompleter
    {       
        StringBuilder tempFullName = new StringBuilder();
        LinkedList<string> linkedListForSearching = default;
        public void AddToSearch(List<FullName> fullNames)
        {          
            List<string> listForSearching = new List<string>();
            foreach (var fullName in fullNames)
            {
                if (fullName.Surname != null && string.IsNullOrWhiteSpace(fullName.Surname) != true)
                {                   
                    tempFullName.Append(fullName.Surname.Replace(" ", "") + " ");
                }
                if (fullName.Name != null && string.IsNullOrWhiteSpace(fullName.Name) != true)
                {
                    tempFullName.Append(fullName.Name.Replace(" ", "") + " ");
                }
                if (fullName.Patronymic != null && string.IsNullOrWhiteSpace(fullName.Patronymic) != true)
                {
                    tempFullName.Append(fullName.Patronymic.Replace(" ", "") + " ");
                }
                
                listForSearching.Add(tempFullName.ToString().Remove(tempFullName.ToString().Length - 1, 1));
                tempFullName.Clear();
            }
            listForSearching.Sort();
            linkedListForSearching = new LinkedList<string>(listForSearching);            
        }  
        public List<string> Search(string prefix)
        {            
            List<string> outputFullNameList = new List<string>();            
            if (prefix.Length > 101)
            {
                throw new ArgumentException("Long request name.");
            }
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Empty request.");
            }

            foreach (var stringСompare in linkedListForSearching)
            {                
                if (stringСompare.ToLower().Substring(0, prefix.Length).ToString().Contains(prefix.ToLower()))
                {
                    outputFullNameList.Add(stringСompare);
                }
            }
            return outputFullNameList;
        }    
    }
}



