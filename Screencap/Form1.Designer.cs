namespace Screencap
{
    partial class NWBE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NWBE));
            weapon1Combobox = new ComboBox();
            startButton = new Button();
            label1 = new Label();
            label2 = new Label();
            CloseButton = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            weapon2Combobox = new ComboBox();
            linkLabel1 = new LinkLabel();
            ouputFolderBrowser = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // weapon1Combobox
            // 
            weapon1Combobox.FormattingEnabled = true;
            weapon1Combobox.Location = new Point(34, 500);
            weapon1Combobox.Margin = new Padding(3, 4, 3, 4);
            weapon1Combobox.Name = "weapon1Combobox";
            weapon1Combobox.Size = new Size(138, 28);
            weapon1Combobox.TabIndex = 0;
            // 
            // startButton
            // 
            startButton.AutoEllipsis = true;
            startButton.BackColor = Color.Gray;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startButton.ForeColor = Color.Transparent;
            startButton.Location = new Point(137, 612);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(109, 39);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(53, 464);
            label1.Name = "label1";
            label1.Size = new Size(115, 29);
            label1.TabIndex = 2;
            label1.Text = "Weapon I";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(256, 472);
            label2.Name = "label2";
            label2.Size = new Size(0, 18);
            label2.TabIndex = 3;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Transparent;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CloseButton.ForeColor = Color.LightGray;
            CloseButton.Location = new Point(350, 4);
            CloseButton.Margin = new Padding(3, 4, 3, 4);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(35, 41);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "X";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Location = new Point(14, 559);
            label3.Name = "label3";
            label3.Size = new Size(76, 24);
            label3.TabIndex = 5;
            label3.Text = "Save at:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.AppWorkspace;
            label4.Location = new Point(14, 584);
            label4.Name = "label4";
            label4.Size = new Size(0, 24);
            label4.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.AppWorkspace;
            label5.Location = new Point(230, 464);
            label5.Name = "label5";
            label5.Size = new Size(121, 29);
            label5.TabIndex = 7;
            label5.Text = "Weapon II";
            // 
            // weapon2Combobox
            // 
            weapon2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            weapon2Combobox.FormattingEnabled = true;
            weapon2Combobox.Location = new Point(215, 500);
            weapon2Combobox.Margin = new Padding(3, 4, 3, 4);
            weapon2Combobox.Name = "weapon2Combobox";
            weapon2Combobox.Size = new Size(138, 28);
            weapon2Combobox.TabIndex = 8;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.DimGray;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = SystemColors.ActiveBorder;
            linkLabel1.Location = new Point(16, 588);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(23, 18);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "C:";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // ouputFolderBrowser
            // 
            ouputFolderBrowser.SelectedPath = "c:/";
            // 
            // NWBE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.NWBE;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(389, 667);
            ControlBox = false;
            Controls.Add(linkLabel1);
            Controls.Add(weapon2Combobox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(CloseButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(startButton);
            Controls.Add(weapon1Combobox);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "NWBE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NWBE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox weapon1Combobox;
        private Button startButton;
        private Label label1;
        private Label label2;
        private Button CloseButton;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox weapon2Combobox;
        private LinkLabel linkLabel1;
        private FolderBrowserDialog ouputFolderBrowser;
    }
}