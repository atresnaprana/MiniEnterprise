<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usercontrol.aspx.cs" Inherits="OlshoptrackedBAK.usercontrol" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <telerik:RadAjaxPanel ID="ajaxpanel" runat="server">
        <br />
   
    <telerik:RadLabel runat="server" ID="lblTitle" Text="User Control" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
        <telerik:RadGrid ID="rgUser" ExportSettings-Pdf-AllowPrinting="true" runat="server" Height="750px"
            AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0"
            AllowFilteringByColumn="True" PageSize="5" AllowSorting="True" Style="margin-top: 0"
            OnItemCommand="rgUser_ItemCommand" OnItemDataBound="rgUser_ItemDataBound" OnNeedDataSource="rgUser_NeedDataSource"
            OnEditCommand="rgUser_EditCommand" OnUpdateCommand="rgUser_UpdateCommand" OnPreRender="rgUser_PreRender" OnDeleteCommand="rgUser_DeleteCommand" OnInsertCommand="rgUser_InsertCommand" OnPageIndexChanged="rgUser_PageIndexChanged" OnPageSizeChanged="rgUser_PageSizeChanged"
            EnableLinqExpressions="False" Width="100%">
            <HeaderStyle Width="200px" />
            <PagerStyle AlwaysVisible="true" Position="Bottom" />
            <HeaderContextMenu CssClass="GridContextMenu ">
            </HeaderContextMenu>
            <ClientSettings EnablePostBackOnRowClick="true" Resizing-AllowColumnResize="true">
                <Selecting AllowRowSelect="True" />
                <%-- <ClientEvents OnRowSelected="RgAgnCL_RowSelected" />--%>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="430px" />
            </ClientSettings>
            <MasterTableView AllowFilteringByColumn="false" CommandItemDisplay="Top" DataKeyNames="USER_CODE, USER_LEVEL"
                EditMode="InPlace" PagerStyle-Mode="NextPrevAndNumeric" ClientDataKeyNames="USER_CODE, USER_LEVEL" Width="150%">
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
                        HeaderText="Code" UniqueName="USER_CODE" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="USER_CODE">
                        <ItemTemplate>
                            <asp:Label ID="hdrcodetxt" Width="90%" runat="server" Text='<%# Eval("USER_CODE") %>'></asp:Label>
                            <asp:HiddenField ID="hiddencode" Value='<%# Eval("USER_CODE") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="hdrcodetxt" Text='<%# Eval("USER_CODE") %>' ReadOnly="true" runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label ID="hdrcodetxt" Text="#####" runat="server"></asp:Label>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="User Name" UniqueName="USER_NAME" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="USER_NAME">
                        <ItemTemplate>
                            <asp:Label ID="username" Width="90%" runat="server" Text='<%# Eval("USER_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="username" Text='<%# Eval("USER_NAME") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="username" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="Password" UniqueName="USER_PASS" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="USER_PASS">
                        <ItemTemplate>
                            <asp:Label ID="password" Width="100%" runat="server" Text='<%# Eval("USER_PASS") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="password" TextMode="Password" Text='<%# Eval("USER_PASS") %>' runat="server"></telerik:RadTextBox>
                            <asp:HiddenField ID="passwordhidden" Value='<%# Eval("USER_PASS") %>' runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="password" TextMode="Password" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="User Level" UniqueName="USER_LEVEL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="USER_LEVEL">
                        <ItemTemplate>
                            <asp:Label ID="userlevel" Width="100%" runat="server" Text='<%# Eval("USER_LEVEL") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadButton RenderMode="Lightweight" ID="userlevel" runat="server" ToggleType="CustomToggle" ButtonType="StandardButton">
                            <ToggleStates>
                             <telerik:RadButtonToggleState Text="User" PrimaryIconCssClass="rbToggleCheckbox" />
                             <telerik:RadButtonToggleState Text="Admin" PrimaryIconCssClass="rbToggleCheckboxChecked" />
                            </ToggleStates>
                        </telerik:RadButton>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadButton RenderMode="Lightweight" ID="userlevel" runat="server" ToggleType="CustomToggle" ButtonType="StandardButton">
                                    <ToggleStates>
                                     <telerik:RadButtonToggleState Text="User" PrimaryIconCssClass="rbToggleCheckbox" />
                                     <telerik:RadButtonToggleState Text="Admin" PrimaryIconCssClass="rbToggleCheckboxChecked" />
                                    </ToggleStates>
                                </telerik:RadButton>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn AllowFiltering="false" FilterControlAltText="Filter TemplateColumn column"
                        HeaderText="E-mail" UniqueName="EMAIL" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="EMAIL">
                        <ItemTemplate>
                            <asp:Label ID="email" Width="100%" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadTextBox ID="email" Text='<%# Eval("EMAIL") %>' runat="server"></telerik:RadTextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <telerik:RadTextBox ID="email" runat="server"></telerik:RadTextBox>
                        </InsertItemTemplate>
                        <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="250px" />
                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="UPDATE_DATE" HeaderText="Update On" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Names="Verdana" SortExpression="UPDATE_DATE" UniqueName="UPDATE_DATE" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="true">
                        <HeaderStyle Width="120px" Wrap="false" HorizontalAlign="Left" />
                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="UPDATE_USER" HeaderText="Entry By" HeaderStyle-Font-Size="13px" SortExpression="UPDATE_USER" HeaderStyle-Font-Names="Verdana" UniqueName="UPDATE_USER" ReadOnly="true">
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
