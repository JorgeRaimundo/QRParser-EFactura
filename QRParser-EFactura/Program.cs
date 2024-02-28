// See https://aka.ms/new-console-template for more information

const string InputFile = "in.txt";
const string OutputFile = "out.json";

Dictionary<string,string> ElementNames = new() {
    {"A", "Emitente"},
    {"B", "Adquirente"},
    {"C", "País"},
    {"D", "Tipo de factura"},
    {"E", "Estado da factura (?)"},
    {"F", "Data da factura"},
    {"G", "Número da factura"},
    {"H", "ATCUD"},
    {"I1", "Região do Imposto"},
    {"I2", "Isento(?)"},
    {"I3", "Base tributável 6%"},
    {"I4", "IVA 6%"},
    {"I5", "Base tributável 13%"},
    {"I6", "IVA 13%"},
    {"I7", "Base tributável 23%"},
    {"I8", "IVA 23%"},
    {"J", "J ???"},
    {"K", "K ???"},
    {"L", "Valor isento"},
    {"M", "Não tributável(?)"},
    {"N", "IVA total"},
    {"O", "Total"},
    {"P", "Imposto de selo(?)"},
    {"Q", "Código Controlo"},
    {"R", "Número de Certificado"},
    {"S", "S ???"},
};

if (!File.Exists(InputFile)) {
    Console.WriteLine("The input file 'in.txt' does not exist");
    return;
}

var fileLines = File.ReadAllLines(InputFile).ToList();

foreach (var line in fileLines)
{
    List<string> elements = [.. line.Split('*')];

    foreach (var element in elements)
    {
        List<string> elementParts = [.. element.Split(':')];
        Console.WriteLine($"{ElementNames[elementParts[0]]}: {elementParts[1]}");
    }
}
