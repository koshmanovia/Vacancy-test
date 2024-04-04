using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_IP
{
    /*
    По возможности, кроме передачи параметров через командную строку,         
    предусмотреть возможность частичной/полной передачи параметров через
    файлы конфигурации или переменные среды*/ 
    
    /*!!! Их мы ловим и выводим 
         * ArgumentException
         * 
         */
    internal class ComandPromt
    {
        private string _pathLogFile = null;
        private string _pathOutputFile = null;
        private string _startIp = null;
        private string _mask = null;
       

        /*Все параметры передаются приложению через параметры командной строки:
        --file-log — путь к файлу с логами
        --file-output — путь к файлу с результатом
        --address-start —  нижняя граница диапазона адресов, необязательный параметр, по умолчанию обрабатываются все адреса
        --address-mask — маска подсети, задающая верхнюю границу диапазона десятичное число.Необязательный параметр
         В случае, если он не указан, обрабатываются все адреса, 
         начиная с нижней границы диапазона.Параметр нельзя использовать, если не задан address-start.*/

        /*
         custom:
        --data-start - дата начала, если не задана data-end, то работает до сегодня
        --data-end - дата конца
        --read - чтение данных из файла
        --default - стандартные настройки
        --show - показать текущие настройки
        --start - начать обработку
        --exit - выйти из приложения
        --save - сохранить настройку
        --help - вывод всех команд
        --cls - очистка экрана от лишнего
        --load - загрузить параметры из файла
         */
    }
}
