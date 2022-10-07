namespace SocketFormServer
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
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.labelChatTitle = new System.Windows.Forms.Label();
            this.txtBoxChat = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btnNewConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(343, 389);
            this.txtBoxSend.Multiline = true;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(297, 25);
            this.txtBoxSend.TabIndex = 13;
            this.txtBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSend_KeyDown);
            // 
            // labelChatTitle
            // 
            this.labelChatTitle.AutoSize = true;
            this.labelChatTitle.Location = new System.Drawing.Point(478, 108);
            this.labelChatTitle.Name = "labelChatTitle";
            this.labelChatTitle.Size = new System.Drawing.Size(34, 16);
            this.labelChatTitle.TabIndex = 12;
            this.labelChatTitle.Text = "Chat";
            // 
            // txtBoxChat
            // 
            this.txtBoxChat.Location = new System.Drawing.Point(343, 127);
            this.txtBoxChat.Multiline = true;
            this.txtBoxChat.Name = "txtBoxChat";
            this.txtBoxChat.ReadOnly = true;
            this.txtBoxChat.Size = new System.Drawing.Size(297, 245);
            this.txtBoxChat.TabIndex = 11;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(543, 420);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(97, 32);
            this.btn_Send.TabIndex = 10;
            this.btn_Send.Text = "Invia";
            this.btn_Send.UseVisualStyleBackColor = true;
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Location = new System.Drawing.Point(543, 100);
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(97, 24);
            this.btnNewConnection.TabIndex = 14;
            this.btnNewConnection.Text = "Connesione";
            this.btnNewConnection.UseVisualStyleBackColor = true;
            this.btnNewConnection.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.btnNewConnection);
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
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.Windows.Forms.Label labelChatTitle;
        private System.Windows.Forms.TextBox txtBoxChat;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btnNewConnection;
    }
}

