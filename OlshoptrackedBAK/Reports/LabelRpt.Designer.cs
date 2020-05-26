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
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.textBox2 = new Telerik.Reporting.TextBox();
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
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0.26458284258842468D)));
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.5502078533172607D)));
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.9651288986206055D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(5.2652082443237305D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            this.list1.Body.SetCellContent(0, 2, this.textBox1);
            this.list1.Body.SetCellContent(0, 1, this.textBox2);
            tableGroup1.Name = "ColumnGroup";
            tableGroup2.Name = "group1";
            tableGroup3.Name = "group";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.ColumnGroups.Add(tableGroup2);
            this.list1.ColumnGroups.Add(tableGroup3);
            this.list1.DataSource = this.objectDataSource1;
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.textBox1,
            this.textBox2});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Cm(0.66770833730697632D));
            this.list1.Name = "list1";
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "DetailGroup";
            this.list1.RowGroups.Add(tableGroup4);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.7799186706542969D), Telerik.Reporting.Drawing.Unit.Cm(5.2652082443237305D));
            // 
            // panel1
            // 
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.26458284258842468D), Telerik.Reporting.Drawing.Unit.Cm(5.2652082443237305D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.9651284217834473D), Telerik.Reporting.Drawing.Unit.Cm(5.2652082443237305D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.StyleName = "";
            this.textBox1.Value = "{Fields.CUST_NAME} \r\n\r\n{Fields.CUST_ADDRESS}\r\n\r\n{Fields.CUST_PHONE1}\r\n\r\n{Fields.O" +
    "LSHOP_NAME}\r\n\r\n{Fields.COST_DESC}\r\n\r\n{Fields.TRANS_CODE}";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229171931743622D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(6.4677085876464844D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(OlshoptrackedBAK.ReportDataSet.AddressesDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5502077341079712D), Telerik.Reporting.Drawing.Unit.Cm(5.2652082443237305D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "To:\r\n\r\n\r\n\r\nPhone:\r\n\r\nFrom:\r\n\r\nVIA:\r\n\r\n\r\nCode:";
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
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(9.2999992370605469D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
    }
}