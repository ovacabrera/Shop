<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Shop.WebForms.Pages.Search" %>
<%@ OutputCache Location="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: ResolveUrl("~/Scripts/jquery.twbsPagination.js") %>"  type="text/javascript"></script>
    <script src="<%: ResolveUrl("~/Scripts/jquery.bootpag.min.js") %>"  type="text/javascript"></script>
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
             <br/> 
             <div class="d-flex justify-content-center">
                 <nav aria-label="Page navigation" id="paginationNav">
                     <ul class="pagination" id="pagination"></ul>
                 </nav>
             </div>
         </div>
     </div>                 

    <asp:HiddenField runat="server" ID="hfCurrentPage" EnableViewState="True"/>
    <asp:HiddenField runat="server" ID="hfTotalPages" EnableViewState="True"/>
    
    <script type="text/javascript" language="javascript">

        $('#paginationNav').bootpag({
            total: $("#<%= hfTotalPages.ClientID %>").val(),
            maxVisible: 8,
            page: $("#<%= hfCurrentPage.ClientID %>").val(),

            leaps: true,
            firstLastUse: true,
            first: '←',
            last: '→',
            wrapClass: 'pagination',
            activeClass: 'active',
            disabledClass: 'disabled',
            nextClass: 'next',
            prevClass: 'prev',
            lastClass: 'last',
            firstClass: 'first'

        }).on("page", function(event, /* page number here */ num){
            var str = window.location.href;
            str = replaceQueryParam('p', num, str);                    
            window.location.href = str;
        });

        function Comprar(id) {
            window.location.href = 'Item.aspx?id='+id;
        };

        function replaceQueryParam(param, newval, search) {
            var regex = new RegExp("([?;&])" + param + "[^&;]*[;&]?");
            var query = search.replace(regex, "$1").replace(/&$/, '');

            return (query.length > 2 ? query + "&" : "?") + (newval ? param + "=" + newval : '');
        }

        function GetParamValue(param) {
            var url = new URL(window.location.href);
            var paramValue = url.searchParams.get(param);
            if (paramValue != '') {
                return paramValue;
            } else {
                return 1;
            }
        }
    </script>
    

</asp:Content>
