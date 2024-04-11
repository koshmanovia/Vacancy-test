using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_IP
{
    internal class DictionaryIpAndDateEnumerator : IDictionaryEnumerator
    {
        int currIndex = -1;        
        DictionaryIpAndDate dictionaryIpAndDate;

        public DictionaryIpAndDateEnumerator(DictionaryIpAndDate dictionaryIpAndDate)
        {
            this.dictionaryIpAndDate = dictionaryIpAndDate;
        }

        public object Current
        {
            get { return dictionaryIpAndDate; }
        }
        public bool MoveNext()
        {
            currIndex++;
            if (currIndex >= dictionaryIpAndDate.CountDate)
                return false;
            else
                return true;
        }
        public void Reset()
        {
            currIndex = -1;
        }
    }
}
