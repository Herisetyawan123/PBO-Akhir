<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transaksi.aspx.cs" Inherits="PBO_Akhir.Transaksi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 mb-5">
        <div class="card shadow">
            <div class="card-header d-flex justify-content-between">
                <h3>Daftar Transaksi</h3>
                <!-- Button trigger modal -->
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                  Tambah
                </button>
            </div>
            <div class="card-body">
                <div id="test" runat="server"></div>
                <table class="table table-striped">
                  <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">Nama</th>
                      <th scope="col">Barang</th>
                      <th scope="col">Jumlah</th>
                      <th scope="col">harga</th>
                    </tr>
                  </thead>
                  <tbody id="transaksi" runat="server">
                    <tr>
                      <th scope="row">1</th>
                      <td>Mark</td>
                      <td>Mark</td>
                      <td>Otto</td>
                      <td>@mdo</td>
                    </tr>
                  </tbody>
                </table>
            </div>

        </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Tambah Transaksi</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <%--<form class="">--%>
              <div class="form-group">
                <label for="exampleInputPassword1">Nama</label>
                <input type="text" class="form-control col-12" id="nama" runat="server">
              </div>
              <div class="form-group">
                <label for="exampleFormControlSelect2">Kain</label>
                  <select class='form-control col-12' id='kain' runat='server'>

                  </select>
 <%--                 <div id="select" runat="server">

                  </div>--%>
              </div>

              <div class="form-group">
                <label for="exampleInputPassword1">Jumlah</label>
                <input type="number" class="form-control col-12" id="jumlah" runat="server">
              </div>
                <asp:Button class="btn btn-primary col-12" type="button" runat="server" Text="Tambah" OnClick="InsertData" />  
              <%--<button type="button" class="btn btn-primary col-12" onClick="btn_Click" runat="server">Submit</button>--%>
            <%--</form>--%>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
