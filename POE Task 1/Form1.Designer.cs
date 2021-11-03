
namespace POE_Task_1
{
    partial class Form1
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
            this.MapLabel = new System.Windows.Forms.Label();
            this.CharacterLabel = new System.Windows.Forms.Label();
            this.EnemyLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(72, 54);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(50, 20);
            this.MapLabel.TabIndex = 0;
            this.MapLabel.Text = "label1";
            // 
            // CharacterLabel
            // 
            this.CharacterLabel.AutoSize = true;
            this.CharacterLabel.Location = new System.Drawing.Point(375, 81);
            this.CharacterLabel.Name = "CharacterLabel";
            this.CharacterLabel.Size = new System.Drawing.Size(50, 20);
            this.CharacterLabel.TabIndex = 1;
            this.CharacterLabel.Text = "label2";
            // 
            // EnemyLabel
            // 
            this.EnemyLabel.AutoSize = true;
            this.EnemyLabel.Location = new System.Drawing.Point(375, 182);
            this.EnemyLabel.Name = "EnemyLabel";
            this.EnemyLabel.Size = new System.Drawing.Size(50, 20);
            this.EnemyLabel.TabIndex = 2;
            this.EnemyLabel.Text = "label3";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(57, 353);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(165, 66);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click_1);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(582, 297);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(94, 29);
            this.UpButton.TabIndex = 4;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(479, 344);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(94, 29);
            this.LeftButton.TabIndex = 5;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(679, 344);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(94, 29);
            this.RightButton.TabIndex = 6;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(582, 390);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(94, 29);
            this.DownButton.TabIndex = 7;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.EnemyLabel);
            this.Controls.Add(this.CharacterLabel);
            this.Controls.Add(this.MapLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CharacterLabel;
        private System.Windows.Forms.Label EnemyLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Label MapLabel;
    }
}

