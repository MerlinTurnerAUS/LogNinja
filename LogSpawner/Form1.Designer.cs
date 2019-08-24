namespace LogSpawner
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLogError = new System.Windows.Forms.CheckBox();
            this.txtLogText = new System.Windows.Forms.TextBox();
            this.btnAppendLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAppendLog);
            this.groupBox1.Controls.Add(this.txtLogText);
            this.groupBox1.Controls.Add(this.chkLogError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text:";
            // 
            // chkLogError
            // 
            this.chkLogError.AutoSize = true;
            this.chkLogError.Location = new System.Drawing.Point(10, 19);
            this.chkLogError.Name = "chkLogError";
            this.chkLogError.Size = new System.Drawing.Size(48, 17);
            this.chkLogError.TabIndex = 2;
            this.chkLogError.Text = "Error";
            this.chkLogError.UseVisualStyleBackColor = true;
            // 
            // txtLogText
            // 
            this.txtLogText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogText.Location = new System.Drawing.Point(44, 36);
            this.txtLogText.Name = "txtLogText";
            this.txtLogText.Size = new System.Drawing.Size(697, 20);
            this.txtLogText.TabIndex = 4;
            // 
            // btnAppendLog
            // 
            this.btnAppendLog.Location = new System.Drawing.Point(6, 62);
            this.btnAppendLog.Name = "btnAppendLog";
            this.btnAppendLog.Size = new System.Drawing.Size(101, 23);
            this.btnAppendLog.TabIndex = 5;
            this.btnAppendLog.Text = "Append to Log";
            this.btnAppendLog.UseVisualStyleBackColor = true;
            this.btnAppendLog.Click += new System.EventHandler(this.BtnAppendLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Log Spawner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAppendLog;
        private System.Windows.Forms.TextBox txtLogText;
        private System.Windows.Forms.CheckBox chkLogError;
        private System.Windows.Forms.Label label2;
    }
}

