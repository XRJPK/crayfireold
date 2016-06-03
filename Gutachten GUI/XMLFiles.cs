using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace Gutachten_GUI
{
    class XMLFiles
    {
        Errors Erros = new Errors();
        public bool XML() {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\TabConfig.xml")) { return true; }
            else { return false; }
        }
        public void CreateXML()
        {
            bool FolderExist = false;
            bool FileExist = false;

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\"))
            {
                FolderExist = true;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\TabConfig.xml")) { FileExist = true; }
                else
                {
                    try
                    {
                        XmlDocument TabConfig = new XmlDocument();
                        XmlNode myRoot, myNode;
                        // XmlAttribute myAttribute;

                        //Root Element einfügen
                        myRoot = TabConfig.CreateElement("TabConfiguration");
                        TabConfig.AppendChild(myRoot);

                        myNode = TabConfig.CreateElement("First");               //Unterknoten einfügen
                        myNode.InnerText = "PHV503";                         //Text in den Knoten laden

                        //Unterknoten an Root Knoten anhängen
                        myRoot.AppendChild(myNode);
                        //Das ganze in 2 Zeilen
                        myRoot.AppendChild(TabConfig.CreateElement("Second")).InnerText = "PHV504";

                        //XML Dokument speichern
                        TabConfig.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\TabConfig.xml");
                    }
                    catch (Exception e) { Erros.WriteToLog(e); }
                }
            }
            else
            {
                try { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\"); }
                catch (Exception e) { Erros.WriteToLog(e); }
            }
        }

        public void LoadXML() { }

        public void Test() { }


    }
}
