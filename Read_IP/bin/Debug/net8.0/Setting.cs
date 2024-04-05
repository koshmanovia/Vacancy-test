using System.IO;

namespace Read_IP
{
    internal class Setting
    {
        private string _pathSettingFile = Environment.CurrentDirectory + @"\Data\defaultconfig"; 
        private string _pathLogFile = Environment.CurrentDirectory + @"\Data\LogIP.log";
        private string _pathOutputFile = Environment.CurrentDirectory + @"\Data\output";
        private string _startIp ="0.0.0.0";
        private string _mask = "0";


        //Дописать для каждого свойства обработку ошибок
        public string PathLogFile
        {           
            set { _pathLogFile = value; }
            get { return _pathLogFile; }
        }
        public string PathOutputFile 
        {
            set { _pathOutputFile = value; }
            get { return _pathOutputFile; }
        }
        public string StartIp 
        {
            set { _startIp = value; }
            get { return _startIp; }
        }

        //Обработка вводимых значений чтобы и 255.255.255.0 и 1-32 можно было
        public string Mask 
        {
            set { _mask = value; }
            get { return _mask; }
        }

        public Setting() 
        {
            //Load();
        }
        public Setting(string path)
        {
            if (File.Exists(path)) 
            {
                _pathSettingFile = path;
                Load();
            }
            else { throw new FileNotFoundException("Не найден конфигурационный файл"); }
        }

        //TODO
        public void Save() 
        { 
            
        }
        public  void Load() 
        {
            Console.WriteLine(_pathSettingFile);
            StreamReader sr = new StreamReader(_pathSettingFile);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
            }
            sr.Close();

        }
    }
}
