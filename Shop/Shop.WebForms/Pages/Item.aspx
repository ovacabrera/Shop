<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Shop.WebForms.Pages.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" ID="divItem">
    <div class="row">
        <div class="col-md-8">
            <div id="carouselExampleIndicators" class="carousel card" data-ride="carousel">
                <ol class="carousel-indicators">
                    <asp:Repeater runat="server" ID="rpCarouselControls">
                        <ItemTemplate>
                            <li data-target="#carouselExampleIndicators" data-slide-to='<%# (Container.ItemIndex) %>' class='<%# (Container.ItemIndex == 0 ? "active" : "") %>'></li>
                        </ItemTemplate>
                    </asp:Repeater>  
                </ol>
                <div class="carousel-inner">
                    <asp:Repeater runat="server" ID="rpImages">
                        <ItemTemplate>
                            <div class='<%# "carousel-item "+(Container.ItemIndex == 0 ? "active" : "") %>' style="max-height: 430px;">
                                <img class="d-block w-100 h-auto" src='<%# ((Shop.Entities.Picture)Container.DataItem).url %>' alt="First slide">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>                    
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <div class="row">
                
            </div>
        </div>
        <div class="col-md-4">
            <p runat="server" ID="txtSoldQuantity"></p>
            <h3 class="my-3" runat="server" ID="txtTitulo"></h3>
            <h3 class="my-3" runat="server" ID="txtPrecio"></h3>            
            <ul>
                <li>Pagá en 3 cuotas sin interés</li>
                <li>Envío $ 1</li>
                <li>Devolución gratis</li>
            </ul>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Cantidad:</span>
                </div>
                <input type="text" class="form-control" aria-label="" value="1">
                <div class="input-group-append">
                    <span class="input-group-text" runat="server" ID="txtAvailableQuantity"></span>
                </div>
            </div>
            <button type="button" class="btn btn-primary">Comprar ahora</button>
            <button type="button" class="btn btn-outline-primary">Agregar al carrito</button>
        </div>
    </div>
    <div class="row" style="padding: 10px">
        <h2 class="my-4">Características</h2>
    </div>
    <div class="row" style="padding: 15px" >
        <asp:Repeater runat="server" ID="rpCharacterists">
            <ItemTemplate>
                <div class="col-md-6">
                    <blockquote class="blockquote">                        
                        <footer class="blockquote-footer"><%# ((Shop.Entities.AttributeX)Container.DataItem).name + ":" %></footer>
                        <p class="mb-0"><%# ((Shop.Entities.AttributeX)Container.DataItem).value_name %></p>                        
                    </blockquote>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="row" style="padding: 10px">
        <h2 class="my-4">Descripción
            <%--<small>Secondary Text</small>--%>
        </h2>
    </div>
    <div class="row" style="padding: 15px">
        <p runat="server" ID="txtDescription">

        </p>
    </div>
    </div>
    <div runat="server" class="jumbotron" ID="divNoItem">
        <h2>No hay publicaciones que coincidan con tu búsqueda.</h2>
    </div>
    
    <script type="text/javascript">

    </script>
</asp:Content>
