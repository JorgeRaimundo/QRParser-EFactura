// See https://aka.ms/new-console-template for more information

const string fact1 = "A:501556109*B:213114755*C:PT*D:FR*E:N*F:20231120*G:VD0 A/93446*H:JFN4TKFM-93446*I1:PT*I2:0.00*I3:0.00*I4:0.00*I5:0.00*I6:0.00*I7:41.46*I8:9.54*L:0.00*M:0*N:9.54*O:51.00*P:0*Q:a7UN*R:122";

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

List<string> elements = [.. fact1.Split('*')];

foreach (var element in elements)
{
    List<string> elementParts = [.. element.Split(':')];
    Console.WriteLine($"{ElementNames[elementParts[0]]}: {elementParts[1]}");
}
