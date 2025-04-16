using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Base;

namespace SACDumont.Catalogos
{
    public partial class frmCatTutores : frmBaseCatalogos
    {
        public frmCatTutores(int matricula = 0)
        {
            InitializeComponent();
        }

        protected override void Nuevo()
        {
            // Implementar la lógica para crear un nuevo registro de alumno
        }
        protected override void Guardar()
        {

        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
        }

        protected override void AgregarTutor()
        {
            // Implementar la lógica para eliminar el registro de alumno
        }

        protected override void Cerrar()
        {
            this.Close();
        }

        private void frmCatTutores_Load(object sender, EventArgs e)
        {
            agregarTutorToolStripMenuItem.Visible = false;
        }
    }
}
