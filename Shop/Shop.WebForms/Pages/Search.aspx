<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Shop.WebForms.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container">
     <div class="col-md-2">
     </div>
     <div class="col-md-10">
         <div class="row">
             <asp:Repeater runat="server" ID="rpItems">
                 <ItemTemplate>
                     <div class="col-sm-12 col-lg-4">
                         <div class="card h-100" style="width: 18rem;" onclick="Comprar('<%# ((Shop.Entities.Result)Container.DataItem).id %>');">
                             <img class="card-img-top" src='<%# ((Shop.Entities.Result)Container.DataItem).thumbnail %>'>
                             <div class="card-body">
                                 <p class="card-text"><%# ((Shop.Entities.Result)Container.DataItem).title %></p>
                                 <h5 class="card-title"><%# "$ "+ ((Shop.Entities.Result)Container.DataItem).price.ToString("N") %></h5>                            
                             </div>
                         </div>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>
         </div>
         <div class="jumbotron" runat="server" id="divNoResults">
             <h2>No hay publicaciones que coincidan con tu búsqueda.</h2>
             <p class="lead">Revisá la ortografía de la palabra.</p>
             <p class="lead">Utilizá palabras más genéricas o menos palabras.</p>
             <p class="lead">Navega por las categorías para encontrar un producto similar.</p>
         </div>
     </div>
 </div> 
    

    <script type="text/javascript">
        function Comprar(id) {
            window.location.href = 'Item.aspx?id='+id;
        }

    </script>
</asp:Content>
