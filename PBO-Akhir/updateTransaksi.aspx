<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateTransaksi.aspx.cs" Inherits="PBO_Akhir.updateTransaksi" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-8">
                <div id="test" runat="server"></div>
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
                <asp:Button class="btn btn-primary col-12" type="button" runat="server" Text="Edit" onClick="updateData" /> 
            </div>
        </div>
    </div>
</asp:Content>