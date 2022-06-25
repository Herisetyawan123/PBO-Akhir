<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCloth.aspx.cs" Inherits="PBO_Akhir.ListCloth" %>

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

                      <th scope="col">Barang</th>
                      <th scope="col">harga</th>
                    </tr>
                  </thead>
                  <tbody id="daftar" runat="server">

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
            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form class="">
              <div class="form-group">
                <label for="exampleFormControlSelect1">Jenis Pakaian</label>
                <select class="form-control col-12" name="clothes" id="pakaian" runat="server">
                  <option value="baju">Baju</option>
                  <option value="celana">Celana</option>
                </select>
              </div>
              <div class="form-group">
                <label for="exampleFormControlSelect1">Ukuran</label>
                <select class="form-control col-12" name="clothes" id="ukuran" runat="server">
                  <option value="panjang">Panjang</option>
                  <option value="pendek">Pendek</option>
                </select>
              </div>
              <div class="form-group">
              <div class="form-group">
                <label for="exampleInputPassword1">Jenis Kain</label>
                <input type="text" class="form-control col-12" id="kain" runat="server">
              </div>
              <div class="form-group">
                <label for="exampleInputPassword1">Harga</label>
                <input type="text" class="form-control col-12" id="harga" runat="server">
              </div>
<%--              <button type="submit" class="btn btn-primary col-12">Submit</button>--%>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
              <asp:Button class="btn btn-primary" type="button" runat="server" Text="Save Canges" OnClick="InsertData" />
          </div>
        </div>
      </div>
    </div>
</asp:Content>
