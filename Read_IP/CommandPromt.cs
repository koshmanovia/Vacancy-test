using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Read_IP
{
    /*!!! TODO:
     * 
     * Их мы ловим и выводим 
     * ArgumentException - DataBaseIP - не подходит формат IP 
     *                   - не корректная маска
     * FileNotFoundException - Setting - не найден конфигурациооный файл 
     *                       - GetRangeAddressesByMask - не верно введен IP
     * 
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
                switch (s.ToLower())
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
                        if(st.StartIp == "0.0.0.0") 
                        {
                            Console.WriteLine("не задан стартовый параметр IP адреса. Задайте IP адрес и повторите попытку");
                            break;
                        }
                        Console.WriteLine(st.Mask);
                        break;
                    case "help":
                        Help();
                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "exit" or "quit":
                        Environment.Exit(0) ; 
                        break;
                    case "start":
                        DataBaseIP db = new DataBaseIP(st);
                        Console.WriteLine(">>Данные загружены из файла!\n");
                        SaveDataOnOS(db, st);
                        Console.WriteLine("Данные загружены в файл!");
                        break;
                    case "clear":
                        db = new DataBaseIP();
                        Console.WriteLine("Создана пустая база Данных !!!!!Инструкция как заполнить нужна!!!");
                        break;
                    case "test":
                        DataBaseIP db1 = new DataBaseIP(st);
                        Test(CheckIP.GetRangeAddressesByMask("158.215.32.1", "24"), db1,st);
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
                "start: начать обработку\n" +
                "exit: выйти из приложения\n" +
                "quit: выйти из приложения\n" +
                "cls: очистка экрана от лишнего\n" +
                "help: вывод всех команд \n\n\n\n" +
                "TODO:\n" +
                "date-start - дата начала, если не задана \n" +
                "date-end, то работает до сегодня\n" +
                "date-end - дата конца\n" +
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
            string path = st.PathOutputFile + $"\\{DateTime.Now}".ToString().Replace(' ', '_').Replace(':', '-').Replace('.', '-') + ".txt";            
            Console.WriteLine(path);
            List<string> keyList = db.GetKeys();            
            if (!File.Exists(path))
            { 
                File.Create(path).Close();
               
            }
            foreach (string key in keyList) 
            {          
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(key + " - " + db.GetData(key).Count());
                }
            }            
        }
        public void Test(string between, DataBaseIP db, Setting st)
        {
            string saveNameFile = st.PathOutputFile + $"\\{DateTime.Now}".ToString().Replace(' ', '_').Replace(':', '-').Replace('.', '-') + ".txt";
            List<string> keyList = db.GetKeys();
            string[] rangeStr =  between.Split(new char[] { '.' });
            int[] rangeInt = new int[rangeStr.Length];
            for (int i = 0; i < rangeStr.Length; i++)
            {
                rangeInt[i] = int.Parse(rangeStr[i]);
                Console.Write(rangeInt[i] + ".");
            }
            if (rangeInt[0] != rangeInt[4])
            {
                for (int i = rangeInt[0]; i <= rangeInt[4]; i++) //первый актет
                {
                    for (int j =0; j < 256 ; j++ )//второй актет
                    {
                        for (int k =0 ;k < 256; k++ )//третий актет
                        {
                            for (int h = 0; h < 256; h++ )//четвертый актет
                            {
                                db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                            }
                        }
                    }
                }

            }
            else if (rangeInt[1] != rangeInt[5])
            {
                Console.WriteLine("TO DO1");
            }
            else if (rangeInt[2] != rangeInt[6])
            {
                Console.WriteLine("TO DO2");
            }
            else if (rangeInt[3] != rangeInt[7])
            {
                for (int i = rangeInt[3]; i < rangeInt[7]; i++)//четвертый актет
                {
                    if (db.Data.ContainsKey($"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i}"))
                    {
                        SaveOneIPForFile(saveNameFile, $"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i} - " +
                                                       $"{db.Data[$"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i}"].Count}");
                        Console.WriteLine($"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i} - " +
                                                       $"{db.Data[$"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i}"].Count}");
                    }
                }
            }
            else if (rangeInt[3] == rangeInt[7])
            {
                Console.WriteLine("TO DO4");
            }


            //если 0 и 4 не равны
            //запускаем 4 цикла 1 основной 3 вложенных
            //сравниваем с ключом в бд, если да, записываем идем пока не станет равным с 1 до 5

            //2 и 6 тож самое

            //3 и 7

            //8 и 4


        }


        public void SaveOneIPForFile(string path, string data)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();

            }            
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(data);
            }            
        }
          
    }
}
