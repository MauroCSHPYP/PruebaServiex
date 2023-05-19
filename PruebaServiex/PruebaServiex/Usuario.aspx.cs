using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaServiex
{
    public partial class Usuario : System.Web.UI.Page
    {
        /// <summary>
        /// Instancia del servicio.
        /// </summary>
        SrvRef_CRUD_Serviex.IService1 servicio;

        /// <summary>
        /// Page_Load.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /// <summary>
        /// Agregar persona.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void btnAddPerson_Click(object sender, EventArgs e)
        {
            bool hasErrors = false;
            string msgError = "";
            int id_persona = 0;
            string nombre = "";
            DateTime fecha_nacimiento = new DateTime();
            string sexo = "";

            try
            {
                nombre = txtNombre.Text.Trim();
                if (DateTime.TryParse(txtFechaNacimiento.Text, out fecha_nacimiento))
                {
                    fecha_nacimiento = DateTime.Parse(txtFechaNacimiento.Text.Trim());
                }
                sexo = ddlSexo.SelectedValue;
            }
            catch (Exception ex)
            {
                hasErrors = true;
                msgError = "No se pudo crear la información de la persona";
                //ex.ToString();
            }

            if (!hasErrors)
            {
                // Crear registro: 

                //// Prueba local:
                PSData.PersonaData personalData = new PSData.PersonaData();
                //id_persona = personalData.InsertarPersona(new PSModel.Entidades.Persona()
                //{
                //    Nombre = nombre,
                //    FechaNacimiento = fecha_nacimiento,
                //    Sexo = sexo
                //});

                // Prueba desde el servicio - WCF:
                servicio = new SrvRef_CRUD_Serviex.Service1Client();
                id_persona = servicio.InsertarPersona(new PSModel.Entidades.Persona()
                {
                    Nombre = nombre,
                    FechaNacimiento = fecha_nacimiento,
                    Sexo = sexo
                });

                hasErrors = (id_persona <= 0);
                msgError = (!hasErrors) ? "Persona creada correctamente" : "No se creó la persona";
                showMessage(msgError, hasErrors);
            }
            else
            {
                showMessage(msgError, hasErrors);
            }

            this.limpiarCampos();
        }

        /// <summary>
        /// Limpiar los campos del formulario.
        /// </summary>
        private void limpiarCampos()
        {
            try
            {
                txtNombre.Text = "";
                txtFechaNacimiento.Text = "";
                ddlSexo.SelectedIndex = -1;
            }
            catch { }
        }

        /// <summary>
        /// Mostrar mensaje informativo.
        /// </summary>
        /// <param name="msg">Texto a mostrar</param>
        /// <param name="showControl">TRUE | FALSE</param>
        private void showMessage(string msg, bool showControl)
        {
            //lblError.Visible = showControl;
            lblError.Text = msg;
            lblError.ForeColor = (showControl) ? System.Drawing.Color.Red : System.Drawing.Color.Blue;
        }
    }
}