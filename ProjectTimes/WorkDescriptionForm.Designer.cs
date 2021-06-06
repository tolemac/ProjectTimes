
namespace ProjectTimes
{
    partial class WorkDescriptionForm
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxWorkDescription = new System.Windows.Forms.TextBox();
            this.lstLastDescriptions = new System.Windows.Forms.ListBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(408, 192);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(489, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Work description:";
            // 
            // tbxWorkDescription
            // 
            this.tbxWorkDescription.Location = new System.Drawing.Point(127, 27);
            this.tbxWorkDescription.Name = "tbxWorkDescription";
            this.tbxWorkDescription.Size = new System.Drawing.Size(437, 23);
            this.tbxWorkDescription.TabIndex = 0;
            this.tbxWorkDescription.TextChanged += new System.EventHandler(this.tbxWorkDescription_TextChanged);
            // 
            // lstLastDescriptions
            // 
            this.lstLastDescriptions.FormattingEnabled = true;
            this.lstLastDescriptions.ItemHeight = 15;
            this.lstLastDescriptions.Location = new System.Drawing.Point(21, 77);
            this.lstLastDescriptions.Name = "lstLastDescriptions";
            this.lstLastDescriptions.Size = new System.Drawing.Size(543, 94);
            this.lstLastDescriptions.TabIndex = 1;
            this.lstLastDescriptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLastDescriptions_KeyDown);
            this.lstLastDescriptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstLastDescriptions_MouseDoubleClick);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(21, 59);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(119, 15);
            this.lblProjectName.TabIndex = 5;
            this.lblProjectName.Text = "Last works on project";
            // 
            // WorkDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 227);
            this.ControlBox = false;
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.lstLastDescriptions);
            this.Controls.Add(this.tbxWorkDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WorkDescriptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work description";
            this.Activated += new System.EventHandler(this.WorkDescriptionForm_Activated);
            this.Load += new System.EventHandler(this.WorkDescriptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxWorkDescription;
        private System.Windows.Forms.ListBox lstLastDescriptions;
        private System.Windows.Forms.Label lblProjectName;
    }
}