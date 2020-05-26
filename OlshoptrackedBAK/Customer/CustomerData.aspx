<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerData.aspx.cs" Inherits="OlshoptrackedBAK.Customer.CustomerData" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Customer Information" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
    <br />
    <telerik:RadButton ID="Filter" runat="server" Font-Names="Verdana" GroupName="Toggle" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Show Filter" OnClientClicked="OnGridCreated" AutoPostBack="false"></telerik:RadButton>
    <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <br />

        <telerik:RadGrid ID="rgCustomer" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgCustomer_ItemCommand" OnItemDataBound="rgCustomer_ItemDataBound" OnNeedDataSource="rgCustomer_NeedDataSource"
            OnEditCommand="rgCustomer_EditCommand" OnUpdateCommand="rgCustomer_UpdateCommand" OnPreRender="rgCustomer_PreRender" OnDeleteCommand="rgCustomer_DeleteCommand" OnInsertCommand="rgCustomer_InsertCommand" OnPageIndexChanged="rgCustomer_PageIndexChanged" OnPageSizeChanged="rgCustomer_PageSizeChanged"
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
            <MasterTableView AllowFilteringByColumn="true" CommandItemDisplay="Top" DataKeyNames="CUST_ID"
                PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="CUST_ID" Width="150%">
                <CommandItemSettings AddNewRecordText="Add Record" ShowRefreshButton="true" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                 <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>

                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="4%" />
                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                    </telerik:GridEditCommandColumn>


                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Code" UniqueName="CUST_ID" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("CUST_ID") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("CUST_ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("CUST_ID") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Name" UniqueName="CUST_NAME" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="name" Width="90%" runat="server" Text='<%# Eval("CUST_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="name" Text='<%# Eval("CUST_NAME") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="name" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Phone 1" UniqueName="PHONE" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="phone" Width="90%" runat="server" Text='<%# Eval("PHONE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadMaskedTextBox RenderMode="Lightweight" ID="phone" runat="server" Mask="(###)-#########" Text='<%# Eval("PHONE") %>' Width="222px"
                                ValidationGroup="Group1">
                            </telerik:RadMaskedTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadMaskedTextBox RenderMode="Lightweight" ID="phone" runat="server" Mask="(###)-#########" Width="222px"
                                ValidationGroup="Group1">
                            </telerik:RadMaskedTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="E mail" UniqueName="EMAIL" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="email" Width="90%" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="email" TextMode="MultiLine" Text='<%# Eval("EMAIL") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="email" TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Address" UniqueName="ADDRESS" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="address" Width="90%" runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="address" TextMode="MultiLine" Text='<%# Eval("ADDRESS") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="address" TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="UPDATE_USER" HeaderText="Update By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="ENTRY_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="false" DataField="ENTRY_USER" HeaderText="Update By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="ENTRY_USER" ReadOnly="true">
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
             <FilterMenu AutoScrollMinimumWidth="1000">
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
                window.$find('<%=rgCustomer.ClientID %>').get_masterTableView().hideFilterItem();
            }

            function ShowFilter() {
                console.log("show")
                window.$find('<%=rgCustomer.ClientID %>').get_masterTableView().showFilterItem();
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
