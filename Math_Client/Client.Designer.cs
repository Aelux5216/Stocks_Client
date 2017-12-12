namespace Math_Client
{
    partial class Client
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
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgdDisplay = new System.Windows.Forms.DataGridView();
            this.lblIntro = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnPurchaseHistory = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).BeginInit();
            this.grpAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(646, 446);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(727, 446);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(70, 446);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgdDisplay
            // 
            this.dgdDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdDisplay.Location = new System.Drawing.Point(70, 115);
            this.dgdDisplay.Name = "dgdDisplay";
            this.dgdDisplay.Size = new System.Drawing.Size(732, 325);
            this.dgdDisplay.TabIndex = 3;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblIntro.Location = new System.Drawing.Point(196, 41);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(478, 40);
            this.lblIntro.TabIndex = 4;
            this.lblIntro.Text = "   Welcome to my client for Buying/Selling/Viewing stocks.\r\nPlease select a stock" +
    " for more information or to interact with it.";
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(this.txtBalance);
            this.grpAccount.Controls.Add(this.btnPurchaseHistory);
            this.grpAccount.Controls.Add(this.lblBalance);
            this.grpAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.grpAccount.Location = new System.Drawing.Point(716, 12);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(152, 97);
            this.grpAccount.TabIndex = 5;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Account:";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBalance.Location = new System.Drawing.Point(67, 23);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(79, 26);
            this.txtBalance.TabIndex = 6;
            this.txtBalance.Text = "£20,000";
            // 
            // btnPurchaseHistory
            // 
            this.btnPurchaseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnPurchaseHistory.Location = new System.Drawing.Point(6, 55);
            this.btnPurchaseHistory.Name = "btnPurchaseHistory";
            this.btnPurchaseHistory.Size = new System.Drawing.Size(140, 31);
            this.btnPurchaseHistory.TabIndex = 7;
            this.btnPurchaseHistory.Text = "Purchase History";
            this.btnPurchaseHistory.UseVisualStyleBackColor = true;
            this.btnPurchaseHistory.Click += new System.EventHandler(this.btnPurchaseHistory_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblBalance.Location = new System.Drawing.Point(9, 29);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(55, 15);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "Balance:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 505);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.dgdDisplay);
            this.Name = "Client";
            this.Text = "Client Stocks";
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgdDisplay;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnPurchaseHistory;
        private System.Windows.Forms.Label lblBalance;
    }
}

