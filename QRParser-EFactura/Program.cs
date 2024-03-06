// See https://aka.ms/new-console-template for more information

using System.Globalization;

const string InputFile = "in.txt";
const string OutputFile = "out.json";

Dictionary<string,string> ElementNames = new() {
    {"A", "NIF do emitente"},
    {"B", "NIF do adquirente"},
    {"C", "País do adquirente"},
    {"D", "Tipo de documento"},
    {"E", "Estado do documento"},
    {"F", "Data do documento"},
    {"G", "Identificação única do documento (nº. da factura)"},
    {"H", "ATCUD"},
    {"I1", "Espaço fiscal"},
    {"I2", "Base tributável isenta de IVA"},
    {"I3", "Base tributável de IVA à taxa reduzida (6%)"},
    {"I4", "Total de IVA à taxa reduzida (6%)"},
    {"I5", "Base tributável de IVA à taxa intermédia (13%)"},
    {"I6", "Total de IVA à taxa intermédia (13%)"},
    {"I7", "Base tributável de IVA à taxa normal (23%)"},
    {"I8", "Total de IVA à taxa normal (23%)"},
    {"J1", "Espaço fiscal"},
    {"J2", "Base tributável isenta de IVA"},
    {"J3", "Base tributável de IVA à taxa reduzida"},
    {"J4", "Total de IVA à taxa reduzida"},
    {"J5", "Base tributável de IVA à taxa intermédia"},
    {"J6", "Total de IVA à taxa intermédia"},
    {"J7", "Base tributável de IVA à taxa normal"},
    {"J8", "Total de IVA à taxa normal"},
    {"K1", "Espaço fiscal"},
    {"K2", "Base tributável isenta de IVA"},
    {"K3", "Base tributável de IVA à taxa reduzida"},
    {"K4", "Total de IVA à taxa reduzida"},
    {"K5", "Base tributável de IVA à taxa intermédia"},
    {"K6", "Total de IVA à taxa intermédia"},
    {"K7", "Base tributável de IVA à taxa normal"},
    {"K8", "Total de IVA à taxa normal"},
    {"L", "Não sujeito / não tributável em IVA"},
    {"M", "Imposto do Selo"},
    {"N", "Total de impostos"},
    {"O", "Total do documento com impostos"},
    {"P", "Retenções na fonte"},
    {"Q", "Código de Controlo"},
    {"R", "Número do Certificado"},
    {"S", "Outras informações"}
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
        if (elementParts[0] == "F") 
        {
            elementParts[1] = DateTime.ParseExact(elementParts[1],"yyyyMMdd", CultureInfo.CurrentCulture).ToShortDateString();
        }
        Console.WriteLine($"{ElementNames[elementParts[0]]}: {elementParts[1]}");
    }
}
