<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updatePrice.aspx.cs" Inherits="PBO_Akhir.updatePrice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-8">
                <div id="test" runat="server"></div>
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
               <asp:Button class="btn btn-primary" type="button" runat="server" Text="Save Canges" OnClick="InsertData" />
            </div>
        </div>
    </div>

</asp:Content>
