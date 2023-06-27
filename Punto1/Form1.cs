using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libConversor;


namespace Punto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {       
            this.txtTempEnt.Text = String.Empty;
            this.lbTempSal.Text = String.Empty;
            this.cbTipTempEnt.Text = String.Empty;
            this.cbTipoTempSal.Text = String.Empty;
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            float fltTempEnt;
            int intTipTempEnt, intTipTempSal;
            try
            {
                fltTempEnt = Convert.ToSingle(this.txtTempEnt.Text);
                intTipTempEnt = cbTipTempEnt.SelectedIndex;
                intTipTempSal = cbTipoTempSal.SelectedIndex;

                clsConversor oC = new clsConversor();

                oC.tempEnt = fltTempEnt;
                oC.opcion = intTipTempEnt;
                oC.tipTempSal = intTipTempSal;


                // TRATAMIENTO DEL ERROR

                if (!oC.Convertir())
                {
                    MessageBox.Show(oC.Error);
                    oC = null; // opcional
                    return;
                }

                //Mostrar info

                this.lbTempSal.Text = oC.tempSal.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
