namespace Server_GUI
{
    partial class Server
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
            ButtonListen = new Button();
            TextReceived = new ListBox();
            InputData = new TextBox();
            SendButton = new Button();
            SuspendLayout();
            // 
            // ButtonListen
            // 
            ButtonListen.Location = new Point(12, 12);
            ButtonListen.Name = "ButtonListen";
            ButtonListen.Size = new Size(167, 23);
            ButtonListen.TabIndex = 0;
            ButtonListen.Text = "Start Listen";
            ButtonListen.UseVisualStyleBackColor = true;
            ButtonListen.Click += ButtonListen_Click;
            // 
            // TextReceived
            // 
            TextReceived.FormattingEnabled = true;
            TextReceived.ItemHeight = 15;
            TextReceived.Location = new Point(35, 53);
            TextReceived.Name = "TextReceived";
            TextReceived.Size = new Size(120, 94);
            TextReceived.TabIndex = 1;
            // 
            // textBox1
            // 
            InputData.Location = new Point(12, 171);
            InputData.Multiline = true;
            InputData.Name = "InputData";
            InputData.Size = new Size(84, 23);
            InputData.TabIndex = 2;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(102, 171);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 3;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(191, 211);
            Controls.Add(SendButton);
            Controls.Add(InputData);
            Controls.Add(TextReceived);
            Controls.Add(ButtonListen);
            MaximizeBox = false;
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox TextReceived;
        private TextBox InputData;
        private Button SendButton;
        private Button ButtonListen;
    }
}
