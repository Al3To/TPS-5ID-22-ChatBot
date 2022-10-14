namespace SocketFormClient
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelChatTitle = new System.Windows.Forms.Label();
            this.txtBoxChat = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboBoxSelections = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelChatTitle
            // 
            this.labelChatTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChatTitle.AutoSize = true;
            this.labelChatTitle.Location = new System.Drawing.Point(385, 77);
            this.labelChatTitle.Name = "labelChatTitle";
            this.labelChatTitle.Size = new System.Drawing.Size(34, 16);
            this.labelChatTitle.TabIndex = 7;
            this.labelChatTitle.Text = "Chat";
            // 
            // txtBoxChat
            // 
            this.txtBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxChat.Location = new System.Drawing.Point(268, 100);
            this.txtBoxChat.Multiline = true;
            this.txtBoxChat.Name = "txtBoxChat";
            this.txtBoxChat.ReadOnly = true;
            this.txtBoxChat.Size = new System.Drawing.Size(297, 245);
            this.txtBoxChat.TabIndex = 6;
            // 
            // btn_Send
            // 
            this.btn_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Send.Location = new System.Drawing.Point(468, 393);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(97, 32);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Invia";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSend.Location = new System.Drawing.Point(268, 362);
            this.txtBoxSend.Multiline = true;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(297, 25);
            this.txtBoxSend.TabIndex = 8;
            this.txtBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSend_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(486, 73);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 24);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connettiti";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBoxSelections
            // 
            this.comboBoxSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelections.FormattingEnabled = true;
            this.comboBoxSelections.Items.AddRange(new object[] {
            "Numero Random",
            "Un Dado",
            "Due Dadi",
            "Calcolatrice",
            "Lancio Moneta",
            "Pi Greco"});
            this.comboBoxSelections.Location = new System.Drawing.Point(131, 363);
            this.comboBoxSelections.Name = "comboBoxSelections";
            this.comboBoxSelections.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSelections.TabIndex = 10;
            this.comboBoxSelections.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelections_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.comboBoxSelections);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtBoxSend);
            this.Controls.Add(this.labelChatTitle);
            this.Controls.Add(this.txtBoxChat);
            this.Controls.Add(this.btn_Send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelChatTitle;
        private System.Windows.Forms.TextBox txtBoxChat;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxSelections;
    }
}

