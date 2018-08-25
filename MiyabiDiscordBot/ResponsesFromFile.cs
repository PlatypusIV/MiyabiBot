using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MiyabiDiscordBot
{
    class ResponsesFromFile
    {

        const string dirName = "responsesEdit";
        const string fileName = "responses.json";
        string wholePath = $"{dirName}\\{fileName}";

        public ResponsesFromFile()
        {
            makeFileIfNeeded();
        }


        void makeFileIfNeeded()
        {

            //wholePath = $"{dirName}\\{fileName}";

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            if (!File.Exists(wholePath))
            {
                File.Exists(wholePath);
            }


        }

        public bool checkForFile()
        {
            if (!File.Exists(wholePath))
            {
                return false;
            }
            return true;
        }

        void writeToFile(Dictionary<string,string[]> _dict)
        { 

            using (StreamWriter sw = new StreamWriter(wholePath))
            {
                string jsonToWrite = JsonConvert.SerializeObject(_dict, Formatting.Indented);
                sw.Write(jsonToWrite);
            }
        }

        Task writeToFileTask(Dictionary<string, string[]> dictTask)
        {
            return Task.Factory.StartNew(()=> writeToFile(dictTask));
        }

        public async void writeToFileAsync(Dictionary<string, string[]> dictAsync)
        {
            await writeToFileTask(dictAsync);
        }

        public Dictionary<string,string[]> readFromFileBase()
        {
            Dictionary<string, string[]> dictionaryToReturn = new Dictionary<string, string[]>();
            string jsonFromFile = "";

            using(StreamReader sr = new StreamReader(wholePath))
            {
                jsonFromFile = sr.ReadToEnd();
            }

            dictionaryToReturn = JsonConvert.DeserializeObject<Dictionary<string,string[]>>(jsonFromFile);

            return dictionaryToReturn;
        }

        public Task<Dictionary<string,string[]>> readFromFileTask()
        {
            return Task.Factory.StartNew(() => readFromFileBase());
        }







    }
}


