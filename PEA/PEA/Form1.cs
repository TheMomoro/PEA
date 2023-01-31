using PEA.Windows.AppSettings;
using System.Diagnostics;
using System.Text;

namespace PEA
{
    public partial class Form1 : Form
    {
        public ROM rom;
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GameBoy Advance ROM (*.gba)|*.gba|GameBoy Advance Binary ROM (*.bin)|*.bin";
            ofd.Title = "Open a GameBoy Advance ROM";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                /* This line is for a possible future update. */
                //File.WriteAllBytes("Dependencies/current.gba", File.ReadAllBytes(ofd.FileName));
                string name;
                string gameCode;
                string path;
                using (BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName)))
                {
                    br.BaseStream.Seek(0xAC, SeekOrigin.Begin);
                    gameCode = Encoding.UTF8.GetString(br.ReadBytes(4));
                    if (gameCode == "BPRE")
                    {
                        name = "Pokémon FireRed (English)";
                    }
                    else
                    {
                        name = "";
                    }
                    path = ofd.FileName;
                    br.Dispose();
                    br.Close();
                }
                rom = new ROM(gameCode, name, path);
                GBA.CreateBackup(rom);
                rom.InitializeDictionary();
                MessageBox.Show(GBA.ToText(GBA.ReadHEX(rom, "0x1C5C78", 4), rom.table));
            }
        }

        private void saverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom != null)
            {
                if (File.Exists(rom.fullPath))
                {
                    File.WriteAllBytes(rom.fullPath, File.ReadAllBytes("Dependencies/current.gba"));
                }
                else
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();
            appSettings.ShowDialog();
        }
    }
}