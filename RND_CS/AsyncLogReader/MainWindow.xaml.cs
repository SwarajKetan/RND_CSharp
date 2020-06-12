using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncLogReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Log
        {
            public string Text { get; set; }
        }

        private FileSystemWatcher fso =
            new FileSystemWatcher(@"C:\dev\GitHub\Source\Repos\RND_CSharp\RND_CS\ProgramRunner\bin\Debug\netcoreapp3.1\", "*.log");

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            HandleFso_Changed();

            fso.EnableRaisingEvents = true;
            fso.Changed += Fso_Changed;

        }

        private volatile bool Reading = false;
        private volatile int LastReadIndex = -1;

        private void Fso_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                HandleFso_Changed();
            }
        }

        private void HandleFso_Changed()
        {
            if (!Reading)
            {
                lock (this)
                {
                    if (Reading) return;

                    Reading = true;
                    int i = 0;
                    using (System.IO.StreamReader file = new StreamReader(Path))
                    {
                        string line = string.Empty;
                        while ((line = file.ReadLine()) != null)
                        {
                            if (i++ <= LastReadIndex)
                            {
                                Debug.WriteLine($"##### Continue : i = {i - 1}, LastReadIndex = {LastReadIndex}");
                                continue;
                            }
                            Dispatcher.Invoke(() => Logs.Add(new Log { Text = line }));
                        }
                    }
                    LastReadIndex = i;
                    Reading = false; 
                }
            }
        }

        private ObservableCollection<Log> logs = new ObservableCollection<Log>();

        public ObservableCollection<Log> Logs
        {
            get { return logs; }
            set { logs = value; }
        }


        private static string Path = @"C:\dev\GitHub\Source\Repos\RND_CSharp\RND_CS\ProgramRunner\bin\Debug\netcoreapp3.1\hub.log";
    }
}
