<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionIn.aspx.cs" Inherits="OlshoptrackedBAK.Transaction.TransactionIn" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Daily Transaction" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
    <br />
    <telerik:RadButton ID="Filter" runat="server" Font-Names="Verdana" GroupName="Toggle" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Show Filter" OnClientClicked="OnGridCreated" AutoPostBack="false"></telerik:RadButton>
     <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <br />

        <telerik:RadGrid ID="rgTransIn" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"  
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgTransIn_ItemCommand" OnItemDataBound="rgTransIn_ItemDataBound" OnNeedDataSource="rgTransIn_NeedDataSource"
            OnEditCommand="rgTransIn_EditCommand" OnUpdateCommand="rgTransIn_UpdateCommand" OnPreRender="rgTransIn_PreRender" OnDeleteCommand="rgTransIn_DeleteCommand"
            OnInsertCommand="rgTransIn_InsertCommand" AllowMultiRowEdit="false" OnPageIndexChanged="rgTransIn_PageIndexChanged" OnPageSizeChanged="rgTransIn_PageSizeChanged"
            EnableLinqExpressions="False" Width="100%">
            <HeaderStyle Width="200px" />
            <PagerStyle AlwaysVisible="true" Position="Bottom" />
            <HeaderContextMenu CssClass="GridContextMenu ">
            </HeaderContextMenu>
            <ClientSettings EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="false" />
                <ClientEvents OnGridCreated="OnGridCreated" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="430px" />
            </ClientSettings>
            <MasterTableView AllowFilteringByColumn="true" EditMode="InPlace" CommandItemDisplay="Top" DataKeyNames="TRANS_ID,CUST_ID,PROD_ID,IS_GOJEK"
                PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="TRANS_ID,CUST_ID,PROD_ID,IS_GOJEK" Width="150%">
                <CommandItemSettings AddNewRecordText="Add Record" ShowRefreshButton="true" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="False">
                        </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>

                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                         <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="5%" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </telerik:GridEditCommandColumn>


                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Code" UniqueName="TRANS_ID" FilterControlWidth="100%" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("TRANS_ID") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("TRANS_ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("TRANS_ID") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="5%" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Trans Date" UniqueName="TRANS_DATE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="transdate" Width="90%" runat="server" Text='<%# Eval("TRANS_DATE", "{0:dd-MMM-yyyy}") %>' ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadDatePicker ID="transdate" runat="server" Width="100%" DateInput-DisplayDateFormat="dd-MMM-yyyy" SelectedDate='<%# Eval("TRANS_DATE") == DBNull.Value ? null :  (DateTime?)Eval("TRANS_DATE") %>'></telerik:RadDatePicker>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadDatePicker ID="transdate" Width ="100%" runat="server"></telerik:RadDatePicker>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Description" UniqueName="DESCRIPTION" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="description" Width="90%" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="description" Text='<%# Eval("DESCRIPTION") %>' runat="server" TextMode="MultiLine"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="description" runat="server" TextMode="MultiLine"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Customer" UniqueName="CUST_NAME" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="hdrcustcode" Width="90%" runat="server" Text='<%# Eval("CUST_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadComboBox ID="RadCmbCustHdr" Width="150px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CUST_NAME" DataValueField="CUST_ID">
                            </telerik:RadComboBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadComboBox ID="RadCmbCustHdr" Width="150px" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CUST_NAME" DataValueField="CUST_ID"></telerik:RadComboBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Product" UniqueName="PROD_NAME" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="hdrprodcode" Width="90%" runat="server" Text='<%# Eval("PROD_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadComboBox ID="RadCmbProdHdr" Width="150px" AllowCustomText="true" OnSelectedIndexChanged="RadCmbProdHdr_SelectedIndexChanged" AutoPostBack="true" runat="server" EmptyMessage="Select.." DataTextField="PROD_NAME" DataValueField="PROD_ID">
                            </telerik:RadComboBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>

                            <telerik:RadComboBox ID="RadCmbProdHdr" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="RadCmbProdHdr_SelectedIndexChanged" runat="server" EmptyMessage="Select.." DataTextField="PROD_NAME" DataValueField="PROD_ID"></telerik:RadComboBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </telerik:GridTemplateColumn>
                  
                      <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Item amount" UniqueName="ITEM_AMT" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="itemamt" Width="90%" runat="server" Text='<%# Eval("ITEM_AMT") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadNumericTextBox ID="itemamt" AutoPostBack="true" OnTextChanged="itemamt_TextChanged" runat="server" Text='<%# Eval("ITEM_AMT") %>'></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadNumericTextBox ID="itemamt" AutoPostBack="true" OnTextChanged="itemamt_TextChanged" runat="server"></telerik:RadNumericTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Is Gojek" UniqueName="IS_GOJEK" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="isgojeklbl" Width="90%" runat="server" Text='<%# Eval("IS_GOJEK") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadCheckBox ID="isgojek" runat="server" AutoPostBack="true" OnClick="isgojek_CheckedChanged"></telerik:RadCheckBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadCheckBox ID="isgojek" runat="server" AutoPostBack="true" OnClick="isgojek_CheckedChanged"></telerik:RadCheckBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>   
                    <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Total" UniqueName="PRICE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" ShowFilterIcon="false" AutoPostBackOnFilter="true" AndCurrentFilterFunction="Contains">
                        <ItemTemplate>
                            <asp:Label ID="price" Width="90%" runat="server" Text='<%# Eval("PRICE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadNumericTextBox ID="price" runat="server" ReadOnly="true" Text='<%# Eval("PRICE") %>'></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadNumericTextBox ID="price" ReadOnly="true" runat="server"></telerik:RadNumericTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                   
                   <%-- <telerik:GridBoundColumn DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UPDATE_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>--%>
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
                    <HeaderContextMenu RenderMode="Auto">
                    </HeaderContextMenu>
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
              <asp:HiddenField ID="HdfRetrieveID" runat="server" />
                <asp:HiddenField ID="HdfSelectedRow" runat="server" />
        </div>
    </telerik:RadAjaxPanel>
    <telerik:RadScriptBlock runat="server">
        <script>
            $(document).ready(function () {
<%--            $find('<%=rgTransIn.ClientID %>').get_masterTableView().showFilterItem();--%>
        });
       function HideFilter() {
            window.$find('<%=rgTransIn.ClientID %>').get_masterTableView().hideFilterItem();
        }

        function ShowFilter() {
            window.$find('<%=rgTransIn.ClientID %>').get_masterTableView().showFilterItem();
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
            function rgTransIn_RowSelected(sender, eventArgs) {
                var grid = window.$find('<%# rgTransIn.ClientID%>');
                var masterTableView = grid.get_masterTableView();
                rgTransIn_SelectRow(eventArgs.get_itemIndexHierarchical(), masterTableView.get_currentPageIndex(), masterTableView.get_pageSize());
            }
            function rgTransIn_SelectRow(rowNo, pageIndex, pageSize) {
                var grid = window.$find('<%# rgTransIn.ClientID %>');
                var masterTableView = grid.get_masterTableView();
                var dataItems = masterTableView.get_dataItems();
                if (rowNo >= 0 && rowNo < dataItems.length) {
                    try {
                        dataItems[rowNo].set_selected(true);
                        var keyid = dataItems[rowNo].getDataKeyValue("TRANS_CODE");
                        FillKeyAndIndex(keyid, rowNo + pageIndex * pageSize);
                    } catch (e) {

                    }
                }
            }

            function FillKeyAndIndex(key, index) {
                var hdValue = document.getElementById('<%# HdfRetrieveID.ClientID %>');
            var hdIndexValue = document.getElementById('<%# HdfSelectedRow.ClientID %>');
                hdValue.value = key;
                console.log("key: " + hdValue.value);
                hdIndexValue.value = index;
                console.log("index: " + hdIndexValue.value);
            }
    </script>
    </telerik:RadScriptBlock>
    
</asp:Content>

