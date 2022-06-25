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
    public partial class Aksi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"];
            string id = Request.QueryString["id"];
            if(action == "delete")
            {
                delete(id, "transaksi");
                Response.Redirect("/Transaksi");
            }else if(action == "deleteHarga")
            {
                delete(id, "harga_kain");
                Response.Redirect("/ListClothes");
            }

        }

        protected void delete(string id, string table)
        {
            try /* Deletion After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"Delete from {table} where id={id}";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
                //return "berhasil";
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }
        }
    }
}