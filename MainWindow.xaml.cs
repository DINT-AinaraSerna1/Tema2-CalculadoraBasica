using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int op1;
        private int op2;
        private char signo;
        private bool op1Set, op2Set, signoSet;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar_Button_Click(object sender, RoutedEventArgs e)
        {
            operando1_TextBox.Text = operando2_TextBox.Text = signo_TextBox.Text = resultado_TextBox.Text = "";
        }
        private static int Operar(int op1, char signo, int op2)
        {
            switch (signo)
            {
                case '+':
                    return op1 + op2;
                case '-':
                    return op1 - op2;
                case 'X' or 'x' or '*':
                    return op1 * op2;
                case '/':
                    return op1 / op2;
                default:
                    return -1;

            }
        }
        private void Calcular_Button_Click(object sender, RoutedEventArgs e)
        {
            op1 = int.Parse(operando1_TextBox.Text);
            op2 = int.Parse(operando2_TextBox.Text);
            signo = char.Parse(signo_TextBox.Text);

            resultado_TextBox.Text = Operar(op1, signo, op2).ToString();
        }

        private void Operando1_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            op1Set = int.TryParse(operando1_TextBox.Text, out op1);
            CompruebaEstadoBotonCalcular();
        }

        private void Operando2_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            op2Set = int.TryParse(operando1_TextBox.Text, out op2);
            CompruebaEstadoBotonCalcular();
        }

        private void Signo_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string signos = "+-/*xX";
            signoSet = char.TryParse(signo_TextBox.Text, out signo) && signos.Contains(signo);
            CompruebaEstadoBotonCalcular();
        }
        private void CompruebaEstadoBotonCalcular()
        {
            if (op1Set && op2Set && signoSet)
                calcular_Button.IsEnabled = true;
        }
    }
}
