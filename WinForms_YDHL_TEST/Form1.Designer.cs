namespace WinForms_YDHL_TEST
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
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admission_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visit_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(12, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_name,
            this.admission_date,
            this.dept_name,
            this.visit_id,
            this.patient_id});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(863, 209);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnNameChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnNameChanged);
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "病人姓名";
            this.patient_name.Name = "patient_name";
            // 
            // admission_date
            // 
            this.admission_date.DataPropertyName = "admission_date";
            this.admission_date.HeaderText = "住院日期";
            this.admission_date.Name = "admission_date";
            // 
            // dept_name
            // 
            this.dept_name.DataPropertyName = "dept_name";
            this.dept_name.HeaderText = "科室名称";
            this.dept_name.Name = "dept_name";
            // 
            // visit_id
            // 
            this.visit_id.DataPropertyName = "visit_id";
            this.visit_id.HeaderText = "住院次数";
            this.visit_id.Name = "visit_id";
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "病人ID";
            this.patient_id.Name = "patient_id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 386);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_search);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn admission_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn visit_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
    }
}

