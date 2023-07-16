namespace Flex.Revit
{
    partial class Column
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
            this.label1 = new System.Windows.Forms.Label();
            this.combo_layer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_ColumnType = new System.Windows.Forms.ComboBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Layer";
            // 
            // combo_layer
            // 
            this.combo_layer.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.combo_layer.FormattingEnabled = true;
            this.combo_layer.Location = new System.Drawing.Point(40, 85);
            this.combo_layer.Name = "combo_layer";
            this.combo_layer.Size = new System.Drawing.Size(334, 24);
            this.combo_layer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(42, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Column Type";
            // 
            // combo_ColumnType
            // 
            this.combo_ColumnType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.combo_ColumnType.FormattingEnabled = true;
            this.combo_ColumnType.Location = new System.Drawing.Point(40, 174);
            this.combo_ColumnType.Name = "combo_ColumnType";
            this.combo_ColumnType.Size = new System.Drawing.Size(334, 24);
            this.combo_ColumnType.TabIndex = 1;
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Create.Location = new System.Drawing.Point(252, 242);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(121, 27);
            this.btn_Create.TabIndex = 2;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // Column
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(429, 302);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.combo_ColumnType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_layer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Column";
            this.Text = "Column";
            this.Load += new System.EventHandler(this.Column_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_layer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_ColumnType;
        private System.Windows.Forms.Button btn_Create;
    }
}