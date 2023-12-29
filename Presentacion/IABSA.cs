using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class IABSA : Form
    {
        public IABSA()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing() 
        //ocultamos todos los sub menus==> agregar todos los sub paneles
        {
            psubAdministracion.Visible = false;
        }
        private void hideSubMenu() 
        //oculta el sub menu de manera individual ==> agregar todos los sub paneles
        {
            if (psubAdministracion.Visible==true)
                psubAdministracion.Visible=false;
        }
        private void showSubMenu(Panel subMenu) 
        //Si el sub menu esta abrieto lo cierra y abre el siguiente
        {
            if (subMenu.Visible == false) 
            {
                hideSubMenu();
                subMenu.Visible=true;
            }
            else
                subMenu.Visible=false;
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        //llamada del sub menu
        {
            showSubMenu(psubAdministracion);
        }

        private void btnRegistroUsuario_Click(object sender, EventArgs e)
        //muestra el sub menu
        {
            openChildForm(new RegUsuarios());
            hideSubMenu();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm) 
        {
            if(activeForm!=null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ESTA POR SALIR DE SESION","PELIGRO",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                this.Close();
        }
    }
}
