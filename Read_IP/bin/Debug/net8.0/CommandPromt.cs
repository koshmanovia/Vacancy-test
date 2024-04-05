using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_IP
{   
    /*!!! Их мы ловим и выводим 
         * ArgumentException - DataBaseIP - не подходит формат IP
         * FileNotFoundException - Setting - не найден конфигурациооный файл 
         */
    internal class CommandPromt
    {
        string s;
        public void EnterCommand()
        {
            Setting st = new Setting();
            while (true)
            {
                Console.Write("Введите команду: ");
                s = Console.ReadLine();                
                switch (s)
                {
                    case "file-log":
                        Console.WriteLine(st.PathLogFile);
                        break;
                    case "file-output":
                        Console.WriteLine(st.PathOutputFile);
                        break;
                    case "address-start":
                        Console.WriteLine(st.StartIp);
                        break;
                    case "address-mask":
                        Console.WriteLine(st.Mask);
                        break;
                    case "help":
                        Help();
                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "exit":
                        Environment.Exit(0) ; 
                        break;
                     case "start":
                        DataBaseIP db = new DataBaseIP(st);
                        Console.WriteLine(">>Данные загружены из файла!\n");
                        SaveDataOnOS(db, st);
                        Console.WriteLine("Данные загружены в файл!");
                        //запустить чтение за файла и заполнение в местную бд
                        //запись данных в файл
                        break;
                    /*
                     custom:
                    --data-start - дата начала, если не задана data-end, то работает до сегодня
                    --data-end - дата конца
                    --read - чтение данных из файла
                    --default - стандартные настройки
                    --show - показать текущие настройки                    
                    --save - сохранить настройку
                    --help - вывод всех команд                  
                    --load - загрузить параметры из файла
                    --clear-db - очистка бд
                     */
                    default:
                        Console.WriteLine("Вы ввели не верную команду в случае проблем воспользуетесь командой help");
                     break;  
                }
            }            
        }
        private void Help() 
        {
            Console.WriteLine(
                "file-log: выводит путь к файлу с логами \n" +
                "file-output: путь к файлу с результатом \n" +
                "address-start: нижняя граница диапазона адресов, необязательный параметр, по умолчанию обрабатываются все адреса \n" +
                "address-mask: маска подсети, задающая верхнюю границу диапазона десятичное число.Необязательный параметр в случае, если он не указан, обрабатываются все адреса, начиная с нижней границы диапазона.Параметр нельзя использовать, если не задан address-start. \n" +
                "start - начать обработку\n" +
                "exit - выйти из приложения\n" +
                "cls - очистка экрана от лишнего\n" +
                "help: вывод всех команд \n" +
                "TODO:\n" +
                "data-start - дата начала, если не задана \n" +
                "data-end, то работает до сегодня\n" +
                "data-end - дата конца\n" +
                "read - чтение данных из файла\n" +
                "default - стандартные настройки\n" +
                "show - показать текущие настройки\n" +           
                "save - сохранить настройку\n" +
                "clear-db - очистка бд \n" +
                "load - загрузить параметры из файла\n"
                            );     
        }
        private void SaveDataOnOS(DataBaseIP db, Setting st)
        {
            string path = st.PathOutputFile + @"\test.txt";
            Console.WriteLine(path);
            string text;
            List<string> keyList = db.GetKeys();
            foreach (string key in keyList) 
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(key + " - " + db.GetData(key).Count());
                }

            }            
        }
    }
}
