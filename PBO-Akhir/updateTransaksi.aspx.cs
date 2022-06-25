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
    public partial class updateTransaksi : System.Web.UI.Page
    {
        public string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
     
            getKain();

        }


        protected void getKain()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"select * from harga_kain";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int index = 1;
                    //option += "<select class='form-control col-12' id='kain' runat='server'>";


                    kain.Items.Insert(0, "-- choose ---");
                    foreach (DataRow dr in dt.Rows)
                    {
                        //kain.Items.Insert(int.Parse(dr["id"].ToString()), $"{dr["clothes"].ToString()} {dr["size"].ToString()} {dr["type"].ToString()}");
                        kain.Items.Insert(index, $"{dr["id"].ToString()} {dr["clothes"].ToString()} {dr["size"].ToString()} {dr["type"].ToString()}");
                        //kain.Items.Insert();
                    }

                    //option += "</select>";

                    cmd.Dispose();
                    connection.Close();

                    //return "berhasil";
                }
            }
            catch (Exception ex)
            {
                //table = ex.Message;

                //return ex.Message;

            }
        }

        protected void updateData(object sender, EventArgs e)
        {
            string name = nama.Value;
            string clothes = kain.Value.Split(' ')[0];
            string count = jumlah.Value;
            DateTime now = DateTime.Now;
            string tanggal = now.ToString("yyyy-MM-dd");
           string id = Request.QueryString["id"];

            try
            {


                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"UPDATE transaksi SET hk_id={clothes}, name = '{name}', amount = {count} WHERE id={id};";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    test.InnerHtml = $"<div class='alert alert-success' role='alert'>Berhasil Di ubah</div>";
                    //Response.Redirect($"/updateTransaksi?id={id}");
                }
            }
            catch (Exception ex)
            {
                test.InnerHtml = $"<div class='alert alert-danger' role='alert'>UPDATE transaksi SET hk_id={clothes}, name = '{name}', amount = {count} WHERE id={id};</div>";

            }

        }


    }
}