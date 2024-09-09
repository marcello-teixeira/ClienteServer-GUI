namespace Cliente_GUI
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConnectButton = new Button();
            TextReceived = new ListBox();
            InputIP = new TextBox();
            InputData = new TextBox();
            SendButton = new Button();
            SuspendLayout();
            // 
            // ConnectButton
            // 
            ConnectButton.Cursor = Cursors.Hand;
            ConnectButton.Location = new Point(169, 12);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 0;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // TextReceived
            // 
            TextReceived.FormattingEnabled = true;
            TextReceived.ItemHeight = 15;
            TextReceived.Location = new Point(26, 41);
            TextReceived.Name = "TextReceived";
            TextReceived.Size = new Size(188, 94);
            TextReceived.TabIndex = 1;
            // 
            // InputIP
            // 
            InputIP.Location = new Point(12, 13);
            InputIP.Name = "InputIP";
            InputIP.Size = new Size(151, 23);
            InputIP.TabIndex = 2;
            // 
            // InputData
            // 
            InputData.Location = new Point(12, 141);
            InputData.Name = "InputData";
            InputData.Size = new Size(151, 23);
            InputData.TabIndex = 4;
            // 
            // SendButton
            // 
            SendButton.Cursor = Cursors.Hand;
            SendButton.Location = new Point(169, 140);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 3;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 182);
            Controls.Add(InputData);
            Controls.Add(SendButton);
            Controls.Add(InputIP);
            Controls.Add(TextReceived);
            Controls.Add(ConnectButton);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectButton;
        private ListBox TextReceived;
        private TextBox InputIP;
        private TextBox InputData;
        private Button SendButton;
    }
}
