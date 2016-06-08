using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Fluent;
using System.IO;
using System.Reflection;
using System.Xml;
using crayfire;

/*
CHANGELOG

    27.09.15. - TM - StatusBar Überarbeitet. (Skalierung und Verhältnisse angepasst)
                   - ProgressBar zur StatusBar hinzugefügt

TO-DO

    - ballonTip fürs Errors als Debug ( Title: Error bei Application Error : Details Short Error Message) -  VERTAGT

    */


namespace Gutachten_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        // Variablen Definition
        XMLFiles XMLFiles = new XMLFiles();
        Tabs Tabs = new Tabs();
        Errors Errors = new Errors();
        MSSQL MSSQL = new MSSQL();
        MySQL MySQL = new MySQL();

        private Thread trd;

        public MainWindow()
        {
            new crayfire.crayfire();
            //crayfire.crayfire.getDB();
            InitializeComponent();
            /// Fenster Maximiert starten lassen...
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            if (!XMLFiles.XML()) { XMLFiles.CreateXML(); }
            try
            {
                MySQL.OpenConnection();
                StatusBar_Right_User.Text = "Angemeldet als : " + Environment.UserName.ToString() + " | ";
                StatusBar_Right_Server.Text = "Server: " + MySQL.getServer() + " | ";
                StatusBar_Right_DB.Text = "DB : " + MySQL.getDatabase();
            }
                catch (Exception ex) { Errors.WriteToLog(ex); Errors.SetStatusbar(); }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySQL.CloseConnection();
            }
            catch (Exception Ex)
            {
                Errors.WriteToLog(Ex);
            }
                this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Klick_Click(object sender, RoutedEventArgs e)
        {
            Statusbar_Left.Text = "Gutachten - PHV503 - B-QA164";
        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            TabItem tempTab = new TabItem();
            tempTab = newTab();
            MainTabControl.Items.Add(tempTab);
            MainTabControl.SelectedItem = tempTab;
            
        }
        private TabItem newTab()
        {
            Random Rnd = new Random();
            int RndNr1 = Rnd.Next(9999);
            TabItem neuerTab = new TabItem();
            neuerTab.Name = "Tab" + RndNr1.ToString();
            neuerTab.Header = "Tab" + RndNr1.ToString();
            return neuerTab;
        }

        private void Visible_Click(object sender, RoutedEventArgs e)
        {
            if (PHV503.IsVisible)
            {
                PHV503.Visibility = System.Windows.Visibility.Hidden;
                MainTabControl.SelectedItem = Home;
            }

            else
            {
                PHV503.Visibility = System.Windows.Visibility.Visible;
                MainTabControl.SelectedItem = PHV503;
            }
        }

        private void Btn_CreateXML_Click(object sender, RoutedEventArgs e)
        {
           /// MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\Blubber\\" );
            XMLFiles.CreateXML();
        }

        private void Btn_LoadXML_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\TabConfig.xml"))
            {
                try {
                    XmlDocument TabConfig = new XmlDocument();
                    var Pfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\TabConfig2.xml";
                    TabConfig.Load(Pfad);
                    //Root Knoten in ein XmlElement laden
                    XmlElement root = TabConfig.DocumentElement;
                    //Für jedes XML Element aus dem Root Knoten die Schleife ausführen
                    foreach (XmlNode First in root.ChildNodes)
                    {
                      //  Console.WriteLine(TabConfiguration.Attributes["First"].InnerText);  //Wert des Attributs "Name" auf der Konsole ausgeben
                      //  Console.WriteLine(TabConfiguration.Attributes["Second"].InnerText);    //Wert des Attributs "ID" auf der Konsole ausgeben
                        MessageBox.Show(First.InnerText);                     //Text des Unterknotens auf der Konsole ausgeben
                    }
                }
                catch (Exception ex) { Errors.WriteToLog(ex);}
            }
            else
            {
                XMLFiles.CreateXML();
            }
        }

        private void ThreadTask()
        {
            ProgressBar_Left.Value = 0;
            while (ProgressBar_Left.Value < 100)
            {
                ProgressBar_Left.Value = ProgressBar_Left.Value + 1;
                System.Threading.Thread.Sleep(100);
            }
           
            
        }

        private void Btn_ErrorTest_Click(object sender, RoutedEventArgs e)
        {
            // Worker workerObject = new Worker();

            // Den Thread 'trd' initialisieren mit der Methode 'ThreadTask'
            // Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            // Thread ist ein Hintergrund Thread
            //  trd.IsBackground = true;
            // Thread starten
            // trd.Start();

            // Thread workerThread = new Thread(workerObject.DoWork);
            Statusbar_Left.InvalidateVisual();
            string temp = Statusbar_Left.Text.ToString();
            Errors.Debug_WritetoLog("Error 2 - Errortest");
            Statusbar_Left.Text = "Fehler - Errortest" + Statusbar_Left.Text.ToString();
            Statusbar_Left.InvalidateVisual();
            Statusbar_Left.UpdateLayout();
           // System.Threading.Thread.Sleep(5000);
           // Statusbar_Left.Text = temp;

         
        }
    }
}
