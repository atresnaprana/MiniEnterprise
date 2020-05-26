<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="OlshoptrackedBAK.Inventory.ShoppingList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
         <br />
   
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Shopping List" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
        <telerik:RadGrid ID="rgShoppingList" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgShoppingList_ItemCommand" OnItemDataBound="rgShoppingList_ItemDataBound" OnNeedDataSource="rgShoppingList_NeedDataSource"
            OnEditCommand="rgShoppingList_EditCommand" OnUpdateCommand="rgShoppingList_UpdateCommand" OnPreRender="rgShoppingList_PreRender" OnDeleteCommand="rgShoppingList_DeleteCommand"
            OnInsertCommand="rgShoppingList_InsertCommand" OnPageIndexChanged="rgShoppingList_PageIndexChanged" OnPageSizeChanged="rgShoppingList_PageSizeChanged"
            EnableLinqExpressions="False" Width="100%">
            <HeaderStyle Width="200px" />
            <PagerStyle AlwaysVisible="true" Position="Bottom" />
            <HeaderContextMenu CssClass="GridContextMenu ">
            </HeaderContextMenu>
            <ClientSettings EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="True" />
                <%-- <ClientEvents OnRowSelected="RgAgnCL_RowSelected" />--%>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="430px" />
            </ClientSettings>
            <MasterTableView AllowFilteringByColumn="false" CommandItemDisplay="Top" DataKeyNames="ID"
                PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="ID" Width="150%">
                <CommandItemSettings AddNewRecordText="Add Record" ShowRefreshButton="true" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>

                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                         <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="5%" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </telerik:GridEditCommandColumn>


                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Code" UniqueName="ID" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("ID") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="12%" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Shopping Notes" UniqueName="NOTES" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="notes" Width="90%" runat="server" Text='<%# Eval("NOTES") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <strong>*</strong><telerik:RadTextBox ID="notes" Text='<%# Eval("NOTES") %>' TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <strong>*</strong><telerik:RadTextBox ID="notes" runat="server" TextMode="MultiLine"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="13%" />
                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                    </telerik:GridTemplateColumn>
                 
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Transaction amount" UniqueName="AMOUNT" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="amount" Width="90%" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <strong>*</strong><telerik:RadNumericTextBox ID="amount" runat="server" Text='<%# Eval("AMOUNT") %>'></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <strong>*</strong><telerik:RadNumericTextBox ID="amount" runat="server"></telerik:RadNumericTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Transaction date" UniqueName="TRANS_DATE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                                    <asp:Label ID="transdate" Width="90%" runat="server" Text='<%# Eval("TRANS_DATE", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                           <strong>*</strong>         <telerik:RadDatePicker ID="transdate" runat="server" DateInput-DisplayDateFormat="dd-MMM-yyyy" SelectedDate='<%# Eval("TRANS_DATE") == DBNull.Value ? null :  (DateTime?)Eval("TRANS_DATE") %>'></telerik:RadDatePicker>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <strong>*</strong>        <telerik:RadDatePicker ID="transdate" runat="server"></telerik:RadDatePicker>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                   
                    <telerik:GridBoundColumn DataField="ENTRY_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ENTRY_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UPDATE_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogHeight="130px"
                        ConfirmDialogType="RadWindow" ConfirmDialogWidth="350px" ConfirmText="Do you want to delete this record ?"
                        ConfirmTitle="Delete" FilterControlAltText="Filter Delete column" HeaderButtonType="None"
                        UniqueName="Delete">
                        <HeaderStyle HorizontalAlign="Left" Width="30px" />
                        <ItemStyle HorizontalAlign="Left" Width="30px" />
                    </telerik:GridButtonColumn>
                    <%--<telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                                     <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                    </telerik:GridClientSelectColumn>--%>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
                <PagerStyle AlwaysVisible="True" />

            </MasterTableView>
            <FilterMenu>
            </FilterMenu>
            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="350px" />
                <ClientEvents />
            </ClientSettings>
        </telerik:RadGrid>
        <asp:HiddenField ID="hdfdataoperation" runat="server" />
        <telerik:RadWindowManager RenderMode="Lightweight" runat="server" ID="RadWindowManager1"></telerik:RadWindowManager>
        <div class="demo-container size-custom">
            <telerik:RadNotification RenderMode="Lightweight" ID="RadNotification1" runat="server" Height="140px"
                Animation="Fade" EnableRoundedCorners="true" EnableShadow="true" AutoCloseDelay="3500"
                Position="Center" OffsetX="-30" OffsetY="-70" ShowCloseButton="true"
                KeepOnMouseOver="false"
                OnClientUpdating="OnClientUpdating"
                OnClientShowing="onClientShowing">
            </telerik:RadNotification>
        </div>
    </telerik:RadAjaxPanel>
    <script>
        function callBackFn(arg) {
            // alert("this is the client-side callback function. The RadAlert returned: " + arg);
        }
        function RemoveZeros(sender, args) {
            var tbValue = sender._textBoxElement.value;
            if (tbValue.indexOf(".00") != -1)
                sender._textBoxElement.value = tbValue.substr(0, tbValue.indexOf(".00"));
        }
        function OnClientUpdating(sender, args) {
            if (sender.isVisible()) {
                args.set_cancel(true);
            }
        }
        function onClientShowing(sender, args) {
            notification = sender;
            notification.set_width(560);
        }
    </script>
</asp:Content>
