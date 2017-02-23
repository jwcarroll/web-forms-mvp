<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebContactManager.aspx.cs" Inherits="Agile.WebForms.ContactManager.WebContactManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-sm-4">
                    <div class="row">
                        <div class="col-sm-12">
                            <h2>Contact Manager</h2>
                            <div>
                                <asp:UpdateProgress ID="UpdateProgress1" DynamicLayout="false" runat="server" DisplayAfter="250">
                                    <ProgressTemplate>
                                        <img id="contactManager_updateProgress" src="../Image/ajax-loader.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <asp:Label ID="lblFirstName" Text="First Name" AssociatedControlID="tbFirstName" runat="server" />
                                <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblLastName" Text="Last Name" AssociatedControlID="tbLastName" runat="server" />
                                <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblPhoneNumber" Text="Phone Number" AssociatedControlID="tbPhoneNumber" runat="server" />
                                <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="form-control" />
                            </div>
                            <div class="radio">
                                <asp:RadioButtonList ID="rblStorageType" runat="server" RepeatLayout="UnorderedList" CssClass="list-unstyled" AutoPostBack="True">
                                    <asp:ListItem Text="SQL Store" Value="SQL" Selected="True" />
                                    <asp:ListItem Text="Flat File" Value="File" />
                                </asp:RadioButtonList>
                            </div>
                            <asp:Button ID="btnAddContact" CssClass="btn btn-default" ClientIDMode="Static" Text="Add Contact" runat="server" OnClick="btnAddContact_Click" />
                            <asp:Label ID="lblErrorMessage" CssClass="alert alert-danger" Text="" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div id="contactManager_contactList">
                                <h4>Contacts</h4>
                                <hr />
                                <asp:GridView ID="gvContactList" ClientIDMode="Static" runat="server" CellPadding="4"
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-8">
                    <h1>Contact Manager</h1>
                    <p>
                        The Contact Manager is a good example of how the Model View Presenter pattern can be used to
        build a single component that will work with any reasonably implemented view. The same Presenter
        that is driving the WinForms example is driving this example.
                    </p>
                    <p>
                        The Contact Manager also demonstrates how dependency injection can be used to manipulate the 
        underlying behavior of an object at runtime. Without a lot of effort the same type can easily
        switch between SQL storage and a Flat File. Since the type only knows about the interface, any
        storage mechanism can be used that implements that interface.
                    </p>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageScriptContent" runat="server">
</asp:Content>
