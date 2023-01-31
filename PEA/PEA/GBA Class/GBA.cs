using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static System.Windows.Forms.AxHost;
using System.Globalization;

namespace PEA
{
    public static class GBA
    {
        public static string ToText(string hex, Dictionary<string, string> textValues)
        {
            string _text = "";
            for (int i = 0; i < hex.Length; i += 2)
            {
                string key = "";
                key += hex[i];
                key += hex[i + 1];
                string text = "";
                textValues.TryGetValue(key, out text);
                _text += text;
            }
            return _text;
        }
        public static string ReadHEX(ROM rom, string offset, int length)
        {
            byte bytHex;
            string sHex = "";
            int i;
            long start = Int32.Parse(((offset.Replace("0x",""))), NumberStyles.HexNumber);
            var l = File.ReadAllBytes(rom.fullPath).Length;
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(rom.fullPath, FileMode.Open)))
                {
                    reader.BaseStream.Seek(start, SeekOrigin.Begin);
                    bool endofoffset = false;
                    for (i = 0; endofoffset == false; i++)
                    {
                        bytHex = reader.ReadByte();

                        if (bytHex.ToString("X2") != "FF")
                        {
                            sHex += bytHex.ToString("X2");
                        }
                        else
                        {
                            endofoffset = true;
                            break;
                        }
                    }
                    reader.Dispose();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
            return sHex;
        }
        public static void CreateBackup(ROM rom)
        {
            Action:
            bool success = false;
            for (int i = 0; success == false; i++)
            {
                var path = rom.fullPath.Replace(Path.GetFileName(rom.fullPath), "") + Path.GetFileNameWithoutExtension(rom.fullPath) + " " + i + Path.GetExtension(rom.fullPath);
                if (!File.Exists(path))
                {
                    File.Copy(rom.fullPath, path);
                    success = true;
                    break;
                }
            }
        }
    }
}