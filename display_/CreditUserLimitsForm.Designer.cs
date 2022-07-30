
namespace display_multiple_values_in_dgv_column
{
    partial class CreditUserLimitsForm 
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
            this.dataGridViewCreditUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreditUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCreditUser
            // 
            this.dataGridViewCreditUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCreditUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCreditUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCreditUser.Name = "dataGridViewCreditUser";
            this.dataGridViewCreditUser.RowHeadersWidth = 62;
            this.dataGridViewCreditUser.RowTemplate.Height = 33;
            this.dataGridViewCreditUser.Size = new System.Drawing.Size(578, 344);
            this.dataGridViewCreditUser.TabIndex = 0;
            // 
            // CreditUserLimitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 344);
            this.Controls.Add(this.dataGridViewCreditUser);
            this.Name = "CreditUserLimitsForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreditUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCreditUser;
    }
}

