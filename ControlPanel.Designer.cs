namespace Lab7__gMartin
{
    partial class ControlPanel
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
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnSearchContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAddContact.Location = new System.Drawing.Point(262, 216);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(374, 152);
            this.btnAddContact.TabIndex = 0;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = false;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnSearchContact
            // 
            this.btnSearchContact.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSearchContact.Location = new System.Drawing.Point(669, 216);
            this.btnSearchContact.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSearchContact.Name = "btnSearchContact";
            this.btnSearchContact.Size = new System.Drawing.Size(364, 152);
            this.btnSearchContact.TabIndex = 1;
            this.btnSearchContact.Text = "Search Contact";
            this.btnSearchContact.UseVisualStyleBackColor = false;
            this.btnSearchContact.Click += new System.EventHandler(this.btnSearchContact_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1294, 647);
            this.Controls.Add(this.btnSearchContact);
            this.Controls.Add(this.btnAddContact);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnSearchContact;
    }
}