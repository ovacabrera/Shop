<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Shop.WebForms.Pages.Search" %>
<%@ OutputCache Location="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: ResolveUrl("~/Scripts/jquery.bootpag.min.js") %>"  type="text/javascript"></script>
         <div class="col-md-12">
             <div class="row">
                 <asp:Repeater runat="server" ID="rpItems">
                     <ItemTemplate>
                         <div class="col-6 col-sm-4 col-lg-2">
                             <div class="card shadow" style="width: 10rem;" onclick="GoToItemPage('<%# ((Shop.Entities.Result)Container.DataItem).id %>');">
                                 <div class="d-flex justify-content-center">
                                     <img class="card-img-top h-100 w-100" src='<%# ((Shop.Entities.Result)Container.DataItem).thumbnail %>'>
                                 </div>
                                 <hr/>
                                 <div class="card-body">
                                     <h5 class="card-title"><%# "$ "+ ((Shop.Entities.Result)Container.DataItem).price.ToString("N") %></h5>                                                                 
                                     <small class="<%# "text-success " + (((Shop.Entities.Result)Container.DataItem).shipping.free_shipping ? "visible" : "invisible") %>" >Envío Gratis</small>
                                     <p class="card-text"><%# ((Shop.Entities.Result)Container.DataItem).title %></p>                                     
                                 </div>
                             </div>
                             <br/>
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
    <asp:HiddenField runat="server" ID="hfCurrentPage" EnableViewState="True"/>
    <asp:HiddenField runat="server" ID="hfTotalPages" EnableViewState="True"/>    
    <script type="text/javascript" language="javascript">

        $('#paginationNav').bootpag({
            total: $("#<%= hfTotalPages.ClientID %>").val(),
            maxVisible: 7,
            page: $("#<%= hfCurrentPage.ClientID %>").val(),
            leaps: true,
            firstLastUse: false,
            next: '→',
            prev: '←',
            wrapClass: 'pagination',
            activeClass: 'active',
            disabledClass: 'disabled',
            nextClass: 'next',
            prevClass: 'prev',
            lastClass: 'last',
            firstClass: 'first'
        }).on("page", function (event, /* page number here */ num) {            
            var str = window.location.href;
            str = replaceQueryParam(<%= "'"+this.PageNumberParamName+"'" %>, num, str);                    
            window.location.href = str;
        });

        function GoToItemPage(id) {
            window.location.href = 'Item.aspx?id='+id;
        };

        function replaceQueryParam(param, newval, search) {
            var regex = new RegExp("([?;&])" + param + "[^&;]*[;&]?");
            var query = search.replace(regex, "$1").replace(/&$/, '');

            return (query.length > 2 ? query + "&" : "?") + (newval ? param + "=" + newval : '');
        }
    </script>
    

</asp:Content>
