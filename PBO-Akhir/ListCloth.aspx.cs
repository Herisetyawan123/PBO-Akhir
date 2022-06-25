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
    public partial class ListCloth : System.Web.UI.Page
    {

        protected string table = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();  
            daftar.InnerHtml = table;
        }

        protected void getData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from harga_kain";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int index = 1;
                    foreach(DataRow dr in dt.Rows)
                    {
                        table += $"<tr><th scope='row'>{index}</th><td>{dr["clothes"].ToString()} {dr["size"].ToString()} {dr["type"].ToString()}</td><td>Rp. {dr["price"].ToString()}</td><td><a href='/Aksi?action=deleteHarga&id={dr["id"].ToString()}' class='badge badge-danger'>Hapus</a><a href='/updatePrice?id={dr["id"].ToString()}' class='badge badge-primary'>Edit</a></td></tr>";
                        index++;
                    }

                    cmd.Dispose();
                    connection.Close();

                    //return "berhasil";
                }
            }
            catch (Exception ex)
            {
                table = "gagal";
                //return ex.Message;

            }
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
                    cmd.CommandText = $"INSERT INTO harga_kain (size, type, clothes, price) VALUES ('{size}', '{kains}', '{clothes}', {price});";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    test.InnerHtml = $"<div class='alert alert-success' role='alert'>Berhaisl ditambah</div>";
                    Response.Redirect("/ListCloth");
                }
            }
            catch (Exception ex)
            {
                test.InnerHtml = $"<div class='alert alert-danger' role='alert'>{ex.Message}</div>";

            }

        }


    }

}