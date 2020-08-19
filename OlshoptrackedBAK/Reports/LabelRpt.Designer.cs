namespace OlshoptrackedBAK.Reports
{
    partial class LabelRpt
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229171931743622D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.1322917640209198D);
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229171931743622D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3.8847916126251221D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox11,
            this.table1});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9988508736714721E-05D), Telerik.Reporting.Drawing.Unit.Cm(9.9988508736714721E-05D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4197998046875D), Telerik.Reporting.Drawing.Unit.Cm(0.36760836839675903D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Value = "Resto Oemah Jowo Pondok Kelapa";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.98539399006404E-05D), Telerik.Reporting.Drawing.Unit.Cm(0.76770830154418945D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.29979997873306274D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Value = "= Now()";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.267708420753479D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.29999995231628418D));
            this.textBox3.Value = "PIN: {Fields.PIN}";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332D), Telerik.Reporting.Drawing.Unit.Cm(0.36790847778320312D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4197998046875D), Telerik.Reporting.Drawing.Unit.Cm(0.299999862909317D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Value = "081318955863";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.7677083015441895D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4199004173278809D), Telerik.Reporting.Drawing.Unit.Cm(0.29999995231628418D));
            this.textBox11.Value = "Customer: {Fields.CUST_NAME}";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(OlshoptrackedBAK.ReportDataSet.BonDtDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // textBox16
            // 
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1546335220336914D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.StyleName = "";
            this.textBox16.Value = "=IIf(Fields.AMOUNTCREDIT = 0, \"\", Fields.AMOUNTCREDIT)";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0294275283813477D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0.81514543294906616D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.6266285181045532D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox9);
            this.table1.Body.SetCellContent(0, 1, this.textBox14);
            this.table1.Body.SetCellContent(0, 2, this.textBox15);
            this.table1.Body.SetCellContent(1, 0, this.textBox18);
            this.table1.Body.SetCellContent(1, 1, this.textBox20);
            this.table1.Body.SetCellContent(1, 2, this.textBox22);
            tableGroup1.Name = "tableGroup";
            tableGroup1.ReportItem = this.textBox27;
            tableGroup2.Name = "tableGroup2";
            tableGroup2.ReportItem = this.textBox31;
            tableGroup3.Name = "group";
            tableGroup3.ReportItem = this.textBox33;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.DataSource = this.objectDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox14,
            this.textBox15,
            this.textBox18,
            this.textBox20,
            this.textBox22,
            this.textBox27,
            this.textBox31,
            this.textBox33});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332D), Telerik.Reporting.Drawing.Unit.Cm(2.067908763885498D));
            this.table1.Name = "table1";
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "detailTableGroup";
            tableGroup5.Name = "group2";
            this.table1.RowGroups.Add(tableGroup4);
            this.table1.RowGroups.Add(tableGroup5);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.4712014198303223D), Telerik.Reporting.Drawing.Unit.Cm(1.7170833349227905D));
            this.table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.81514549255371094D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "= Fields.Jml";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6266285181045532D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.StyleName = "";
            this.textBox15.Value = "= Fields.AMOUNT";
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.81514549255371094D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.StyleName = "";
            // 
            // textBox22
            // 
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6266285181045532D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox22.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.StyleName = "";
            this.textBox22.Value = "=Sum(Fields.AMOUNT)";
            // 
            // textBox31
            // 
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.81514549255371094D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox31.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox31.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox31.Style.Font.Bold = true;
            this.textBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox31.Value = "Jml";
            // 
            // textBox33
            // 
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6266285181045532D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox33.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox33.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox33.Style.Font.Bold = true;
            this.textBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox33.StyleName = "";
            this.textBox33.Value = "Harga";
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0294275283813477D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.StyleName = "";
            this.textBox18.Value = "Total";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0294275283813477D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "=Fields.PRODUCT_NAME";
            // 
            // textBox27
            // 
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0294275283813477D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox27.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Strikeout = false;
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Value = "Item";
            // 
            // LabelRpt
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "LabelRpt";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D), Telerik.Reporting.Drawing.Unit.Mm(10D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(85D), Telerik.Reporting.Drawing.Unit.Mm(148D));
            this.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox33;
    }
}