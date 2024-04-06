using System.Xml;
using System.Xml.Linq;
using static System.Console;

class TestResults
{
    public static XmlDocument doc;
    public static XmlElement root;

    public static void Open(string filePath)
    {
        doc.Load(filePath);
    }

    public static void Read(string nodeName)
    {
        XmlNodeList nodes = doc.SelectNodes($"//{nodeName}");
        foreach (XmlNode node in nodes)
        {
            WriteLine(node.InnerText);
        }
    }

    public static void WriteRoot()
    {
        // создание элемента - корневой
        root = doc.CreateElement("Root");
        doc.AppendChild(root);
    }

    public static void WriteChild(string name, string value)
    {
        // создание элемента - дочерний
        XmlElement child = doc.CreateElement(name);
        child.InnerText = value;
        root.AppendChild(child);
    }

    public static void DisplayDocument(string filePath)
    {
        doc.Load(filePath);
        XmlNodeList nodes = doc.SelectNodes("//node");
        foreach (XmlNode node in nodes)
        {
            WriteLine(node.InnerText);
        }
    }

    public static void CreateDocumentRoot()
    {
        // создание дока
        doc = new XmlDocument();
        // создание шапочки с информацией о документе
        XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(declaration);
        // создание элемента - корневой
        root = doc.CreateElement("Root");
        doc.AppendChild(root);
    }

    public static void CreateDocumentChild(string name, string value)
    {
        // создание элемента - дочерний
        XmlElement child = doc.CreateElement(name);
        child.InnerText = value;
        root.AppendChild(child);
    }
}

class Start
{
    public static void Main()
    {
        WriteLine("Option 1 - DisplayDocument(), other - CreateDocument()");
        int option = Read();

        if (option == 0)
        {
            Environment.Exit(0);
        }
        else if (option == 1)
        {
            string path = "E:\\c sharp for uni\\чистовики (код) ФИНАЛ\\СИ ШАРП 2-ой семестр\\Assignment 2\\sampleFolder\\as 2 ex 4\\XMLFile1.xml";
            TestResults.Open(path);
            TestResults.Read("test_results");
        }
        else
        {
            TestResults.WriteRoot();
            TestResults.WriteChild("name", "Neithan");
            TestResults.WriteChild("score", "5");
        }
    }
}