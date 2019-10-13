using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;


namespace MVC_VISTA_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null;  //Inicializa la instancia
        ClsContactoMgr objContactoMgr = null; //Inicializar la instancia
        DataTable Dtt = null;  //Inicializa la instancia
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Listar() {
            objContacto = new ClsContacto();  //Completo la instancia
            objContacto.opc = 1;     //Setter
            objContactoMgr = new ClsContactoMgr(objContacto); //Completo la instancia

            Dtt = new DataTable();   //Completo la instancia
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0) {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Guardar() {
            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Id = Convert.ToInt32( txtcodigo.Text );
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Contacto guardado exitosamente", "Mensaje");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtcodigo.Focus();
            Listar();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos() {
            txtcodigo.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txtcodigo.Focus();
        }

        private void GuardarCambios() {
            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios guardados exitosamente", "Mensaje");
        }

        private void dtregistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString(); 
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txttelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            txtcodigo.Enabled = false;
            btneliminar.Enabled = true;
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        public void Eliminar() {
            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Id = Convert.ToInt16(txtcodigo.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);

            objContactoMgr.EliminarDatos();
            MessageBox.Show("Registro eliminado exitosamente", "Mensaje");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = true;
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }
    }
}
