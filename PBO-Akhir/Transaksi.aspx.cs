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
    public partial class Transaksi : System.Web.UI.Page
    {
        protected string table = "";
        protected string option = "";
        //protected List<dynamic> options = [];
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();
            transaksi.InnerHtml = table;
            getKain();
            
            //kain.InnerText = option;

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
                    cmd.CommandText = $"select * from transaksi join harga_kain on harga_kain.id = transaksi.hk_id";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int index = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        table += $"<tr><th scope='row'>{index}</th><td>{dr["name"].ToString()}</td><td>{dr["clothes"].ToString()} {dr["size"].ToString()} {dr["type"].ToString()}</td><td>{dr["amount"].ToString()}</td><td>{dr["price"].ToString()}</td><td><a href='/Aksi?action=delete&id={dr["id"].ToString()}' class='badge badge-danger'>Hapus</a><a class='badge badge-primary' href='/updateTransaksi?id={dr["id"].ToString()}'>Edit</a></td></tr>";
                        index += 1;
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
                table = ex.Message;
                
                //return ex.Message;

            }
        }



        protected void InsertData(object sender, EventArgs e)
        {
            string name = nama.Value;
            string clothes = kain.Value.Split(' ')[0];
            string count = jumlah.Value;
            DateTime now = DateTime.Now;
            string tanggal = now.ToString("yyyy-MM-dd");

            try
            {


                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["dataku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"INSERT INTO transaksi (hk_id, name, amount, order_date) VALUES ({clothes}, '{name}', '{count}', '{tanggal}');";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    test.InnerHtml = $"<div class='alert alert-success' role='alert'>Berhaisl ditambah</div>";
                    Response.Redirect("/Transaksi");
                }
            }
            catch (Exception ex)
            {
                test.InnerHtml = $"<div class='alert alert-danger' role='alert'>{ex.Message}</div>";

            }

        }


    }
}