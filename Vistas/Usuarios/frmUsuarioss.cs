using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_proimea_vez.Vistas.Usuarios
{
    public partial class frmUsuarioss : Form
    {
        Controladores.UsuariosController _usuariosController = new Controladores.UsuariosController();

        public frmUsuarioss()
        {
            InitializeComponent();
        }

        private void frmUsuarioss_Load(object sender, EventArgs e)
        {
            cargaLista();
        }

        public void cargaLista()
        {
            lst_ListaUsuarios.DataSource = _usuariosController.todos().ToList();
            lst_ListaUsuarios.ValueMember = "UsuarioId";
            lst_ListaUsuarios.DisplayMember = "Nombre_Usuario";
        }

        public void LimpiarCajas()
        {
            txtNombres.Text = "";
            txtapellido.Text = "";
            txtCorreo.Text = "";
            txtnombre_usuario.Text = "";
            textContraseña.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var id = _usuariosController._listaUsuarios.Count();
            var usuario = new Modelos.Usuarios
            {
                Nombre = txtNombres.Text.Trim(),
                Apellido = txtapellido.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                Nombre_Usuario = txtnombre_usuario.Text.Trim(),
                Contrasenia = textContraseña.Text.Trim(),
                UsuarioId = id + 1
            };

            var res = _usuariosController.insertar(usuario);
            if (res == "ok")
            {
                MessageBox.Show("Se guardó con éxito");
                this.LimpiarCajas();
                this.cargaLista();
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario. " + res);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lst_ListaUsuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un ítem de la lista");
                return;
            }

            var usuario = _usuariosController.uno(Convert.ToInt32(lst_ListaUsuarios.SelectedValue));
            txtNombres.Text = usuario.Nombre;
            txtapellido.Text = usuario.Apellido;
            txtCorreo.Text = usuario.correo;
            txtnombre_usuario.Text = usuario.Nombre_Usuario;
            textContraseña.Text = usuario.Contrasenia;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var res = _usuariosController.eliminar(Convert.ToInt32(lst_ListaUsuarios.SelectedValue));
            if (res == "ok")
            {
                MessageBox.Show("Se eliminó con éxito");
                this.LimpiarCajas();
                this.cargaLista();
            }
            else
            {
                MessageBox.Show("Error al eliminar el usuario. " + res);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_ListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtapellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usuario = new Modelos.Usuarios
            {
                Nombre = txtNombres.Text.Trim(),
                Apellido = txtapellido.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                Nombre_Usuario = txtnombre_usuario.Text.Trim(),
                Contrasenia = textContraseña.Text.Trim(),
                UsuarioId = Convert.ToInt32(lst_ListaUsuarios.SelectedValue)
            };

            var res = _usuariosController.actualizar(usuario);
            if (res == "ok")
            {
                MessageBox.Show("Se modificó con éxito");
                this.LimpiarCajas();
                this.cargaLista();
            }
            else
            {
                MessageBox.Show("Error al modificar el usuario. " + res);
            }
        }
    }
}
