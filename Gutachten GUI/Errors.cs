using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* CHANGELOG
   23.09.2015 - Version 0.1 - Initiale Version - T.M.   
   
   To - Do 
   - Von welchem User kam der Error? 

    */

/* USAGE
    25.12.2015
    
    try 
    catch (Exception ex) { Erros.WriteToLog(ex) 
*/
namespace Gutachten_GUI
{
    class Errors
    {
        //MainWindow MainWindow = new MainWindow();
        private static string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\thobas\\Logs\\";
        private static string LogFile = LogPath + "Erros.txt";

        public void WriteToLog(Exception ex)
        {         
            if (!Directory.Exists(LogPath))
            {
                try { Directory.CreateDirectory(LogPath); }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
            if ( !File.Exists(LogFile))
            {
                try { File.CreateText(LogFile); }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
            // Streamwriter schreibt mit True automatisch die Datei fort
            StreamWriter StreamWriter = new StreamWriter(LogFile, true);
            try { ex.ToString(); }
            catch (Exception e) { MessageBox.Show(e.ToString()); }

            try
            {
                StreamWriter.WriteLine(System.DateTime.Now.ToString() + "\t \t " + ex + " \n");
                StreamWriter.Close();
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }


        }

        public void Debug_WritetoLog(String ex)
        {
            /* WARNING : This Method is only used for Debugging purposes!!! it has NO ERROR Handlig !! 
               USE WITH CAUTION   -   USE WITH CAUTION  -  USE WITH CAUTION  -  USE WITH CAUTION
            */
            StreamWriter StreamWriter = new StreamWriter(LogFile, true);

            StreamWriter.WriteLine(System.DateTime.Now.ToString() + "\t \t " + ex + " \n ");
            StreamWriter.Close();
            
        }

        public void SetStatusbar()
            /*
             * 
             * This Method is used to write that an error ocured in the bottom Statusbar...  
             * 
             */
        {
            // MainWindow.Statusbar_Left.Text = "Die letzte Aktion konnte nicht erfolgreich abgeschlossen werden - Bitte prüfen Sie das Fehlerlog! ";
        }
    }
}
