using SACDumont.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmImrpimirCobros : Form
    {
        public int idMovimiento = 0;
        List<cobros> movCobros = new List<cobros>();

        public frmImrpimirCobros()
        {
            InitializeComponent();
        }

        private void frmImrpimirCobros_Load(object sender, EventArgs e)
        {
            using (var db = new DumontContext())
            {
                movCobros = db.MovimientoCobros.Where(mc => mc.id_movimiento == idMovimiento).ToList();
            }
        }
    }
}
