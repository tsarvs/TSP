namespace TSPConsole
{
    partial class TSPGUI
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSPGUI));
            this.chrtMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.project1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.project2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.project3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.project4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.random100tspToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProcess = new System.Windows.Forms.ToolStripDropDownButton();
            this.geneticAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chrtMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chrtMain
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtMain.ChartAreas.Add(chartArea1);
            this.chrtMain.Location = new System.Drawing.Point(12, 30);
            this.chrtMain.Name = "chrtMain";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chrtMain.Series.Add(series1);
            this.chrtMain.Size = new System.Drawing.Size(1647, 926);
            this.chrtMain.TabIndex = 0;
            this.chrtMain.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.btnProcess});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1671, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.project1ToolStripMenuItem,
            this.project2ToolStripMenuItem,
            this.project3ToolStripMenuItem,
            this.project4ToolStripMenuItem});
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(46, 24);
            this.btnFile.Text = "File";
            // 
            // project1ToolStripMenuItem
            // 
            this.project1ToolStripMenuItem.Name = "project1ToolStripMenuItem";
            this.project1ToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.project1ToolStripMenuItem.Text = "Project 1";
            // 
            // project2ToolStripMenuItem
            // 
            this.project2ToolStripMenuItem.Name = "project2ToolStripMenuItem";
            this.project2ToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.project2ToolStripMenuItem.Text = "Project 2";
            // 
            // project3ToolStripMenuItem
            // 
            this.project3ToolStripMenuItem.Name = "project3ToolStripMenuItem";
            this.project3ToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.project3ToolStripMenuItem.Text = "Project 3";
            // 
            // project4ToolStripMenuItem
            // 
            this.project4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.random100tspToolStripMenuItem});
            this.project4ToolStripMenuItem.Name = "project4ToolStripMenuItem";
            this.project4ToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.project4ToolStripMenuItem.Text = "Project 4";
            // 
            // random100tspToolStripMenuItem
            // 
            this.random100tspToolStripMenuItem.Name = "random100tspToolStripMenuItem";
            this.random100tspToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.random100tspToolStripMenuItem.Text = "Random100.tsp";
            this.random100tspToolStripMenuItem.Click += new System.EventHandler(this.random100tspToolStripMenuItem_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geneticAlgorithmToolStripMenuItem});
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(72, 24);
            this.btnProcess.Text = "Process";
            // 
            // geneticAlgorithmToolStripMenuItem
            // 
            this.geneticAlgorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.bToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.bToolStripMenuItem1});
            this.geneticAlgorithmToolStripMenuItem.Name = "geneticAlgorithmToolStripMenuItem";
            this.geneticAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.geneticAlgorithmToolStripMenuItem.Text = "Genetic Algorithm";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aToolStripMenuItem.Text = "1A";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.bToolStripMenuItem.Text = "1B";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.aToolStripMenuItem1.Text = "2A";
            this.aToolStripMenuItem1.Click += new System.EventHandler(this.aToolStripMenuItem1_Click);
            // 
            // bToolStripMenuItem1
            // 
            this.bToolStripMenuItem1.Name = "bToolStripMenuItem1";
            this.bToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.bToolStripMenuItem1.Text = "2B";
            this.bToolStripMenuItem1.Click += new System.EventHandler(this.bToolStripMenuItem1_Click);
            // 
            // TSPGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 968);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chrtMain);
            this.Name = "TSPGUI";
            this.Text = "TSPGUI";
            ((System.ComponentModel.ISupportInitialize)(this.chrtMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem project1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem project2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem project3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem project4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem random100tspToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btnProcess;
        private System.Windows.Forms.ToolStripMenuItem geneticAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem1;
    }
}