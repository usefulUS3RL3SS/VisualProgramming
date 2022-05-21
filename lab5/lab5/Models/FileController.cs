using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace lab_5.Models
{
    public class FileController
    {
        public void write(string data, string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(data);
            }
        }

        public string read(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
