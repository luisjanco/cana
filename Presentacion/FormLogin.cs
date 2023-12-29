using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "USUARIO") 
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "") 
            {
                if(txtUser.Text == "") 
                {
                    txtUser.Text = "USUARIO";
                    txtUser.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA") 
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "") 
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor= Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //inicio de sesion
            if (txtUser.Text != "Username") {
                if (txtPass.Text != "CONTRASEÑA") {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtUser.Text,txtPass.Text);
                    if(validLogin==true) 
                    {
                        IABSA mainMenu = new IABSA();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else 
                    {
                        msgError("USUARIO INCORRECTO O CONTRASEÑA INCORRECTA. \n POR FAVOR INTENTALO DE NUEVO");
                        /*txtPass.Clear();
                        txtUser.Focus();*/
                        txtPass.Text= "CONTRASEÑA";
                        txtPass.Focus();
                    }
                }
                else msgError("POR FAVOR INTRODUSCA SU CONTRASEÑA");
            }
            else msgError("PORFAVOR INGRESE SU MONBRE DE USUARIO");
        }
        private void msgError(string msg) {
            lblErrorMennsagge.Text = "    "+msg;
            lblErrorMennsagge.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e) 
        {
            /*txtPass.Clear();
            txtUser.Clear();
            lblErrorMennsagge.Visible=false;
            this.Show();
            txtUser.Focus();*/
            txtPass.Text = "CONTRASEÑA";
            txtPass.UseSystemPasswordChar = false;
            txtUser.Text = "USUARIO";
            lblErrorMennsagge.Visible=false;
            this.Show();
        }
    }
}
