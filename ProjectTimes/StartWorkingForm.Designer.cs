
namespace ProjectTimes
{
    partial class StartWorkingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWorkingForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContinueWork = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.tbxLastProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLatestWorks = new System.Windows.Forms.Panel();
            this.lstLatestProjects = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNoWorking = new System.Windows.Forms.Button();
            this.pnlNewProject = new System.Windows.Forms.Panel();
            this.btnStartWorkingOn = new System.Windows.Forms.Button();
            this.tbxNewProjectName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlContinueWork.SuspendLayout();
            this.pnlLatestWorks.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlNewProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 56);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "What is your working project?";
            // 
            // pnlContinueWork
            // 
            this.pnlContinueWork.Controls.Add(this.btnContinue);
            this.pnlContinueWork.Controls.Add(this.tbxLastProjectName);
            this.pnlContinueWork.Controls.Add(this.label2);
            this.pnlContinueWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContinueWork.Location = new System.Drawing.Point(0, 56);
            this.pnlContinueWork.Name = "pnlContinueWork";
            this.pnlContinueWork.Size = new System.Drawing.Size(720, 69);
            this.pnlContinueWork.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(623, 36);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(74, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // tbxLastProjectName
            // 
            this.tbxLastProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLastProjectName.BackColor = System.Drawing.SystemColors.Info;
            this.tbxLastProjectName.Location = new System.Drawing.Point(13, 36);
            this.tbxLastProjectName.Name = "tbxLastProjectName";
            this.tbxLastProjectName.ReadOnly = true;
            this.tbxLastProjectName.Size = new System.Drawing.Size(604, 23);
            this.tbxLastProjectName.TabIndex = 1;
            this.tbxLastProjectName.TabStop = false;
            this.tbxLastProjectName.TextChanged += new System.EventHandler(this.tbxLastProjectName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "You were working on this project: (less than an hour ago)";
            // 
            // pnlLatestWorks
            // 
            this.pnlLatestWorks.Controls.Add(this.lstLatestProjects);
            this.pnlLatestWorks.Controls.Add(this.label3);
            this.pnlLatestWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLatestWorks.Location = new System.Drawing.Point(0, 125);
            this.pnlLatestWorks.Name = "pnlLatestWorks";
            this.pnlLatestWorks.Size = new System.Drawing.Size(720, 367);
            this.pnlLatestWorks.TabIndex = 3;
            // 
            // lstLatestProjects
            // 
            this.lstLatestProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLatestProjects.FormattingEnabled = true;
            this.lstLatestProjects.ItemHeight = 15;
            this.lstLatestProjects.Location = new System.Drawing.Point(12, 34);
            this.lstLatestProjects.Name = "lstLatestProjects";
            this.lstLatestProjects.Size = new System.Drawing.Size(690, 199);
            this.lstLatestProjects.TabIndex = 4;
            this.lstLatestProjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLatestProjects_KeyDown);
            this.lstLatestProjects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstLatestProjects_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Latest projects (double click to do back to work on it):";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNoWorking);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 58);
            this.panel2.TabIndex = 1;
            // 
            // btnNoWorking
            // 
            this.btnNoWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoWorking.Location = new System.Drawing.Point(522, 23);
            this.btnNoWorking.Name = "btnNoWorking";
            this.btnNoWorking.Size = new System.Drawing.Size(180, 23);
            this.btnNoWorking.TabIndex = 2;
            this.btnNoWorking.Text = "No working, time to rest";
            this.btnNoWorking.UseVisualStyleBackColor = true;
            this.btnNoWorking.Click += new System.EventHandler(this.btnNoWorking_Click);
            // 
            // pnlNewProject
            // 
            this.pnlNewProject.Controls.Add(this.btnStartWorkingOn);
            this.pnlNewProject.Controls.Add(this.tbxNewProjectName);
            this.pnlNewProject.Controls.Add(this.label4);
            this.pnlNewProject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNewProject.Location = new System.Drawing.Point(0, 371);
            this.pnlNewProject.Name = "pnlNewProject";
            this.pnlNewProject.Size = new System.Drawing.Size(720, 63);
            this.pnlNewProject.TabIndex = 0;
            // 
            // btnStartWorkingOn
            // 
            this.btnStartWorkingOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartWorkingOn.Enabled = false;
            this.btnStartWorkingOn.Location = new System.Drawing.Point(582, 34);
            this.btnStartWorkingOn.Name = "btnStartWorkingOn";
            this.btnStartWorkingOn.Size = new System.Drawing.Size(120, 23);
            this.btnStartWorkingOn.TabIndex = 1;
            this.btnStartWorkingOn.Text = "Start working on";
            this.btnStartWorkingOn.UseVisualStyleBackColor = true;
            this.btnStartWorkingOn.Click += new System.EventHandler(this.btnStartWorkingOn_Click);
            // 
            // tbxNewProjectName
            // 
            this.tbxNewProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNewProjectName.Location = new System.Drawing.Point(12, 34);
            this.tbxNewProjectName.Name = "tbxNewProjectName";
            this.tbxNewProjectName.Size = new System.Drawing.Size(564, 23);
            this.tbxNewProjectName.TabIndex = 0;
            this.tbxNewProjectName.TextChanged += new System.EventHandler(this.tbxNewProjectName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Would you like start new project? Write his name and start working:";
            // 
            // StartWorkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 492);
            this.ControlBox = false;
            this.Controls.Add(this.pnlNewProject);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLatestWorks);
            this.Controls.Add(this.pnlContinueWork);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartWorkingForm";
            this.Text = "Start to working ...";
            this.Activated += new System.EventHandler(this.StartWorkingForm_Activated);
            this.Load += new System.EventHandler(this.StartWorkingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContinueWork.ResumeLayout(false);
            this.pnlContinueWork.PerformLayout();
            this.pnlLatestWorks.ResumeLayout(false);
            this.pnlLatestWorks.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlNewProject.ResumeLayout(false);
            this.pnlNewProject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContinueWork;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox tbxLastProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlLatestWorks;
        private System.Windows.Forms.ListBox lstLatestProjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlNewProject;
        private System.Windows.Forms.Button btnStartWorkingOn;
        private System.Windows.Forms.TextBox tbxNewProjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNoWorking;
    }
}

