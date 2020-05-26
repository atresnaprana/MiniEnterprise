<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourierCostData.aspx.cs" Inherits="OlshoptrackedBAK.Courier.CouriereCostData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <br />

        <telerik:RadGrid ID="rgCourierCost" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgCourierCost_ItemCommand" OnItemDataBound="rgCourierCost_ItemDataBound" OnNeedDataSource="rgCourierCost_NeedDataSource"
            OnEditCommand="rgCourierCost_EditCommand" OnUpdateCommand="rgCourierCost_UpdateCommand" OnPreRender="rgCourierCost_PreRender" OnDeleteCommand="rgCourierCost_DeleteCommand" OnInsertCommand="rgCourierCost_InsertCommand" OnPageIndexChanged="rgCourierCost_PageIndexChanged" OnPageSizeChanged="rgCourierCost_PageSizeChanged"
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
            <MasterTableView AllowFilteringByColumn="false" EditMode="InPlace" CommandItemDisplay="Top" DataKeyNames="COST_CODE,COURIER_CODE"
                 PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="COST_CODE, COURIER_CODE" Width="150%">
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
                        HeaderText="Code" UniqueName="COST_CODE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("COST_CODE") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("COST_CODE") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("COST_CODE") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Description" UniqueName="COST_DESC" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="desc" Width="90%" runat="server" Text='<%# Eval("COST_DESC") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="desc" Text='<%# Eval("COST_DESC") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="desc" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Cost" UniqueName="COST_AMT" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="cost" Width="90%" runat="server" Text='<%# Eval("COST_AMT") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadNumericTextBox ID="cost" runat="server" Text='<%# Eval("COST_AMT") %>'></telerik:RadNumericTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadNumericTextBox ID="cost" runat="server"></telerik:RadNumericTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    
                      <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Courier" UniqueName="COURIER_DETAIL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana">
                        <ItemTemplate>
                            <asp:Label ID="hdrcode" Width="90%" runat="server" Text='<%# Eval("COURIER_DETAIL") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadComboBox ID="RadCmbCourierHdr" Width="150px" OnLoad="RadCmbCourierHdr_Load" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="COURIER_DETAIL" DataValueField="COURIER_CODE">
                            </telerik:RadComboBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                           
                           <telerik:RadComboBox ID="RadCmbCourierHdr" Width="150px" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="COURIER_DETAIL" DataValueField="COURIER_CODE"></telerik:RadComboBox>
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
