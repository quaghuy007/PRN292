namespace StudentSystem
{
    partial class Schedulecs
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
            this.dsChedule = new System.Windows.Forms.DataGridView();
            this.slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsChedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dsChedule
            // 
            this.dsChedule.AllowUserToOrderColumns = true;
            this.dsChedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsChedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slot,
            this.monday,
            this.tuesday,
            this.wednesday,
            this.thursday,
            this.friday,
            this.saturday,
            this.sunday});
            this.dsChedule.Location = new System.Drawing.Point(13, 56);
            this.dsChedule.Name = "dsChedule";
            this.dsChedule.RowHeadersWidth = 51;
            this.dsChedule.RowTemplate.Height = 24;
            this.dsChedule.Size = new System.Drawing.Size(1059, 287);
            this.dsChedule.TabIndex = 0;
            // 
            // slot
            // 
            this.slot.HeaderText = "";
            this.slot.MinimumWidth = 6;
            this.slot.Name = "slot";
            this.slot.Width = 125;
            // 
            // monday
            // 
            this.monday.HeaderText = "Monday";
            this.monday.MinimumWidth = 6;
            this.monday.Name = "monday";
            this.monday.Width = 125;
            // 
            // tuesday
            // 
            this.tuesday.HeaderText = "TuesDay";
            this.tuesday.MinimumWidth = 6;
            this.tuesday.Name = "tuesday";
            this.tuesday.Width = 125;
            // 
            // wednesday
            // 
            this.wednesday.HeaderText = "WednesDay";
            this.wednesday.MinimumWidth = 6;
            this.wednesday.Name = "wednesday";
            this.wednesday.Width = 125;
            // 
            // thursday
            // 
            this.thursday.HeaderText = "ThursDay";
            this.thursday.MinimumWidth = 6;
            this.thursday.Name = "thursday";
            this.thursday.Width = 125;
            // 
            // friday
            // 
            this.friday.HeaderText = "Friday";
            this.friday.MinimumWidth = 6;
            this.friday.Name = "friday";
            this.friday.Width = 125;
            // 
            // saturday
            // 
            this.saturday.HeaderText = "SaturDay";
            this.saturday.MinimumWidth = 6;
            this.saturday.Name = "saturday";
            this.saturday.Width = 125;
            // 
            // sunday
            // 
            this.sunday.HeaderText = "SunDay";
            this.sunday.MinimumWidth = 6;
            this.sunday.Name = "sunday";
            this.sunday.Width = 125;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(573, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = " Years :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(321, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = " Date :";
            // 
            // Schedulecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 428);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dsChedule);
            this.Name = "Schedulecs";
            this.Text = "Schedulecs";
            this.Load += new System.EventHandler(this.Schedulecs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsChedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dsChedule;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn slot;
        private System.Windows.Forms.DataGridViewTextBoxColumn monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn sunday;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}