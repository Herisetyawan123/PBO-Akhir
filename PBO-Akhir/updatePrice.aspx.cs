using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBO_Akhir
{
    public partial class updatePrice : System.Web.UI.Page
    {
        protected string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
        }


        protected void InsertData(object sender, EventArgs e)
        {
            string clothes = pakaian.Value;
            string size = ukuran.Value;
            string kains = kain.Value;
            //DateTime now = DateTime.Now;
            string price = harga.Value;

            try
            {


                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"UPDATE harga_kain SET size = '{size}', type = '{kains}', clothes = '{clothes}', price = {price} WHERE id={id};";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    test.InnerHtml = $"<div class='alert alert-success' role='alert'>Berhaisl ditambah</div>";
                    //Response.Redirect("/ListCloth");
                }
            }
            catch (Exception ex)
            {
                test.InnerHtml = $"<div class='alert alert-danger' role='alert'>{ex.Message}</div>";

            }

        }

    }
}