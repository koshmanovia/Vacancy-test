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
    internal class CommandPromt
    {
        string s;
        public void EnterCommand()
        {
            Setting st = new Setting();
            while (true)
            {
                Console.Write("Введите команду: ");
                try
                {
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
                            Console.Write("Введите новый IP адрес: ");
                            st.StartIp = Console.ReadLine();
                            Console.WriteLine(st.StartIp);
                            break;
                        case "address-mask":
                            if (st.StartIp == "0.0.0.0")
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
                            Environment.Exit(0);
                            break;
                        case "start":
                            DataBaseIP db = new DataBaseIP(st);
                            Console.WriteLine(">>Данные загружены из файла!\n");
                            if (st.StartIp == "0.0.0.0" && st.Mask == "0")
                            {
                                SaveDataOnOS(db, st);
                            }
                            else if (st.Mask != "0")
                            {
                                SaveDataOnOS(CheckIP.GetRangeAddressesByMask(st.StartIp, st.Mask), db, st);
                            }
                            else 
                            {
                                SaveDataOnOSZeroMask(db, st);//В разработке
                            }
                            Console.WriteLine("Данные загружены в файл!");
                            break;
                        case "clear":
                            db = new DataBaseIP();
                            Console.WriteLine("Создана пустая база Данных !!!!!Инструкция как заполнить нужна!!!");
                            break;
                        case "test":
                            DataBaseIP db1 = new DataBaseIP(st);
                            st.StartIp = "5.255.250.10";
                            SaveDataOnOSZeroMask(db1, st);
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FileNotFoundException ex) 
                {
                    Console.WriteLine(ex.Message);
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
        private void SaveDataOnOS(string between, DataBaseIP db, Setting st)
        {
            string saveNameFile = st.PathOutputFile + $"\\{DateTime.Now}".ToString().Replace(' ', '_').Replace(':', '-').Replace('.', '-') + ".txt";
            string[] rangeStr =  between.Split(new char[] { '.' });
            int[] rangeInt = new int[rangeStr.Length];
            for (int i = 0; i < rangeStr.Length; i++)
            {
                rangeInt[i] = int.Parse(rangeStr[i]);               
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
                                if (db.Data.ContainsKey($"{i}.{j}.{k}.{h}"))
                                {
                                    SaveOneIPForFile(saveNameFile, $"{i}.{j}.{k}.{h} - " +
                                                      $"{db.Data[$"{i}.{j}.{k}.{h}"].Count}");
                                    db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                                }
                            }
                        }
                    }
                }

            }
            else if (rangeInt[1] != rangeInt[5])
            {
                for (int i = rangeInt[1]; i <= rangeInt[5]; i++) //первый актет
                {
                    for (int j = 0; j < 256; j++)//второй актет
                    {
                        for (int k = 0; k < 256; k++)//третий актет
                        {
                            if (db.Data.ContainsKey($"{rangeInt[0]}.{i}.{j}.{k}"))
                            {
                                SaveOneIPForFile(saveNameFile, $"{rangeInt[0]}.{i}.{j}.{k} - " +
                                                      $"{db.Data[$"{rangeInt[0]}.{i}.{j}.{k}"].Count}");
                                db.Data.ContainsKey($"{rangeInt[0]}.{i}.{j}.{k}");
                            }
                        }
                    }
                }
            }
            else if (rangeInt[2] != rangeInt[6])
            {
                for (int i = rangeInt[1]; i <= rangeInt[5]; i++) //первый актет
                {
                    for (int j = 0; j < 256; j++)//второй актет
                    {
                        if (db.Data.ContainsKey($"{rangeInt[0]}.{rangeInt[1]}.{i}.{j}"))
                        {
                            SaveOneIPForFile(saveNameFile, $"{rangeInt[0]}.{rangeInt[1]}.{i}.{j} - " +
                                                    $"{db.Data[$"{rangeInt[0]}.{rangeInt[1]}.{i}.{j}"].Count}");                           
                        }
                    }
                }
            }
            else if (rangeInt[3] != rangeInt[7])
            {
                for (int i = rangeInt[3]; i < rangeInt[7]; i++)//четвертый актет
                {
                    if (db.Data.ContainsKey($"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i}"))
                    {
                        SaveOneIPForFile(saveNameFile, $"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i} - " +
                                                       $"{db.Data[$"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{i}"].Count}");                        
                    }
                }
            }
            else if (rangeInt[3] == rangeInt[7])
            {                
                if (db.Data.ContainsKey($"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{rangeInt[3]}"))
                {                    
                    SaveOneIPForFile(saveNameFile, $"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{rangeInt[3]} - " +
                                                    $"{db.Data[$"{rangeInt[0]}.{rangeInt[1]}.{rangeInt[2]}.{rangeInt[3]}"].Count}");                    
                }
            }
        }

        private void SaveDataOnOSZeroMask(DataBaseIP db, Setting st)
        {
            string saveNameFile = st.PathOutputFile + $"\\{DateTime.Now}".ToString().Replace(' ', '_').Replace(':', '-').Replace('.', '-') + ".txt";
            string[] rangeStr = st.StartIp.Split(new char[] { '.' });
            int[] rangeInt = new int[rangeStr.Length];
            for (int i = 0; i < rangeStr.Length; i++)
            {
                rangeInt[i] = int.Parse(rangeStr[i]);
            }
            for (int i = rangeInt[0]; i < 256; i++) 
            {
                if (i == rangeInt[0])
                {
                    for (int j = rangeInt[1]; j < 256; j++)
                    {
                        if (j == rangeInt[1])
                        {
                            for (int k = rangeInt[2]; k < 256; k++)
                            {
                                if (k == rangeInt[2]) 
                                {
                                    for (int h = rangeInt[3]; h < 256; h++)
                                    {
                                        if (db.Data.ContainsKey($"{i}.{j}.{k}.{h}"))
                                        {
                                            SaveOneIPForFile(saveNameFile, $"{i}.{j}.{k}.{h} - " +
                                                                $"{db.Data[$"{i}.{j}.{k}.{h}"].Count}");
                                            db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                                        }
                                    }
                                }
                                else 
                                {
                                    for (int h = 0; h < 256; h++)
                                    {
                                        if (db.Data.ContainsKey($"{i}.{j}.{k}.{h}"))
                                        {
                                            SaveOneIPForFile(saveNameFile, $"{i}.{j}.{k}.{h} - " +
                                                                $"{db.Data[$"{i}.{j}.{k}.{h}"].Count}");
                                            db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                                        }
                                    }
                                }
                                
                            }
                        }
                        else 
                        {
                            for (int k = 0; k < 256; k++)
                            {
                                for (int h = 0; h < 256; h++)
                                {
                                    if (db.Data.ContainsKey($"{i}.{j}.{k}.{h}"))
                                    {
                                        SaveOneIPForFile(saveNameFile, $"{i}.{j}.{k}.{h} - " +
                                                            $"{db.Data[$"{i}.{j}.{k}.{h}"].Count}");
                                        db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < 256; j++)
                    {
                        for (int k = 0; k < 256; k++)
                        {
                            for (int h = 0; h < 256; h++)
                            {
                                if (db.Data.ContainsKey($"{i}.{j}.{k}.{h}"))
                                {
                                    SaveOneIPForFile(saveNameFile, $"{i}.{j}.{k}.{h} - " +
                                                        $"{db.Data[$"{i}.{j}.{k}.{h}"].Count}");
                                    db.Data.ContainsKey($"{i}.{j}.{k}.{h}");
                                }
                            }
                        }
                    }

                }


            }
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
