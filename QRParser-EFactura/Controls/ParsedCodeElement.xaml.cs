using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace QRParser_EFactura.Controls
{
    /// <summary>
    /// Interaction logic for ParsedCodeElement.xaml
    /// </summary>
    public partial class ParsedCodeElement : UserControl, INotifyPropertyChanged
    {
        public ParsedCodeElement()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? labelContent;

        public string? LabelContent
        {
            get { return labelContent; }
        }

        private string? lineValue;

        public string? LineValue
        {
            get { return lineValue; }
            set
            {
                lineValue = value;
                labelContent = $"{lineDescription}: {lineValue}";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LabelContent)));
            }
        }

        private string? lineDescription;

        public string? LineDescription
        {
            get { return lineDescription; }
            set
            {
                lineDescription = value;
                labelContent = $"{lineDescription}: {lineValue}";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LabelContent)));
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(lineValue);
        }
    }
}
