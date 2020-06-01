<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInventory.aspx.cs" Inherits="OlshoptrackedBAK.Inventory.ProductInventory" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Menu List" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
    <telerik:RadLabel runat="server" ID="RadLabel1" Text="Customer Information" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
    <br />
    <telerik:RadButton ID="Filter" runat="server" Font-Names="Verdana" GroupName="Toggle" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Show Filter" OnClientClicked="OnGridCreated" AutoPostBack="false"></telerik:RadButton>
    <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <br />

        <telerik:RadGrid ID="rgProduct" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgProduct_ItemCommand" OnItemDataBound="rgProduct_ItemDataBound" OnNeedDataSource="rgProduct_NeedDataSource"
            OnEditCommand="rgProduct_EditCommand" OnUpdateCommand="rgProduct_UpdateCommand" OnPreRender="rgProduct_PreRender" OnDeleteCommand="rgProduct_DeleteCommand"
            OnInsertCommand="rgProduct_InsertCommand" OnPageIndexChanged="rgProduct_PageIndexChanged" OnPageSizeChanged="rgProduct_PageSizeChanged"
            EnableLinqExpressions="False" Width="100%">
            <HeaderStyle Width="200px" />
            <PagerStyle AlwaysVisible="true" Position="Bottom" />
            <HeaderContextMenu CssClass="GridContextMenu ">
            </HeaderContextMenu>
            <ClientSettings EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="True" />
                <ClientEvents OnGridCreated="OnGridCreated" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="430px" />
            </ClientSettings>
            <MasterTableView AllowFilteringByColumn="true" CommandItemDisplay="Top" DataKeyNames="PROD_ID,prod_cat_id"
                PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="PROD_ID,prod_cat_id" Width="150%">
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


                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Code" UniqueName="PROD_ID" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("PROD_ID") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("PROD_ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("PROD_ID") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="12%" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Product Name" UniqueName="PROD_NAME" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="prodname" Width="90%" runat="server" Text='<%# Eval("PROD_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="prodname" Text='<%# Eval("PROD_NAME") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="prodname" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="13%" />
                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Product Description" UniqueName="DESCRIPTION" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="description" Width="90%" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="description" Text='<%# Eval("DESCRIPTION") %>' TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="description" runat="server" TextMode="MultiLine"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="13%" />
                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Price" UniqueName="PRICE" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="price" Width="90%" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadNumericTextBox ID="price" runat="server" Text='<%# Eval("PRICE") %>'></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadNumericTextBox ID="price" runat="server"></telerik:RadNumericTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Category" UniqueName="CATEGORY_NAME" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="hdrcustcode" Width="90%" runat="server" Text='<%# Eval("CATEGORY_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadComboBox ID="RadCmbCatHdr" Width="150px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CATEGORY_NAME" DataValueField="id">
                            </telerik:RadComboBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadComboBox ID="RadCmbCatHdr" Width="150px" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CATEGORY_NAME" DataValueField="id"></telerik:RadComboBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="ENTRY_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="ENTRY_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="UPDATE_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn  ButtonType="ImageButton" CommandName="Delete" ConfirmDialogHeight="130px"
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
    <telerik:RadScriptBlock runat="server">
         <script>
             function HideFilter() {
                 console.log("hide")
                 window.$find('<%=rgProduct.ClientID %>').get_masterTableView().hideFilterItem();
             }

             function ShowFilter() {
                 console.log("show")
                 window.$find('<%=rgProduct.ClientID %>').get_masterTableView().showFilterItem();
             }
             function OnGridCreated() {
                 var btn1 = window.$find("<%=Filter.ClientID %>");
                if (btn1.get_checked()) {
                    ShowFilter();

                } else {
                    HideFilter();

                }
            }
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
    </telerik:RadScriptBlock>
   
</asp:Content>
