<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Shop.WebForms.Pages.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" ID="divItem" class="card" style="background-color: white;">
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
                                <img class="d-block w-100 h-auto" src='<%# Container.DataItem %>' alt="First slide">
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
            <p runat="server" ID="txtSoldQuantity" class="text-muted"></p>
            <h3 class="my-3" runat="server" ID="txtTitulo"></h3>
            <h3 class="my-3" runat="server" ID="txtPrecio"></h3>            
            <div class="row pl-2">
                <i class="fa fa-credit-card text-success p-2"></i>
                <p class="h6 text-success p-1">Pagá en 3 cuotas sin interés</p>
            </div>
            <p class="text-muted">Con tu mansa tarjeta</p>
            <div class="row pl-2">
                <i class="fa fa-truck text-success p-2"></i>
                <p class="h6 text-success p-1">Envío gratis</p>
            </div>
            <p class="text-muted">Beneficio Mercado Puntos</p>
            <div class="row pl-2">
                <i class="fa fa-reply text-success p-2"></i>
                <p class="h6 text-success p-1">Devolución gratis</p>
            </div>
            <p class="text-muted">Tenés 15 días desde que lo recibís</p>
            <div class="input-group input-group-sm mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Cantidad:</span>
                </div>
                <input runat="server" ID="txtQuantity" type="number" class="form-control col-4" aria-label="" value="1" min="1" max="" />
                <div class="input-group-append">
                    <small class="input-group-text" runat="server" ID="txtAvailableQuantity"></small>
                </div>
            </div>
            <button type="button" class="btn btn-primary">Comprar ahora</button>
            <button type="button" class="btn btn-outline-primary">Agregar al carrito</button>
        </div>
    </div>
    <div class="row pl-4">
        <h2 class="my-4">Características</h2>
    </div>
    <div class="row pl-3" >
        <asp:Repeater runat="server" ID="rpCharacterists">
            <ItemTemplate>
                <div class="col-md-6">
                    <blockquote class="blockquote">                        
                        <footer class="blockquote-footer"><%# ((Tuple<string,string>)Container.DataItem).Item1 + ":" %></footer>
                        <p class="mb-0"><%# ((Tuple<string,string>)Container.DataItem).Item2 %></p>                        
                    </blockquote>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="row pl-4">
        <h2 class="my-4">Descripción</h2>
    </div>
    <div class="row pl-3">
        <p runat="server" ID="txtDescription" class="p-3"></p>
    </div>
    </div>
    <div runat="server" class="jumbotron" ID="divNoItem">
        <i class="fa fa-warning"></i>
        <h2>OPPS!</h2>
    </div>
</asp:Content>
