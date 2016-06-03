using System;

public class XMLFiles
{
    public XMLFiles()
    {
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
                    catch (Exception e) { MessageBox.Show(e.ToString()); }
                }
            }
            else
            {
                try { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\thobas\\"); }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
        }

    }
}
