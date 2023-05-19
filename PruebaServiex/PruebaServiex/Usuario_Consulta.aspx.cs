using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaServiex
{
    public partial class Usuario_Consulta : System.Web.UI.Page
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
            showMessage("", false);
            if (!IsPostBack)
            {
                cargarPersonas();
            }
        }

        /// <summary>
        /// Eliminar persona seleccionada.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvUsers.EditIndex)
                {
                    (e.Row.Cells[4].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar este registro?');";
                }
                if (e.Row.RowType == DataControlRowType.DataRow && gvUsers.EditIndex == e.Row.RowIndex)
                {
                    DropDownList ddlSexo = (DropDownList)e.Row.FindControl("ddlSexoGV");
                    string selectedValue = DataBinder.Eval(e.Row.DataItem, "Sexo").ToString();
                    try { ddlSexo.Items.FindByValue(selectedValue).Selected = true; }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                showMessage("No se pudo eliminar la persona", true);
                //ex.ToString();
            }
        }

        /// <summary>
        /// Seleccionar el ítem a editar.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            this.cargarPersonas();
        }

        /// <summary>
        /// Cancelar edición del registro en el gridview.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            this.cargarPersonas();
        }

        /// <summary>
        /// Editar registro seleccionado en la grilla.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool hasErrors = false;
            string msgError = "";
            int id_persona = 0;
            string nombre = "";
            DateTime fecha_nacimiento = new DateTime();
            string sexo = "";

            try
            {
                GridViewRow row = gvUsers.Rows[e.RowIndex];
                id_persona = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);
                nombre = (row.FindControl("txtNombreGV") as TextBox).Text.Trim();

                TextBox tx = row.FindControl("txtFechaNacimientoGV") as TextBox;
                if (tx != null)
                {
                    if (DateTime.TryParse(tx.Text, out fecha_nacimiento))
                    {
                        fecha_nacimiento = DateTime.Parse(tx.Text.Trim());
                    }
                }
                sexo = (row.FindControl("ddlSexoGV") as DropDownList).SelectedValue;
            }
            catch (Exception ex)
            {
                hasErrors = true;
                msgError = "No se pudo actualizar la información de la persona";
                //ex.ToString();
            }

            if (!hasErrors)
            {
                // Actualizar registro: 

                //// Prueba local:
                //PSData.PersonaData personalData = new PSData.PersonaData();
                //hasErrors = personalData.EditarPersona(new PSModel.Entidades.Persona()
                //{
                //    Id = id_persona,
                //    Nombre = nombre,
                //    FechaNacimiento = fecha_nacimiento,
                //    Sexo = sexo
                //});

                // Prueba desde el servicio - WCF:
                servicio = new SrvRef_CRUD_Serviex.Service1Client();
                hasErrors = servicio.EditarPersona(new PSModel.Entidades.Persona()
                {
                    Id = id_persona,
                    Nombre = nombre,
                    FechaNacimiento = fecha_nacimiento,
                    Sexo = sexo
                });

                msgError = (hasErrors) ? "Persona actualizada" : "No se actualizó la persona";
                showMessage(msgError, !hasErrors);
            }
            else
            {
                showMessage(msgError, hasErrors);
            }

            gvUsers.EditIndex = -1;
            this.cargarPersonas();
        }

        /// <summary>
        /// Eliminar registro/persona.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool hasErrors = false;
            string msgError = "";
            int id_persona = 0;

            try
            {
                GridViewRow row = gvUsers.Rows[e.RowIndex];
                id_persona = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                msgError = "No se pudo eliminar la persona seleccionada";
                //ex.ToString();
            }

            if (!hasErrors)
            {
                // Eliminar registro: 

                //// Prueba local:
                //PSData.PersonaData personalData = new PSData.PersonaData();
                //msgError = personalData.EliminarPersona(id_persona);

                // Prueba desde el servicio - WCF:
                servicio = new SrvRef_CRUD_Serviex.Service1Client();
                msgError = servicio.EliminarPersona(id_persona);
                hasErrors = string.IsNullOrEmpty(msgError.Trim());

                if (hasErrors)
                {
                    msgError = "Persona eliminada";
                }
                showMessage(msgError, !hasErrors);
            }
            else
            {
                showMessage(msgError, hasErrors);
            }

            this.cargarPersonas();
        }

        /// <summary>
        /// Cargar la grilla de personas.
        /// </summary>
        protected void cargarPersonas()
        {
            try
            {
                #region Vaciar campos del formulario.

                txtNombre.Text = "";
                txtFechaNacimiento.Text = "";
                ddlSexo.SelectedIndex = -1;

                #endregion

                //// Prueba local:
                //PSData.PersonaData personas = new PSData.PersonaData();
                //gvUsers.DataSource = personas.ObtenerPersonas(null);

                // Prueba desde el servicio - WCF:
                servicio = new SrvRef_CRUD_Serviex.Service1Client();
                gvUsers.DataSource = servicio.ObtenerPersonas(null);

                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                showMessage("No se puede cargar la grilla de personas", true);
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

            gvUsers.EditIndex = -1;
            this.cargarPersonas();
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