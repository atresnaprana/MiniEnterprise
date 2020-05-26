<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="OlshoptrackedBAK.DashBoard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div style="padding-left:50%;">
                <telerik:RadLabel runat="server" ID="lblTitle" Text="Dashboard" Font-Size="X-Large" Font-Bold="true" style="text-align: center;"></telerik:RadLabel>
    </div>
    <br />
    <table>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td>
                              Periode Product:
                                    <br />
                                <telerik:RadMonthYearPicker ID="Periode" runat="server" OnSelectedDateChanged="Periode_SelectedDateChanged" AutoPostBack="true"></telerik:RadMonthYearPicker>
                        </td>
                         <td style="width:20px;"></td>
                        <td>
                             Range Product:
                                    <br />
                              <telerik:RadDropDownList ID="ModeDD" runat="server" Skin="Metro" OnSelectedIndexChanged="ModeDD_SelectedIndexChanged" AutoPostBack="true">
                                    <Items>
                                        <telerik:DropDownListItem Text="5" Value="5" Selected="true" />
                                        <telerik:DropDownListItem Text="10" Value="10" />
                                        <telerik:DropDownListItem Text="15" Value="15" />
                                        <telerik:DropDownListItem Text="20" Value="20" />
                                    </Items>
                                </telerik:RadDropDownList>
                        </td>
                    </tr>
                </table>
              

            </td>
              <td style="width:400px;">

            </td>
             <td align="center">
                 <table>
                     <tr>
                         <td>
                              Periode Customer:
                                    <br />
                                <telerik:RadMonthYearPicker ID="PeriodeCust" runat="server" OnSelectedDateChanged="PeriodeCust_SelectedDateChanged" AutoPostBack="true"></telerik:RadMonthYearPicker>
                         </td>
                           <td style="width:20px;"></td>
                        <td>
                             Range Customer:
                                    <br />
                              <telerik:RadDropDownList ID="ModeDDCust" runat="server" Skin="Metro" OnSelectedIndexChanged="ModeDDCust_SelectedIndexChanged" AutoPostBack="true">
                                    <Items>
                                        <telerik:DropDownListItem Text="5" Value="5" Selected="true" />
                                        <telerik:DropDownListItem Text="10" Value="10" />
                                        <telerik:DropDownListItem Text="15" Value="15" />
                                        <telerik:DropDownListItem Text="20" Value="20" />
                                    </Items>
                                </telerik:RadDropDownList>
                        </td>
                     </tr>
                 </table>
               

            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadHtmlChart ID="RCHTop5Product" runat="server" Height="400" Width="500">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="TOTAL2" Name="">
                                <TooltipsAppearance Visible="true"></TooltipsAppearance>
                            </telerik:ColumnSeries>

                        </Series>
                        <XAxis DataLabelsField="PROD_NAME">
                            <LabelsAppearance>
                            </LabelsAppearance>
                            <MajorGridLines Visible="true"></MajorGridLines>
                            <MinorGridLines Visible="true"></MinorGridLines>
                        </XAxis>
                        <YAxis>
                            <LabelsAppearance></LabelsAppearance>

                            <MinorGridLines Visible="false"></MinorGridLines>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Top 5 Selling Menu">
                        <Appearance Align="Center" BackgroundColor="Transparent" Position="Top"></Appearance>
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
            <td style="width:400px;">

            </td>
            <td>
                <telerik:RadHtmlChart ID="RCHTop5Customer" runat="server" Height="400" Width="500">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="Rev" Name="">
                                <TooltipsAppearance Visible="true"></TooltipsAppearance>
                            </telerik:ColumnSeries>

                        </Series>
                        <%--<XAxis DataLabelsField="name">--%>
                        <XAxis DataLabelsField="name">
                            <LabelsAppearance>
                            </LabelsAppearance>
                            <MajorGridLines Visible="true"></MajorGridLines>
                            <MinorGridLines Visible="true"></MinorGridLines>
                        </XAxis>
                        <YAxis>
                            <LabelsAppearance></LabelsAppearance>

                            <MinorGridLines Visible="false"></MinorGridLines>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Top 5 Customers">
                        <Appearance Align="Center" BackgroundColor="Transparent" Position="Top"></Appearance>
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadHtmlChart ID="RCHTShopping" runat="server" Height="400" Width="100%">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="Rev" Name="">
                                <TooltipsAppearance Visible="true"></TooltipsAppearance>
                            </telerik:ColumnSeries>

                        </Series>
                        <%--<XAxis DataLabelsField="name">--%>
                        <XAxis DataLabelsField="name">
                            <LabelsAppearance>
                            </LabelsAppearance>
                            <MajorGridLines Visible="true"></MajorGridLines>
                            <MinorGridLines Visible="true"></MinorGridLines>
                        </XAxis>
                        <YAxis>
                            <LabelsAppearance></LabelsAppearance>

                            <MinorGridLines Visible="false"></MinorGridLines>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Last 3 months cost">
                        <Appearance Align="Center" BackgroundColor="Transparent" Position="Top"></Appearance>
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
             <td style="width:400px;">

            </td>
            <td>
                <telerik:RadHtmlChart ID="RCHTProfit" runat="server" Height="400" Width="100%">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="Rev" Name="">
                                <TooltipsAppearance Visible="true"></TooltipsAppearance>
                            </telerik:ColumnSeries>

                        </Series>
                        <%--<XAxis DataLabelsField="name">--%>
                        <XAxis DataLabelsField="name">
                            <LabelsAppearance>
                            </LabelsAppearance>
                            <MajorGridLines Visible="true"></MajorGridLines>
                            <MinorGridLines Visible="true"></MinorGridLines>
                        </XAxis>
                        <YAxis>
                            <LabelsAppearance></LabelsAppearance>

                            <MinorGridLines Visible="false"></MinorGridLines>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Last 5 Month profit and loss">
                        <Appearance Align="Center" BackgroundColor="Transparent" Position="Top"></Appearance>
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
    </table>
   
</asp:Content>
