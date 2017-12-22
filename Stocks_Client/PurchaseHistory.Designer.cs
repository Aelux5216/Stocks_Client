namespace Stocks_Client
{
    partial class PurchaseHistory
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
            this.btnBack = new System.Windows.Forms.Button();
            this.dgdDisplay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Puchase history is desplayed below.\r\nPlease press the back button to return " +
    "to viewing page.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(74, 412);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgdDisplay
            // 
            this.dgdDisplay.AllowUserToAddRows = false;
            this.dgdDisplay.AllowUserToDeleteRows = false;
            this.dgdDisplay.AllowUserToResizeColumns = false;
            this.dgdDisplay.AllowUserToResizeRows = false;
            this.dgdDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgdDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgdDisplay.Location = new System.Drawing.Point(74, 78);
            this.dgdDisplay.MultiSelect = false;
            this.dgdDisplay.Name = "dgdDisplay";
            this.dgdDisplay.ReadOnly = true;
            this.dgdDisplay.RowHeadersVisible = false;
            this.dgdDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgdDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdDisplay.Size = new System.Drawing.Size(619, 328);
            this.dgdDisplay.TabIndex = 4;
            // 
            // PurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 476);
            this.Controls.Add(this.dgdDisplay);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseHistory";
            this.Text = "PurchaseHistory";
            this.Shown += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgdDisplay;
    }
}