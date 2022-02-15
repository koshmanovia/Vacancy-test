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
        {   //Добавьте новый элемент чтобы он начал участвовать в поиске по фио         
            List<string> listForSearching = new List<string>();
            foreach (var fullName in fullNames)
            {
                if (fullName.Surname != null)
                {
                    tempFullName.Append(fullName.Surname + " ");
                }
                if (fullName.Name != null)
                {
                    tempFullName.Append(fullName.Name + " ");
                }
                if (fullName.Patronymic != null)
                {
                    tempFullName.Append(fullName.Patronymic);
                }
                listForSearching.Add(tempFullName.ToString());
                tempFullName.Clear();
            }
            listForSearching.Sort();
            linkedListForSearching = new LinkedList<string>(listForSearching);            
        }  
        public List<string> Search(string prefix)
        {
            //Реализуйте алгоритм поиска по префиксу фио, при этом фио может состоять только из имени или фамилии и имени или отчества или фамилии и отчества или всё вместе.
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
                if (stringСompare.Substring(0, prefix.Length).ToString().Contains(prefix))
                {
                    outputFullNameList.Add(stringСompare);
                }
            }
            return outputFullNameList;
        }    
    }
}

//Переданное ФИО может содержать между фамилией и именем или именем и отчеством множество пробелов. Количество пробелов не должно влиять на поиск.

//Ради упрощения, решили что автокомплит будет искать только по префиксу, без исправления ошибок и без поиска по подстроке.


