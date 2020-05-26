<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RptGojekCust.aspx.cs" Inherits="OlshoptrackedBAK.Reports.RptGojekCust" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Customer Report" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
    <telerik:RadTabStrip RenderMode="Lightweight" runat="server"
        ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0">
        <Tabs>
            <telerik:RadTab Text="Search" Width="200px" PageViewID="RadPageView1" TabIndex="0"></telerik:RadTab>
            <telerik:RadTab Text="Report" Width="200px" PageViewID="RadPageView2" TabIndex="1"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
        <telerik:RadPageView runat="server" ID="RadPageView1" TabIndex="0">
            <br />
            <telerik:RadPageLayout runat="server">
                <Rows>
                    <telerik:LayoutRow>
                        <Columns>
                            <telerik:LayoutColumn>
                                Customer Selection:
                                    <br />
                                <telerik:RadDropDownList ID="ModeDD" runat="server" Skin="Metro">
                                    <Items>
                                        <telerik:DropDownListItem Text="ALL" Value="ALL" Selected="true" />
                                        <telerik:DropDownListItem Text="GOJEK" Value="GOJEK" />
                                        <telerik:DropDownListItem Text="GRAB" Value="GRAB" />
                                        <telerik:DropDownListItem Text="DIRECT" Value="DIRECT" />
                                    </Items>
                                </telerik:RadDropDownList>
                            </telerik:LayoutColumn>
                         
                            <telerik:LayoutColumn>
                                <br />
                                <telerik:RadButton ID="submit" Text="Submit" runat="server" OnClick="submit_Click" AutoPostBack="true"></telerik:RadButton>
                                <telerik:RadButton ID="Clear" Text="clear" runat="server" OnClientClicked="clear" AutoPostBack="false"></telerik:RadButton>
                            </telerik:LayoutColumn>
                            
                        </Columns>
                    </telerik:LayoutRow>
                </Rows>
            </telerik:RadPageLayout>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2" TabIndex="1">
          
            <telerik:ReportViewer ID="ReportViewer1"
                Width="100%"
                Height="650px" runat="server">
            
            </telerik:ReportViewer>
        </telerik:RadPageView>
    </telerik:RadMultiPage>

    <telerik:RadScriptBlock ID="radSript1" runat="server">
        <script>
            var flag = 0;
        
           <%-- function changing(sender, args) {
                console.log("changing");
                  var checkBox = $find("<%=ismonthly.ClientID%>");
                var isChecked = checkBox.get_checked();
                if (isChecked) {

                } else {

                }
            }--%>
            function clear(sender, args) {
                var Mode = $find('<%= ModeDD.ClientID %>');
                Mode.selectedIndex = 0;

            }
        </script>
    </telerik:RadScriptBlock>

</asp:Content>
