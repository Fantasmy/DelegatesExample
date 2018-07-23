using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesExample
{
    public partial class Form1 : Form
    {
        public delegate int Operacion(int a, int b);  // definicion delegado
        Operacion mas = null; //definicion variables del delegado
        Operacion res = null;
        Operacion mul = null;
        Operacion div = null;
        Operacion masLambda = null;

        Calculadora calculadora = null;

   

        public Form1()
        {
            InitializeComponent();
            calculadora = new Calculadora();
            mas = new Operacion(calculadora.Suma);
            res = new Operacion(calculadora.Resta);
            mul = new Operacion(calculadora.Multiplicacion);
            div = new Operacion(calculadora.Division);
            masLambda = (x, y) => (x + y); // no tiene que decirle que es entero porque tiene la firma
        }

        
        private void btnCalculadora_Click(object sender, EventArgs e)
        {

            int resSuma = mas(Convert.ToInt32(txtNum1.Text),
                            Convert.ToInt32(txtNum2.Text));
            int resResta = res(Convert.ToInt32(txtNum1.Text),
                            Convert.ToInt32(txtNum2.Text));
            int resMultiplicacion = mul(Convert.ToInt32(txtNum1.Text),
                            Convert.ToInt32(txtNum2.Text));
            int resDivision = div(Convert.ToInt32(txtNum1.Text),
                            Convert.ToInt32(txtNum2.Text));

            int resMasLambda = masLambda(Convert.ToInt32(txtNum1.Text),
                            Convert.ToInt32(txtNum2.Text));

            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
            MessageBox.Show(new StringBuilder()
                .Append(resSuma.ToString())
                .Append(",")
                .Append(resResta.ToString())
                .Append(",")
                .Append(resMultiplicacion.ToString())
                .Append(",")
                .Append(resDivision.ToString())
                .Append(",")
                .ToString()
          );

            MessageBox.Show(resMasLambda.ToString());

        }
    }
}
