namespace Flex.Revit
{
    partial class Footing
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.combo_FootingType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_layer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Create.Location = new System.Drawing.Point(270, 234);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(121, 27);
            this.btn_Create.TabIndex = 7;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // combo_FootingType
            // 
            this.combo_FootingType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.combo_FootingType.FormattingEnabled = true;
            this.combo_FootingType.Location = new System.Drawing.Point(58, 166);
            this.combo_FootingType.Name = "combo_FootingType";
            this.combo_FootingType.Size = new System.Drawing.Size(334, 24);
            this.combo_FootingType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(60, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Footing Type";
            // 
            // combo_layer
            // 
            this.combo_layer.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.combo_layer.FormattingEnabled = true;
            this.combo_layer.Location = new System.Drawing.Point(58, 77);
            this.combo_layer.Name = "combo_layer";
            this.combo_layer.Size = new System.Drawing.Size(334, 24);
            this.combo_layer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Layer";
            // 
            // Footing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(475, 336);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.combo_FootingType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_layer);
            this.Controls.Add(this.label1);
            this.Name = "Footing";
            this.Text = "Footing";
            this.Load += new System.EventHandler(this.Footing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.ComboBox combo_FootingType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_layer;
        private System.Windows.Forms.Label label1;
    }
}