namespace OlshoptrackedBAK.Reports
{
    partial class RptCustomer
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
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.htmlTextBox2 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox3 = new Telerik.Reporting.HtmlTextBox();
            this.htmlTextBox1 = new Telerik.Reporting.HtmlTextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.htmlTextBox4 = new Telerik.Reporting.HtmlTextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9897916316986084D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Customer ID";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.1437487602233887D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Customer Name";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1275010108947754D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Customer Phone";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D);
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.9897935390472412D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(7.1437454223632812D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.1275010108947754D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox2);
            this.table1.Body.SetCellContent(0, 1, this.textBox4);
            this.table1.Body.SetCellContent(0, 2, this.textBox6);
            tableGroup1.Name = "tableGroup";
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "tableGroup1";
            tableGroup2.ReportItem = this.textBox3;
            tableGroup3.Name = "tableGroup2";
            tableGroup3.ReportItem = this.textBox5;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.DataSource = this.objectDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox4,
            this.textBox6,
            this.textBox1,
            this.textBox3,
            this.textBox5});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.table1.Name = "table1";
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "detailTableGroup";
            this.table1.RowGroups.Add(tableGroup4);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.261039733886719D), Telerik.Reporting.Drawing.Unit.Cm(1.2170833349227905D));
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9897916316986084D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.CUST_ID";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.1437487602233887D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.CUST_NAME";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1275010108947754D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= Fields.PHONE";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(OlshoptrackedBAK.ReportDataSet.ReportCustomerDtDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.htmlTextBox2,
            this.htmlTextBox3,
            this.htmlTextBox1});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // htmlTextBox2
            // 
            this.htmlTextBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.htmlTextBox2.Name = "htmlTextBox2";
            this.htmlTextBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999997615814209D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.htmlTextBox2.Style.Font.Bold = true;
            this.htmlTextBox2.Style.Font.Underline = false;
            this.htmlTextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.htmlTextBox2.Value = "Tertanda";
            // 
            // htmlTextBox3
            // 
            this.htmlTextBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(1.6001008749008179D));
            this.htmlTextBox3.Name = "htmlTextBox3";
            this.htmlTextBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9999992847442627D), Telerik.Reporting.Drawing.Unit.Cm(0.79989951848983765D));
            this.htmlTextBox3.Style.Font.Bold = true;
            this.htmlTextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.htmlTextBox3.Value = "Oemah Jowo";
            // 
            // htmlTextBox1
            // 
            this.htmlTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.999898910522461D), Telerik.Reporting.Drawing.Unit.Cm(1.4000009298324585D));
            this.htmlTextBox1.Name = "htmlTextBox1";
            this.htmlTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(0.9999995231628418D));
            this.htmlTextBox1.Style.Font.Italic = true;
            this.htmlTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.htmlTextBox1.Value = "{Now()}";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.htmlTextBox4});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // htmlTextBox4
            // 
            this.htmlTextBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209D));
            this.htmlTextBox4.Name = "htmlTextBox4";
            this.htmlTextBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.799899101257324D), Telerik.Reporting.Drawing.Unit.Cm(1.0000001192092896D));
            this.htmlTextBox4.Style.Font.Bold = true;
            this.htmlTextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.htmlTextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.htmlTextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.htmlTextBox4.Value = "Daftar Customer Oemah Jowo";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.3000001907348633D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // RptCustomer
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
            this.Name = "RptCustomer";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.LetterPlus;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(16.100000381469727D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.HtmlTextBox htmlTextBox2;
        private Telerik.Reporting.HtmlTextBox htmlTextBox3;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.HtmlTextBox htmlTextBox1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.HtmlTextBox htmlTextBox4;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
    }
}