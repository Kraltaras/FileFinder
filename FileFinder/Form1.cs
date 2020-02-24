using Microsoft.VisualStudio.Workspace;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileFinder
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer aTimer;
        DateTime timerStart;
        TimeSpan timerElapsed;
        
        private bool loading;
        PauseTokenSource myPause;
        private bool paused;
        private bool cancelled;
        CancellationTokenSource myCancel;

        public int fileAdded;
        public int fileChecked;

        public MainForm()
        {
            InitializeComponent();
            loading = false;
            myPause = new PauseTokenSource();
            myCancel = new CancellationTokenSource();
            EnableForm(true);
            cancelled = true;
            if(File.Exists("savingproperties.dat"))
            {
                LoadData();
            }
        }

        public void SaveData()
        {
            if (!loading)
            {
                using (FileStream output = File.Create("savingproperties.dat"))
                {
                    using (BinaryWriter writer = new BinaryWriter(output))
                    {
                        writer.Write(textAddress.Text);
                        writer.Write(textFileName.Text);
                        writer.Write(textSymbols.Text);
                    }
                }
            }
        }

        public void LoadData()
        {
            loading = true;
            using (FileStream input = File.OpenRead("savingproperties.dat"))
            {
                using (BinaryReader reader = new BinaryReader(input))
                {
                    textAddress.Text = reader.ReadString();
                    textFileName.Text = reader.ReadString();
                    textSymbols.Text = reader.ReadString();
                }
            }
            loading = false;
        }

        private async void FindFiles()
        {
            EnableForm(false);
            SetTimer();
            paused = false;
            cancelled = false;
            myCancel = new CancellationTokenSource();
            treeViewFiles.Nodes.Clear();
            fileAdded = 0;
            fileChecked = 0;
            string address = textAddress.Text;
            string fileName = textFileName.Text;
            string symbols = textSymbols.Text;

            var progressFileName = new Progress<string>(s => labelFound.Text = s);
            var progressCurrentFile = new Progress<string>(s => labelCurrentFile.Text = s);
            var progressPopulate = new Progress<string>(s => PopulateTreeView(s, '\\'));

            await Task.Run(() =>
            {
                CheckFile(address, fileName, symbols, progressFileName, progressCurrentFile, progressPopulate, myPause.Token, myCancel.Token).Wait();
            });

            aTimer.Stop();
            EnableForm(true);
            paused = false;
            cancelled = true;
            buttonSearch.Text = "Искать";
            buttonPause.Text = "Пауза";
            myCancel.Dispose();
        }

        private void EnableForm(bool check)
        {
            textFileName.Enabled = check;
            textSymbols.Enabled = check;
            buttonChangeAddress.Enabled = check;
            paused = check;
            buttonPause.Enabled = !check;
        }

        private async Task CheckFile(string address, string fileName, string symbols, IProgress<string> progressFileName, IProgress<string> progressCurFile, IProgress<string> progressPopulate, PauseToken pauseToken, CancellationToken cancelToken)
        {
            foreach (var oneFile in Directory.GetFiles(address, "*", SearchOption.AllDirectories))
            {
                await pauseToken.WaitWhilePausedAsync();
                if (oneFile != null)
                {
                    progressCurFile.Report("Текущий файл: " + oneFile);
                    fileChecked++;
                    if (Path.GetFileName(oneFile).Contains(fileName) && File.ReadAllText(oneFile).Contains(symbols))
                    {
                        progressPopulate.Report(oneFile);
                        fileAdded++;
                    }
                    progressFileName.Report("Файлов обработано:" + fileChecked + "; Файлов найдено: " + fileAdded);
                }
                if(cancelToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            SaveData();
        }

        private void textFileName_TextChanged(object sender, EventArgs e)
        {
            SaveData();
        }

        private void textSymbols_TextChanged(object sender, EventArgs e)
        {
            SaveData();
        }

        private void buttonChangeAddress_Click(object sender, EventArgs e)
        {
            folderAddress.SelectedPath = textAddress.Text;
            DialogResult result = folderAddress.ShowDialog();
            if(result == DialogResult.OK)
            {
                textAddress.Text = folderAddress.SelectedPath;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (cancelled)
            {
                buttonSearch.Text = "Стоп";
                cancelled = false;
                FindFiles();
            }
            else
            {
                buttonSearch.Text = "Искать";
                myCancel.Cancel();
                buttonPause.PerformClick();
                cancelled = true;
            }
        }

        private void PopulateTreeView(string path, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAg = string.Empty;
            foreach(string subPath in path.Split(pathSeparator))
            {
                subPathAg += subPath + pathSeparator;
                TreeNode[] nodes = treeViewFiles.Nodes.Find(subPathAg, true);
                if(nodes.Length == 0)
                {
                    if(lastNode == null)
                    {
                        lastNode = treeViewFiles.Nodes.Add(subPathAg, subPath);
                    }
                    else
                    {
                        lastNode = lastNode.Nodes.Add(subPathAg, subPath);
                    }
                }
                else
                {
                    lastNode = nodes[0];
                }
            }
        }

        void SetTimer()
        {
            aTimer = new System.Windows.Forms.Timer();
            aTimer.Interval = 1;
            aTimer.Tick += new EventHandler(OnTimerTick);
            aTimer.Enabled = true;
            timerStart = DateTime.Now;
            timerElapsed = TimeSpan.Zero;
            aTimer.Start();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            TimeSpan currentElapsed = DateTime.Now - timerStart;
            TimeSpan elapsed = currentElapsed + timerElapsed;
            labelTime.Text = "Время с запуска поиска: " + elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        void OnTimerPause()
        {
            aTimer.Stop();
            TimeSpan currentElapsed = DateTime.Now - timerStart;
            timerElapsed += currentElapsed;
        }

        void OnTimerResume()
        {
            timerStart = DateTime.Now;
            aTimer.Start();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                buttonPause.Text = "Возобновить";
                myPause.Pause();
                paused = true;
                OnTimerPause();
            }
            else
            {
                buttonPause.Text = "Пауза";
                myPause.Resume();
                paused = false;
                OnTimerResume();
            }
        }
    }
}
