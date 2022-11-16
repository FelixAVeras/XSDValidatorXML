using System.Xml;
using System.Xml.Schema;

internal class Program
{
    private static void Main(string[] args)
    {
        XmlSchemaSet schema = new XmlSchemaSet();
        schema.Add("", @"Ruta del archivo XSD");

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas = schema;
        settings.ValidationEventHandler += ValidationEventHandler;

        XmlReader reader = XmlReader.Create(@"Ruta del archivo XML", settings);

        while (reader.Read()) ;
    }

    static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        Console.WriteLine($"Error de Validacion:\n {e.Message}");
    }
}