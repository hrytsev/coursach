namespace yt_DesignUI.Forms
{
    partial class WorkersOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkersOperations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yt_Button1 = new yt_DesignUI.yt_Button();
            this.yt_Button2 = new yt_DesignUI.yt_Button();
            this.yt_Button3 = new yt_DesignUI.yt_Button();
            this.yt_Button5 = new yt_DesignUI.yt_Button();
            this.yt_Button6 = new yt_DesignUI.yt_Button();
            this.yt_Button7 = new yt_DesignUI.yt_Button();
            this.yt_Button8 = new yt_DesignUI.yt_Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(-6, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 73);
            this.panel1.TabIndex = 41;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Moccasin;
            this.label1.Location = new System.Drawing.Point(407, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "HrytsevCO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(628, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "Contact number: +";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(808, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 43;
            this.label3.Text = "1543";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(124, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Loading...";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(1038, 247);
            this.dataGridView1.TabIndex = 56;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Operation";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Time";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 438;
            // 
            // yt_Button1
            // 
            this.yt_Button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.yt_Button1.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button1.BackColorGradientEnabled = false;
            this.yt_Button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button1.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorEnabled = false;
            this.yt_Button1.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorOnHoverEnabled = false;
            this.yt_Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button1.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button1.Location = new System.Drawing.Point(12, 371);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RippleColor = System.Drawing.Color.Black;
            this.yt_Button1.Rounding = 75;
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(121, 55);
            this.yt_Button1.TabIndex = 57;
            this.yt_Button1.Text = "←Back ";
            this.yt_Button1.TextHover = null;
            this.yt_Button1.UseDownPressEffectOnClick = false;
            this.yt_Button1.UseRippleEffect = true;
            this.yt_Button1.UseVisualStyleBackColor = false;
            this.yt_Button1.UseZoomEffectOnHover = false;
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // yt_Button2
            // 
            this.yt_Button2.BackColor = System.Drawing.Color.IndianRed;
            this.yt_Button2.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button2.BackColorGradientEnabled = false;
            this.yt_Button2.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button2.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorEnabled = false;
            this.yt_Button2.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorOnHoverEnabled = false;
            this.yt_Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button2.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button2.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button2.Location = new System.Drawing.Point(164, 371);
            this.yt_Button2.Name = "yt_Button2";
            this.yt_Button2.RippleColor = System.Drawing.Color.Black;
            this.yt_Button2.Rounding = 75;
            this.yt_Button2.RoundingEnable = true;
            this.yt_Button2.Size = new System.Drawing.Size(121, 55);
            this.yt_Button2.TabIndex = 58;
            this.yt_Button2.Text = "Exit";
            this.yt_Button2.TextHover = null;
            this.yt_Button2.UseDownPressEffectOnClick = false;
            this.yt_Button2.UseRippleEffect = true;
            this.yt_Button2.UseVisualStyleBackColor = false;
            this.yt_Button2.UseZoomEffectOnHover = false;
            this.yt_Button2.Click += new System.EventHandler(this.yt_Button2_Click);
            // 
            // yt_Button3
            // 
            this.yt_Button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yt_Button3.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button3.BackColorGradientEnabled = false;
            this.yt_Button3.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button3.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button3.BorderColorEnabled = false;
            this.yt_Button3.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button3.BorderColorOnHoverEnabled = false;
            this.yt_Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button3.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button3.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button3.Location = new System.Drawing.Point(303, 371);
            this.yt_Button3.Name = "yt_Button3";
            this.yt_Button3.RippleColor = System.Drawing.Color.Black;
            this.yt_Button3.Rounding = 75;
            this.yt_Button3.RoundingEnable = true;
            this.yt_Button3.Size = new System.Drawing.Size(121, 55);
            this.yt_Button3.TabIndex = 59;
            this.yt_Button3.Text = "Remove";
            this.yt_Button3.TextHover = null;
            this.yt_Button3.UseDownPressEffectOnClick = false;
            this.yt_Button3.UseRippleEffect = true;
            this.yt_Button3.UseVisualStyleBackColor = false;
            this.yt_Button3.UseZoomEffectOnHover = false;
            this.yt_Button3.Click += new System.EventHandler(this.yt_Button3_Click);
            // 
            // yt_Button5
            // 
            this.yt_Button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yt_Button5.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button5.BackColorGradientEnabled = false;
            this.yt_Button5.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button5.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button5.BorderColorEnabled = false;
            this.yt_Button5.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button5.BorderColorOnHoverEnabled = false;
            this.yt_Button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button5.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button5.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button5.Location = new System.Drawing.Point(472, 370);
            this.yt_Button5.Name = "yt_Button5";
            this.yt_Button5.RippleColor = System.Drawing.Color.Black;
            this.yt_Button5.Rounding = 75;
            this.yt_Button5.RoundingEnable = true;
            this.yt_Button5.Size = new System.Drawing.Size(121, 55);
            this.yt_Button5.TabIndex = 61;
            this.yt_Button5.Text = "Photo log";
            this.yt_Button5.TextHover = null;
            this.yt_Button5.UseDownPressEffectOnClick = false;
            this.yt_Button5.UseRippleEffect = true;
            this.yt_Button5.UseVisualStyleBackColor = false;
            this.yt_Button5.UseZoomEffectOnHover = false;
            this.yt_Button5.Click += new System.EventHandler(this.yt_Button5_Click);
            // 
            // yt_Button6
            // 
            this.yt_Button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yt_Button6.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button6.BackColorGradientEnabled = false;
            this.yt_Button6.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button6.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button6.BorderColorEnabled = false;
            this.yt_Button6.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button6.BorderColorOnHoverEnabled = false;
            this.yt_Button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button6.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button6.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button6.Location = new System.Drawing.Point(623, 371);
            this.yt_Button6.Name = "yt_Button6";
            this.yt_Button6.RippleColor = System.Drawing.Color.Black;
            this.yt_Button6.Rounding = 75;
            this.yt_Button6.RoundingEnable = true;
            this.yt_Button6.Size = new System.Drawing.Size(121, 55);
            this.yt_Button6.TabIndex = 62;
            this.yt_Button6.Text = "Edit";
            this.yt_Button6.TextHover = null;
            this.yt_Button6.UseDownPressEffectOnClick = false;
            this.yt_Button6.UseRippleEffect = true;
            this.yt_Button6.UseVisualStyleBackColor = false;
            this.yt_Button6.UseZoomEffectOnHover = false;
            this.yt_Button6.Click += new System.EventHandler(this.yt_Button6_Click);
            // 
            // yt_Button7
            // 
            this.yt_Button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yt_Button7.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button7.BackColorGradientEnabled = false;
            this.yt_Button7.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button7.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button7.BorderColorEnabled = false;
            this.yt_Button7.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button7.BorderColorOnHoverEnabled = false;
            this.yt_Button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button7.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button7.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button7.Location = new System.Drawing.Point(769, 371);
            this.yt_Button7.Name = "yt_Button7";
            this.yt_Button7.RippleColor = System.Drawing.Color.Black;
            this.yt_Button7.Rounding = 75;
            this.yt_Button7.RoundingEnable = true;
            this.yt_Button7.Size = new System.Drawing.Size(121, 55);
            this.yt_Button7.TabIndex = 63;
            this.yt_Button7.Text = "Add New";
            this.yt_Button7.TextHover = null;
            this.yt_Button7.UseDownPressEffectOnClick = false;
            this.yt_Button7.UseRippleEffect = true;
            this.yt_Button7.UseVisualStyleBackColor = false;
            this.yt_Button7.UseZoomEffectOnHover = false;
            this.yt_Button7.Click += new System.EventHandler(this.yt_Button7_Click);
            // 
            // yt_Button8
            // 
            this.yt_Button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yt_Button8.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button8.BackColorGradientEnabled = false;
            this.yt_Button8.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button8.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button8.BorderColorEnabled = false;
            this.yt_Button8.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button8.BorderColorOnHoverEnabled = false;
            this.yt_Button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button8.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button8.ForeColor = System.Drawing.Color.MintCream;
            this.yt_Button8.Location = new System.Drawing.Point(910, 371);
            this.yt_Button8.Name = "yt_Button8";
            this.yt_Button8.RippleColor = System.Drawing.Color.Black;
            this.yt_Button8.Rounding = 75;
            this.yt_Button8.RoundingEnable = true;
            this.yt_Button8.Size = new System.Drawing.Size(121, 55);
            this.yt_Button8.TabIndex = 64;
            this.yt_Button8.Text = "Clear All";
            this.yt_Button8.TextHover = null;
            this.yt_Button8.UseDownPressEffectOnClick = false;
            this.yt_Button8.UseRippleEffect = true;
            this.yt_Button8.UseVisualStyleBackColor = false;
            this.yt_Button8.UseZoomEffectOnHover = false;
            this.yt_Button8.Click += new System.EventHandler(this.yt_Button8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(479, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 37);
            this.label5.TabIndex = 2;
            this.label5.Text = "LOG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(22, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // WorkersOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 493);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yt_Button8);
            this.Controls.Add(this.yt_Button7);
            this.Controls.Add(this.yt_Button6);
            this.Controls.Add(this.yt_Button5);
            this.Controls.Add(this.yt_Button3);
            this.Controls.Add(this.yt_Button2);
            this.Controls.Add(this.yt_Button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "WorkersOperations";
            this.Text = "WorkersOperations";
            this.Load += new System.EventHandler(this.WorkersOperations_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.yt_Button1, 0);
            this.Controls.SetChildIndex(this.yt_Button2, 0);
            this.Controls.SetChildIndex(this.yt_Button3, 0);
            this.Controls.SetChildIndex(this.yt_Button5, 0);
            this.Controls.SetChildIndex(this.yt_Button6, 0);
            this.Controls.SetChildIndex(this.yt_Button7, 0);
            this.Controls.SetChildIndex(this.yt_Button8, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private yt_Button yt_Button1;
        private yt_Button yt_Button2;
        private yt_Button yt_Button3;
        private yt_Button yt_Button5;
        private yt_Button yt_Button6;
        private yt_Button yt_Button7;
        private yt_Button yt_Button8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}