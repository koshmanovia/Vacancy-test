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
        List<string> listForSearching = new List<string>();
        List<string> outputFullNameList = new List<string>();
        public void AddToSearch(List<FullName> fullNames)
        {  
            if (fullNames[0].Surname != null)
            {
                if (fullNames[0].Name != null)
                {
                    if (fullNames[0].Patronymic != null)
                    {
                        foreach (var fullname in fullNames)
                        {
                            listForSearching.Add($"{fullname.Surname.Replace(" ", "")} {fullname.Name.Replace(" ", "")} {fullname.Patronymic.Replace(" ", "")}");
                        }
                    }
                    else
                    {
                        foreach (var fullname in fullNames)
                        {
                            listForSearching.Add($"{fullname.Surname.Replace(" ", "")} {fullname.Name.Replace(" ", "")}");
                        }                           
                    }
                }
                else
                if (fullNames[0].Patronymic != null)
                {
                    foreach (var fullname in fullNames)
                    {
                        listForSearching.Add($"{fullname.Surname.Replace(" ", "")} {fullname.Patronymic.Replace(" ", "")}");
                    }
                }
                else
                {
                    foreach (var fullname in fullNames)
                    {
                        listForSearching.Add($"{fullname.Surname.Replace(" ", "")}");
                    }                    
                }
            }
            if (fullNames[0].Name != null && fullNames[0].Surname == null)
            {               
                if (fullNames[0].Patronymic != null)
                {
                    foreach (var fullname in fullNames)
                    {
                        listForSearching.Add($"{fullname.Name.Replace(" ", "")} {fullname.Patronymic.Replace(" ", "")}");
                    }                    
                }
                else
                {
                    foreach (var fullname in fullNames)
                    {
                        listForSearching.Add($"{fullname.Name.Replace(" ", "")}");
                    }
                }
            }
            if(fullNames[0].Patronymic != null && fullNames[0].Surname == null && fullNames[0].Name == null)
            {
                foreach (var fullname in fullNames)
                {
                    listForSearching.Add($"{fullname.Patronymic.Replace(" ", "")}");
                }
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
            foreach (var stringСompare in listForSearching)
            {
                if(prefix.Equals(stringСompare.Substring(0, prefix.Length)))
                {
                    outputFullNameList.Add(stringСompare);
                }                    
            }
            return outputFullNameList;
        }
    }
}