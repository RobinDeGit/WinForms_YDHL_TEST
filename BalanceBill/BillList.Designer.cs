namespace BalanceBill
{
    partial class BillList
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
            this.inpBilldataGridView = new System.Windows.Forms.DataGridView();
            this.PatIdBox = new System.Windows.Forms.TextBox();
            this.query_button = new System.Windows.Forms.Button();
            this.vid_box = new System.Windows.Forms.TextBox();
            this.operateButton = new System.Windows.Forms.Button();
            this.balance_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inpBilldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // inpBilldataGridView
            // 
            this.inpBilldataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inpBilldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inpBilldataGridView.Location = new System.Drawing.Point(29, 159);
            this.inpBilldataGridView.Name = "inpBilldataGridView";
            this.inpBilldataGridView.RowTemplate.Height = 27;
            this.inpBilldataGridView.Size = new System.Drawing.Size(894, 357);
            this.inpBilldataGridView.TabIndex = 0;
            // 
            // PatIdBox
            // 
            this.PatIdBox.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatIdBox.Location = new System.Drawing.Point(52, 33);
            this.PatIdBox.Name = "PatIdBox";
            this.PatIdBox.Size = new System.Drawing.Size(180, 34);
            this.PatIdBox.TabIndex = 1;
            this.PatIdBox.Text = "请输入PATIENT_ID";
            this.PatIdBox.Enter += new System.EventHandler(this.PatIdBox_Enter);
            this.PatIdBox.Leave += new System.EventHandler(this.PatIdBox_Leave);
            // 
            // query_button
            // 
            this.query_button.Location = new System.Drawing.Point(599, 33);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(103, 34);
            this.query_button.TabIndex = 2;
            this.query_button.Text = "查询";
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.query_button_MouseClick);
            // 
            // vid_box
            // 
            this.vid_box.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.vid_box.Location = new System.Drawing.Point(319, 33);
            this.vid_box.Name = "vid_box";
            this.vid_box.Size = new System.Drawing.Size(180, 34);
            this.vid_box.TabIndex = 3;
            this.vid_box.Text = "请输入VISIT_ID";
            this.vid_box.Enter += new System.EventHandler(this.vid_box_Enter);
            this.vid_box.Leave += new System.EventHandler(this.vid_box_Leave);
            // 
            // operateButton
            // 
            this.operateButton.Location = new System.Drawing.Point(761, 33);
            this.operateButton.Name = "operateButton";
            this.operateButton.Size = new System.Drawing.Size(103, 34);
            this.operateButton.TabIndex = 4;
            this.operateButton.Text = "分组处理";
            this.operateButton.UseVisualStyleBackColor = true;
            this.operateButton.Click += new System.EventHandler(this.operateButton_Click);
            // 
            // balance_button
            // 
            this.balance_button.Location = new System.Drawing.Point(52, 95);
            this.balance_button.Name = "balance_button";
            this.balance_button.Size = new System.Drawing.Size(141, 34);
            this.balance_button.TabIndex = 5;
            this.balance_button.Text = "账目平衡处理";
            this.balance_button.UseVisualStyleBackColor = true;
            this.balance_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // BillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 528);
            this.Controls.Add(this.balance_button);
            this.Controls.Add(this.operateButton);
            this.Controls.Add(this.vid_box);
            this.Controls.Add(this.query_button);
            this.Controls.Add(this.PatIdBox);
            this.Controls.Add(this.inpBilldataGridView);
            this.Name = "BillList";
            this.Text = "住院账目";
            ((System.ComponentModel.ISupportInitialize)(this.inpBilldataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inpBilldataGridView;
        private System.Windows.Forms.TextBox PatIdBox;
        private System.Windows.Forms.Button query_button;
        private System.Windows.Forms.TextBox vid_box;
        private System.Windows.Forms.Button operateButton;
        private System.Windows.Forms.Button balance_button;
    }
}

