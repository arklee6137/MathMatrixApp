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
using WpfMath;
using WpfMath.Controls;

namespace MathMatrixApp
{
    public class Matrix
    {
        string[,] M;
        int n = 0;
        public Matrix(int n_)
        {
            M = new string[n_, n_];
            n = n_;
        }

        public void AddElement(string el,int i,int j)
        {
            if (i > n - 1 || j > n - 1) return;
            M[i, j] = el;
        }

        public string MatrixConverterToFormula()
        {
            string s = @"\pmatrix{";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += M[i, j];
                    if (j != n - 1) s += " & ";
                }
                if (i != n - 1) s += @" \\ ";
            }
            s += "}";
            return s;
            
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Matrix m = new Matrix(3);
        int i = 0;
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                if (box.Text == "") box.Text += "0";
                m.AddElement(box.Text, i / 3, i % 3);
                box.Text = "";
                formula.Formula = m.MatrixConverterToFormula();
                i++;
            }
        }

        private void Clear_matrix_button_Click(object sender, RoutedEventArgs e)
        {
            m = new Matrix(3);
            i = 0;
            formula.Formula = @"\pmatrix{}";
        }

    }
}
