<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionIn2pagestyle.aspx.cs" Inherits="OlshoptrackedBAK.Transaction.TransactionIn2pagestyle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="Browse" Width="200px" PageViewID="RadPageView1"></telerik:RadTab>
                <telerik:RadTab Text="Form" Width="200px" PageViewID="RadPageView2"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <br />
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                 <div class="FilterButton" id="FiltBtn">
                        <telerik:RadButton ID="Filter" runat="server" Font-Names="Verdana" GroupName="Toggle" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Show Filter" OnClientClicked="OnGridCreated" AutoPostBack="false"></telerik:RadButton>
                    </div>
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
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnGridCreated="OnGridCreated" />
                        <ClientEvents OnRowSelected="rgTransIn_RowSelected" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="430px" />
                    </ClientSettings>
                    <MasterTableView AllowFilteringByColumn="false" DataKeyNames="TRANS_CODE,CUST_CODE,COURIER_CODE,COST_CODE"
                        PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="TRANS_CODE,CUST_CODE,COURIER_CODE,COST_CODE" Width="150%">
                        <CommandItemSettings AddNewRecordText="Add Record" ShowRefreshButton="true" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>

                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Code" UniqueName="TRANS_CODE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("TRANS_CODE") %>'></asp:Label>
                                    <asp:HiddenField ID="hiddencode" Value='<%# Eval("TRANS_CODE") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("TRANS_CODE") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <telerik:RadTextBox ID="hdrcodetxt" ReadOnly="false" runat="server"></telerik:RadTextBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Detail" UniqueName="TRANS_DETAIL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="detail" Width="90%" runat="server" Text='<%# Eval("TRANS_DETAIL") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadTextBox ID="detail" Text='<%# Eval("TRANS_DETAIL") %>' runat="server"></telerik:RadTextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <telerik:RadTextBox ID="detail" runat="server"></telerik:RadTextBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Customer" UniqueName="CUST_NAME" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="hdrcustcode" Width="90%" runat="server" Text='<%# Eval("CUST_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadComboBox ID="RadCmbCustHdr" Width="150px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CUST_NAME" DataValueField="CUST_CODE">
                                    </telerik:RadComboBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>

                                    <telerik:RadComboBox ID="RadCmbCustHdr" Width="150px" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="CUST_NAME" DataValueField="CUST_CODE"></telerik:RadComboBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Courier" UniqueName="COURIER_DETAIL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="hdrcouriercode" Width="90%" runat="server" Text='<%# Eval("COURIER_DETAIL") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadComboBox ID="RadCmbCourierHdr" Width="150px" AllowCustomText="true" OnSelectedIndexChanged="RadCmbCourierHdr_SelectedIndexChanged" AutoPostBack="true" runat="server" EmptyMessage="Select.." DataTextField="COURIER_DETAIL" DataValueField="COURIER_CODE">
                                    </telerik:RadComboBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>

                                    <telerik:RadComboBox ID="RadCmbCourierHdr" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="RadCmbCourierHdr_SelectedIndexChanged" OnItemChecked="RadCmbCourierHdr_ItemChecked" runat="server" EmptyMessage="Select.." DataTextField="COURIER_DETAIL" DataValueField="COURIER_CODE"></telerik:RadComboBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Ongkir" UniqueName="COST_DESC" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="hdrcostcode" Width="90%" runat="server" Text='<%# Eval("COST_DESC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadComboBox ID="RadCmbCostHdr" Width="100px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="COST_DESC" DataValueField="COST_CODE">
                                    </telerik:RadComboBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>

                                    <telerik:RadComboBox ID="RadCmbCostHdr" Width="100px" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="COST_DESC" DataValueField="COST_CODE"></telerik:RadComboBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Trans Date" UniqueName="TRANS_DATE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="transdate" Width="90%" runat="server" Text='<%# Eval("TRANS_DATE", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadDatePicker ID="transdate" runat="server" Width="120px" DateInput-DisplayDateFormat="dd-MMM-yyyy" SelectedDate='<%# Eval("TRANS_DATE") == DBNull.Value ? null :  (DateTime?)Eval("TRANS_DATE") %>'></telerik:RadDatePicker>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <telerik:RadDatePicker ID="transdate" Width="120px" runat="server"></telerik:RadDatePicker>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                                HeaderText="Total" UniqueName="TRANS_TOTAL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                                <ItemTemplate>
                                    <asp:Label ID="total" Width="90%" runat="server" Text='<%# Eval("TRANS_TOTAL") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadNumericTextBox ID="total" runat="server" Text='<%# Eval("TRANS_TOTAL") %>'></telerik:RadNumericTextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <telerik:RadNumericTextBox ID="total" runat="server"></telerik:RadNumericTextBox>
                                </InsertItemTemplate>
                                <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                                <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                                <ItemStyle Width="120px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UPDATE_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
                                <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                                <ItemStyle Width="120px" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                           
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
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                <table>
                    <tr>
                        <td>
                            <telerik:RadButton runat="server" ID="Retrieve" Text="Retrieve" OnClick="Retrieve_Click"></telerik:RadButton>

                        </td>
                        <td>
                            <telerik:RadButton runat="server" ID="Edits" Text="Edit" OnClick="Edit_Click"></telerik:RadButton>

                        </td>
                         <td>
                            <telerik:RadButton runat="server" ID="Insert" Text="Insert" OnClick="Insert_Click"></telerik:RadButton>

                        </td>
                        <td>
                           
                            <telerik:RadButton runat="server" ID="Delete" Text="Delete" OnClientClicked="DeleteConf" OnClick="Delete_Click"></telerik:RadButton>

                        </td>
                          <td>
                            <telerik:RadButton runat="server" ID="Save" Text="Save" OnClick="Save_Click"></telerik:RadButton>

                        </td>
                    </tr>
                  
                </table>
                <br />
                <telerik:RadPageLayout runat="server">
                    <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Transaction Code: 
                                <br />
                                <telerik:RadTextBox runat="server" ID="transcode"></telerik:RadTextBox>
                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                    <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Transaction Detail: 
                                <br />
                                <telerik:RadTextBox runat="server" ID="transdetail"></telerik:RadTextBox>
                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                      <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Transaction Date: 
                                <br />
                                <telerik:RadDatePicker runat="server" ID="transdate"></telerik:RadDatePicker>
                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                        <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Customer: 
                                <br />
                                <telerik:RadComboBox ID="RadCmbCustHdr" Width="150px" AllowCustomText="true" runat="server" EmptyMessage="Select.." DataTextField="CUST_NAME" DataValueField="CUST_CODE">
                                </telerik:RadComboBox>
                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                    <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                OnlineShop
                                <br />
                                <telerik:RadComboBox ID="RadCmbOnlineShop" Width="150px" AllowCustomText="true" runat="server" EmptyMessage="Select" DataTextField="OLSHOP_NAME" DataValueField="OLSHOP_CODE">

                                </telerik:RadComboBox>
                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                       <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Total Transaction: 
                                <br />
                                <telerik:RadNumericTextBox ID="total" runat="server"></telerik:RadNumericTextBox>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                     <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Courier: 
                                <br />
                                <telerik:RadComboBox ID="RadCmbCourierHdr" Width="150px" AllowCustomText="true" OnSelectedIndexChanged="RadCmbCourierHdr_SelectedIndexChanged" AutoPostBack="true" runat="server" EmptyMessage="Select.." DataTextField="COURIER_DETAIL" DataValueField="COURIER_CODE">
                                </telerik:RadComboBox>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                     <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Courier Cost: 
                                <br />
                                <telerik:RadComboBox ID="RadCmbCostHdr" Width="100px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="COST_DESC" DataValueField="COST_CODE">
                                </telerik:RadComboBox>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                     <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Packed Status: 
                                <br />
                                   <telerik:RadButton RenderMode="Lightweight" ID="PackedStat" runat="server" ToggleType="CustomToggle" ButtonType="StandardButton">
                            <ToggleStates>
                             <telerik:RadButtonToggleState Text="Not Packed" PrimaryIconCssClass="rbToggleCheckbox" Value="N" />
                             <telerik:RadButtonToggleState Text="Packed" PrimaryIconCssClass="rbToggleCheckboxChecked" Value ="Y"/>
                            </ToggleStates>
                        </telerik:RadButton>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                     <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Sent Status: 
                                <br />
                                   <telerik:RadButton RenderMode="Lightweight" ID="SentStat" runat="server" ToggleType="CustomToggle" ButtonType="StandardButton">
                            <ToggleStates>
                             <telerik:RadButtonToggleState Text="Not Sent" PrimaryIconCssClass="rbToggleCheckbox" Value="N"/>
                             <telerik:RadButtonToggleState Text="Sent" PrimaryIconCssClass="rbToggleCheckboxChecked" Value="Y"/>
                            </ToggleStates>
                        </telerik:RadButton>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                      <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Payment Status: 
                                <br />
                                   <telerik:RadButton RenderMode="Lightweight" ID="PaymentStat" runat="server" ToggleType="CustomToggle" ButtonType="StandardButton">
                            <ToggleStates>
                             <telerik:RadButtonToggleState Text="Not Paid" PrimaryIconCssClass="rbToggleCheckbox" Value="N"/>
                             <telerik:RadButtonToggleState Text="Paid" PrimaryIconCssClass="rbToggleCheckboxChecked" Value="P"/>
                            </ToggleStates>
                        </telerik:RadButton>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                      <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Remarks: 
                                <br />
                                <telerik:RadTextBox ID="Remarks" runat="server" TextMode="MultiLine"></telerik:RadTextBox>

                            </telerik:LayoutColumn>
                        </Columns>
                    </telerik:LayoutRow>
                </telerik:RadPageLayout>
            </telerik:RadPageView>
        </telerik:RadMultiPage>

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
    <telerik:RadScriptBlock ID="radSript1" runat="server">
        <script>
            window.onload = function () {
              

            };
            function DeleteConf() {

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
              function HideFilter() {
                window.$find('<%= rgTransIn.ClientID %>').get_masterTableView().hideFilterItem();
            }

            function ShowFilter() {
                console.log("showfilter");
                window.$find('<%= rgTransIn.ClientID %>').get_masterTableView().showFilterItem();
            }

            function OnGridCreated(sender, eventArgs) {
                var btn1 = $find("<%= Filter.ClientID %>");
                if (btn1 != null) {
                    if (btn1.get_checked()) {
                        ShowFilter();
                    } else {
                        HideFilter();
                    }
                }
              
            }

            function rgTransIn_RowSelected(sender, eventArgs) {
                var grid = window.$find('<%= rgTransIn.ClientID%>');
                var masterTableView = grid.get_masterTableView();
                rgTransIn_SelectRow(eventArgs.get_itemIndexHierarchical(), masterTableView.get_currentPageIndex(), masterTableView.get_pageSize());
            }
            function rgTransIn_SelectRow(rowNo, pageIndex, pageSize) {
                var grid = window.$find('<%= rgTransIn.ClientID %>');
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
                var hdValue = document.getElementById('<%= HdfRetrieveID.ClientID %>');
                var hdIndexValue = document.getElementById('<%= HdfSelectedRow.ClientID %>');
                hdValue.value = key;
                console.log("key: " + hdValue.value);
                hdIndexValue.value = index;
                console.log("index: " + hdIndexValue.value);
                var tabstrip = window.$find('<%= RadTabStrip1.ClientID%>');
                var tab = tabstrip.findTabByText("Form");
                if(tab){
                    tab.select();
                }
            }
        </script>
    </telerik:RadScriptBlock>

</asp:Content>
