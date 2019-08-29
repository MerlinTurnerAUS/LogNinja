namespace LogSpawner
{
    partial class frmMain
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
            this.btnAppendLog = new System.Windows.Forms.Button();
            this.txtLogText = new System.Windows.Forms.TextBox();
            this.chkLogError = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDB = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDBError = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXML = new System.Windows.Forms.Button();
            this.txtErrorLevelXML = new System.Windows.Forms.TextBox();
            this.txtXMLDesk = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCSVNotes = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCSVResult = new System.Windows.Forms.TextBox();
            this.txtCSVDue = new System.Windows.Forms.TextBox();
            this.txtCSVPaid = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCSVCost = new System.Windows.Forms.TextBox();
            this.txtCSVDesc = new System.Windows.Forms.TextBox();
            this.txtCSVItem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(13, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log file";
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
            // txtLogText
            // 
            this.txtLogText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogText.Location = new System.Drawing.Point(44, 36);
            this.txtLogText.Name = "txtLogText";
            this.txtLogText.Size = new System.Drawing.Size(697, 20);
            this.txtLogText.TabIndex = 4;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDB);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.txtDBError);
            this.groupBox2.Controls.Add(this.txtDBName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(19, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(758, 147);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB Table";
            // 
            // btnDB
            // 
            this.btnDB.Location = new System.Drawing.Point(7, 110);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(94, 23);
            this.btnDB.TabIndex = 6;
            this.btnDB.Text = "Write to DB";
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.BtnDB_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(70, 74);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(197, 20);
            this.txtUser.TabIndex = 5;
            // 
            // txtDBError
            // 
            this.txtDBError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBError.Location = new System.Drawing.Point(70, 46);
            this.txtDBError.Name = "txtDBError";
            this.txtDBError.Size = new System.Drawing.Size(665, 20);
            this.txtDBError.TabIndex = 4;
            // 
            // txtDBName
            // 
            this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName.Location = new System.Drawing.Point(70, 20);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(665, 20);
            this.txtDBName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Error text:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnXML);
            this.groupBox3.Controls.Add(this.txtErrorLevelXML);
            this.groupBox3.Controls.Add(this.txtXMLDesk);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(19, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 147);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "XML";
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(7, 110);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(94, 23);
            this.btnXML.TabIndex = 6;
            this.btnXML.Text = "Write to XML";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // txtErrorLevelXML
            // 
            this.txtErrorLevelXML.Location = new System.Drawing.Point(70, 74);
            this.txtErrorLevelXML.Name = "txtErrorLevelXML";
            this.txtErrorLevelXML.Size = new System.Drawing.Size(197, 20);
            this.txtErrorLevelXML.TabIndex = 5;
            // 
            // txtXMLDesk
            // 
            this.txtXMLDesk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXMLDesk.Location = new System.Drawing.Point(70, 46);
            this.txtXMLDesk.Name = "txtXMLDesk";
            this.txtXMLDesk.Size = new System.Drawing.Size(665, 20);
            this.txtXMLDesk.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(70, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(665, 20);
            this.txtName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Level:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtCSVNotes);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtCSVResult);
            this.groupBox4.Controls.Add(this.txtCSVDue);
            this.groupBox4.Controls.Add(this.txtCSVPaid);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtCSVCost);
            this.groupBox4.Controls.Add(this.txtCSVDesc);
            this.groupBox4.Controls.Add(this.txtCSVItem);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(19, 487);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(758, 267);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CSV";
            // 
            // txtCSVNotes
            // 
            this.txtCSVNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVNotes.Location = new System.Drawing.Point(70, 180);
            this.txtCSVNotes.Name = "txtCSVNotes";
            this.txtCSVNotes.Size = new System.Drawing.Size(665, 20);
            this.txtCSVNotes.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Notes:";
            // 
            // txtCSVResult
            // 
            this.txtCSVResult.Location = new System.Drawing.Point(70, 154);
            this.txtCSVResult.Name = "txtCSVResult";
            this.txtCSVResult.Size = new System.Drawing.Size(197, 20);
            this.txtCSVResult.TabIndex = 12;
            // 
            // txtCSVDue
            // 
            this.txtCSVDue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVDue.Location = new System.Drawing.Point(70, 126);
            this.txtCSVDue.Name = "txtCSVDue";
            this.txtCSVDue.Size = new System.Drawing.Size(665, 20);
            this.txtCSVDue.TabIndex = 11;
            // 
            // txtCSVPaid
            // 
            this.txtCSVPaid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVPaid.Location = new System.Drawing.Point(70, 100);
            this.txtCSVPaid.Name = "txtCSVPaid";
            this.txtCSVPaid.Size = new System.Drawing.Size(665, 20);
            this.txtCSVPaid.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Result:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Due Date:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Paid:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Write to CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtCSVCost
            // 
            this.txtCSVCost.Location = new System.Drawing.Point(70, 74);
            this.txtCSVCost.Name = "txtCSVCost";
            this.txtCSVCost.Size = new System.Drawing.Size(197, 20);
            this.txtCSVCost.TabIndex = 5;
            // 
            // txtCSVDesc
            // 
            this.txtCSVDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVDesc.Location = new System.Drawing.Point(70, 46);
            this.txtCSVDesc.Name = "txtCSVDesc";
            this.txtCSVDesc.Size = new System.Drawing.Size(665, 20);
            this.txtCSVDesc.TabIndex = 4;
            // 
            // txtCSVItem
            // 
            this.txtCSVItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVItem.Location = new System.Drawing.Point(70, 20);
            this.txtCSVItem.Name = "txtCSVItem";
            this.txtCSVItem.Size = new System.Drawing.Size(665, 20);
            this.txtCSVItem.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Cost:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Description:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Item no:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(13, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(764, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset to initial conditions";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 784);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Log Spawner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAppendLog;
        private System.Windows.Forms.TextBox txtLogText;
        private System.Windows.Forms.CheckBox chkLogError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDBError;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.TextBox txtErrorLevelXML;
        private System.Windows.Forms.TextBox txtXMLDesk;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCSVNotes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCSVResult;
        private System.Windows.Forms.TextBox txtCSVDue;
        private System.Windows.Forms.TextBox txtCSVPaid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCSVCost;
        private System.Windows.Forms.TextBox txtCSVDesc;
        private System.Windows.Forms.TextBox txtCSVItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReset;
    }
}

