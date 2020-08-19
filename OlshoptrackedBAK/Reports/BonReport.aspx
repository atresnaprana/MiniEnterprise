<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BonReport.aspx.cs" Inherits="OlshoptrackedBAK.Reports.BonReport" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
    <telerik:RadLabel runat="server" ID="lblTitle" Text="Profit and Loss Report" Font-Size="X-Large" Font-Bold="true"></telerik:RadLabel>
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
                                Date:
                                    <br />
                                <telerik:RadDatePicker ID="dates" runat="server" AutoPostBack="true" OnSelectedDateChanged="dates_SelectedDateChanged"></telerik:RadDatePicker>
                            </telerik:LayoutColumn>
                            <telerik:LayoutColumn>
                                Transaction:
                                    <br />
                                <telerik:RadComboBox ID="RadCmbTrans" Width="150px" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="DESCRIPTION" DataValueField="CUST_ID">
                                </telerik:RadComboBox>

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
            window.onload = function () {
                var datectrl = $find('<%= dates.ClientID %>');
                var selectedctrl = datectrl.get_selectedDate();
                var btn = $find('<%= submit.ClientID %>');
                if (selectedctrl != null) {
                    btn.set_enabled(true);
                } else {
                    btn.set_enabled(false);
                }

            };
           <%-- function changing(sender, args) {
                console.log("changing");
                  var checkBox = $find("<%=ismonthly.ClientID%>");
                var isChecked = checkBox.get_checked();
                if (isChecked) {

                } else {

                }
            }--%>
            function clear(sender, args) {
                var datectrl = $find('<%= dates.ClientID %>');
                datectrl.clear();
                var btn = $find('<%= submit.ClientID %>');
                btn.set_enabled(false);

            }
            function DateChange(sender, args) {
                                var btn = $find('<%= submit.ClientID %>');
                var datectrl = $find('<%= dates.ClientID %>');
                var selectedctrl = datectrl.get_selectedDate();
                var selectedTo = dateto.get_selectedDate();
                if (selectedctrl != null) {
                    flag = 1;
                    btn.set_enabled(true);

                } else {
                    flag = 0;
                    btn.set_enabled(false);

                }

            }
        </script>
    </telerik:RadScriptBlock>

</asp:Content>
