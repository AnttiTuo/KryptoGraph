namespace KryptoGraph
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkedListBoxCryptos = new System.Windows.Forms.CheckedListBox();
            this.buttonAddCrypto = new System.Windows.Forms.Button();
            this.textBoxCrypto = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.Label();
            this.labelCryptoPrices = new System.Windows.Forms.Label();
            this.listBoxPriceTracker = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent50;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.Visible = false;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 156);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "BTC";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1208, 534);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.BackColor = System.Drawing.Color.AliceBlue;
            title1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            title1.BorderWidth = 0;
            title1.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.ShadowOffset = 1;
            title1.Text = "Crypto Prices";
            title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow;
            this.chart1.Titles.Add(title1);
            // 
            // checkedListBoxCryptos
            // 
            this.checkedListBoxCryptos.CheckOnClick = true;
            this.checkedListBoxCryptos.FormattingEnabled = true;
            this.checkedListBoxCryptos.Items.AddRange(new object[] {
            "BTCEUR",
            "ETHEUR",
            "DOGEEUR",
            "XRPEUR",
            "SHIBEUR"});
            this.checkedListBoxCryptos.Location = new System.Drawing.Point(12, 10);
            this.checkedListBoxCryptos.Name = "checkedListBoxCryptos";
            this.checkedListBoxCryptos.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxCryptos.TabIndex = 2;
            // 
            // buttonAddCrypto
            // 
            this.buttonAddCrypto.Location = new System.Drawing.Point(162, 117);
            this.buttonAddCrypto.Name = "buttonAddCrypto";
            this.buttonAddCrypto.Size = new System.Drawing.Size(170, 33);
            this.buttonAddCrypto.TabIndex = 3;
            this.buttonAddCrypto.Text = "Add";
            this.buttonAddCrypto.UseVisualStyleBackColor = true;
            // 
            // textBoxCrypto
            // 
            this.textBoxCrypto.Location = new System.Drawing.Point(148, 84);
            this.textBoxCrypto.Name = "textBoxCrypto";
            this.textBoxCrypto.Size = new System.Drawing.Size(195, 20);
            this.textBoxCrypto.TabIndex = 4;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(145, 68);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(283, 13);
            this.Info.TabIndex = 5;
            this.Info.Text = "Write your crypto abbreviation and currency (ex. BTCEUR)";
            // 
            // labelCryptoPrices
            // 
            this.labelCryptoPrices.AutoSize = true;
            this.labelCryptoPrices.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCryptoPrices.Location = new System.Drawing.Point(503, 9);
            this.labelCryptoPrices.Name = "labelCryptoPrices";
            this.labelCryptoPrices.Size = new System.Drawing.Size(40, 18);
            this.labelCryptoPrices.TabIndex = 6;
            this.labelCryptoPrices.Text = "Price";
            // 
            // listBoxPriceTracker
            // 
            this.listBoxPriceTracker.FormattingEnabled = true;
            this.listBoxPriceTracker.Location = new System.Drawing.Point(506, 30);
            this.listBoxPriceTracker.Name = "listBoxPriceTracker";
            this.listBoxPriceTracker.Size = new System.Drawing.Size(257, 95);
            this.listBoxPriceTracker.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 691);
            this.Controls.Add(this.listBoxPriceTracker);
            this.Controls.Add(this.labelCryptoPrices);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.textBoxCrypto);
            this.Controls.Add(this.buttonAddCrypto);
            this.Controls.Add(this.checkedListBoxCryptos);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckedListBox checkedListBoxCryptos;
        private System.Windows.Forms.Button buttonAddCrypto;
        private System.Windows.Forms.TextBox textBoxCrypto;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label labelCryptoPrices;
        private System.Windows.Forms.ListBox listBoxPriceTracker;
    }
}

