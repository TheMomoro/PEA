using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PEA
{
    public class ROM
    {
        public string code;
        public string name;
        public string fullPath;

        public Dictionary<string, string> table;

        public ROM(string _code, string _name, string _path)
        {
            code = _code;
            name = _name;
            fullPath = _path;
        }

        public void InitializeDictionary()
        {
            table = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines("Ini/textvalues.txt");
            foreach (string str in lines)
            {
                table.Add(str.Split('=')[0], str.Split('=')[1]);
            }
        }

        public void Save()
        {
            Action:
            if (File.Exists(fullPath))
            {
                
            }
            else
            {
                DialogResult dr = MessageBox.Show("ROM not found at " + fullPath, "File Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    goto Action;
                }
            }
        }
        public void Save(string path)
        {
        Action:
            if (File.Exists(path))
            {

            }
            else
            {
                DialogResult dr = MessageBox.Show("ROM not found at " + path, "File Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    goto Action;
                }
            }
        }
        public void Load()
        {
            Action:
            if (File.Exists(fullPath))
            {

            }
            else
            {
                DialogResult dr = MessageBox.Show("ROM not found at " + fullPath, "File Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    goto Action;
                }
            }
        }
        public void Load(string path)
        {
            Action:
            if (File.Exists(path))
            {

            }
            else
            {
                DialogResult dr = MessageBox.Show("ROM not found at " + path, "File Not Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    goto Action;
                }
            }
        }
    }
}