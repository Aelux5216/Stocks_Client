namespace Stocks_Client
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
            this.dgdDisplay = new System.Windows.Forms.DataGridView();
            this.lblIntro = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnPurchaseHistory = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpControlPanel = new System.Windows.Forms.GroupBox();
            this.btnReconnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).BeginInit();
            this.grpAccount.SuspendLayout();
            this.grpControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnBuy.Location = new System.Drawing.Point(12, 133);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(134, 23);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnSell.Location = new System.Drawing.Point(12, 162);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(134, 23);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // dgdDisplay
            // 
            this.dgdDisplay.AllowUserToAddRows = false;
            this.dgdDisplay.AllowUserToDeleteRows = false;
            this.dgdDisplay.AllowUserToResizeColumns = false;
            this.dgdDisplay.AllowUserToResizeRows = false;
            this.dgdDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgdDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgdDisplay.Location = new System.Drawing.Point(8, 101);
            this.dgdDisplay.MultiSelect = false;
            this.dgdDisplay.Name = "dgdDisplay";
            this.dgdDisplay.ReadOnly = true;
            this.dgdDisplay.RowHeadersVisible = false;
            this.dgdDisplay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgdDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdDisplay.Size = new System.Drawing.Size(482, 353);
            this.dgdDisplay.TabIndex = 3;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblIntro.Location = new System.Drawing.Point(12, 41);
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
            this.grpAccount.Location = new System.Drawing.Point(509, 12);
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
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnRefresh.Location = new System.Drawing.Point(12, 63);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(134, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh stocks";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpControlPanel
            // 
            this.grpControlPanel.Controls.Add(this.btnReconnect);
            this.grpControlPanel.Controls.Add(this.btnRefresh);
            this.grpControlPanel.Controls.Add(this.btnBuy);
            this.grpControlPanel.Controls.Add(this.btnSell);
            this.grpControlPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.grpControlPanel.Location = new System.Drawing.Point(509, 115);
            this.grpControlPanel.Name = "grpControlPanel";
            this.grpControlPanel.Size = new System.Drawing.Size(152, 339);
            this.grpControlPanel.TabIndex = 8;
            this.grpControlPanel.TabStop = false;
            this.grpControlPanel.Text = "Control Panel";
            // 
            // btnReconnect
            // 
            this.btnReconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnReconnect.Location = new System.Drawing.Point(12, 234);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(134, 55);
            this.btnReconnect.TabIndex = 7;
            this.btnReconnect.Text = "Connect/Reconnect \r\nto server";
            this.btnReconnect.UseVisualStyleBackColor = true;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(674, 493);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.dgdDisplay);
            this.Controls.Add(this.grpControlPanel);
            this.Name = "Client";
            this.Text = "Client Stocks";
            this.Shown += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgdDisplay)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.grpControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.DataGridView dgdDisplay;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnPurchaseHistory;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpControlPanel;
        private System.Windows.Forms.Button btnReconnect;
    }
}

