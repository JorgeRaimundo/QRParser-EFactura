// See https://aka.ms/new-console-template for more information

using System.Globalization;
using QRParser_EFactura;

const string InputFile = "in.txt";
const string OutputFile = "out.json";


Dictionary<string,CodeElement> CodeElements = new() {
    {"A", new CodeElement("NIF do emitente", 9)},
    {"B", new CodeElement("NIF do adquirente", 30)},
    {"C", new CodeElement("País do adquirente", 12)},
    {"D", new CodeElement("Tipo de documento", 2)},
    {"E", new CodeElement("Estado do documento", 1)},
    {"F", new CodeElement("Data do documento", 8)},
    {"G", new CodeElement("Identificação única do documento (nº. da factura)", 60)},
    {"H", new CodeElement("ATCUD", 70)},
    {"I1", new CodeElement("Espaço fiscal", 5)},
    {"I2", new CodeElement("Base tributável isenta de IVA", 16)},
    {"I3", new CodeElement("Base tributável de IVA à taxa reduzida (6%)", 16)},
    {"I4", new CodeElement("Total de IVA à taxa reduzida (6%)", 16)},
    {"I5", new CodeElement("Base tributável de IVA à taxa intermédia (13%)", 16)},
    {"I6", new CodeElement("Total de IVA à taxa intermédia (13%)", 16)},
    {"I7", new CodeElement("Base tributável de IVA à taxa normal (23%)", 16)},
    {"I8", new CodeElement("Total de IVA à taxa normal (23%)", 16)},
    {"J1", new CodeElement("Espaço fiscal", 1)},
    {"J2", new CodeElement("Base tributável isenta de IVA", 16)},
    {"J3", new CodeElement("Base tributável de IVA à taxa reduzida", 16)},
    {"J4", new CodeElement("Total de IVA à taxa reduzida", 16)},
    {"J5", new CodeElement("Base tributável de IVA à taxa intermédia", 16)},
    {"J6", new CodeElement("Total de IVA à taxa intermédia", 16)},
    {"J7", new CodeElement("Base tributável de IVA à taxa normal", 16)},
    {"J8", new CodeElement("Total de IVA à taxa normal", 16)},
    {"K1", new CodeElement("Espaço fiscal", 1)},
    {"K2", new CodeElement("Base tributável isenta de IVA", 16)},
    {"K3", new CodeElement("Base tributável de IVA à taxa reduzida", 16)},
    {"K4", new CodeElement("Total de IVA à taxa reduzida", 16)},
    {"K5", new CodeElement("Base tributável de IVA à taxa intermédia", 16)},
    {"K6", new CodeElement("Total de IVA à taxa intermédia", 16)},
    {"K7", new CodeElement("Base tributável de IVA à taxa normal", 16)},
    {"K8", new CodeElement("Total de IVA à taxa normal", 16)},
    {"L", new CodeElement("Não sujeito / não tributável em IVA", 16)},
    {"M", new CodeElement("Imposto do Selo", 16)},
    {"N", new CodeElement("Total de impostos", 16)},
    {"O", new CodeElement("Total do documento com impostos", 16)},
    {"P", new CodeElement("Retenções na fonte", 16)},
    {"Q", new CodeElement("Código de Controlo", 4)},
    {"R", new CodeElement("Número do Certificado", 4)},
    {"S", new CodeElement("Outras informações", 65)}
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
        var key = elementParts[0];
        var data = elementParts[1];
        var codeElement = CodeElements[key];

        if (data.Length > codeElement.maxSize) {
            throw new Exception($"O campo {key} ({codeElement.description}) ultrapassa o limite máximo de caracteres ({codeElement.maxSize}): {data}");
        }

        if (key == "F") 
        {
            data = DateTime.ParseExact(data,"yyyyMMdd", CultureInfo.CurrentCulture).ToShortDateString();
        }
        Console.WriteLine($"{codeElement.description}: {data}");
    }
}
