namespace WinForms_YDHL_TEST
{
    partial class deptForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dept_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.组号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admission_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visit_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病人年龄 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depted_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "显示科室信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dept_code,
            this.dept_name});
            this.dataGridView1.Location = new System.Drawing.Point(41, 67);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(250, 340);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // dept_code
            // 
            this.dept_code.DataPropertyName = "dept_code";
            this.dept_code.HeaderText = "科室ID";
            this.dept_code.Name = "dept_code";
            // 
            // dept_name
            // 
            this.dept_name.DataPropertyName = "dept_name";
            this.dept_name.HeaderText = "科室名称";
            this.dept_name.Name = "dept_name";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.组号,
            this.patient_id,
            this.admission_date,
            this.visit_id,
            this.patient_name,
            this.病人年龄,
            this.depted_time,
            this.date_of_birth});
            this.dataGridView2.Location = new System.Drawing.Point(310, 67);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(522, 340);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.advancedDataGridView1_RowPostPaint);
            // 
            // 组号
            // 
            this.组号.DataPropertyName = "组号";
            this.组号.HeaderText = "组号";
            this.组号.Name = "组号";
            this.组号.Width = 54;
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "病人ID号";
            this.patient_id.Name = "patient_id";
            this.patient_id.Width = 78;
            // 
            // admission_date
            // 
            this.admission_date.DataPropertyName = "admission_date";
            this.admission_date.HeaderText = "入院时间";
            this.admission_date.Name = "admission_date";
            this.admission_date.Width = 78;
            // 
            // visit_id
            // 
            this.visit_id.DataPropertyName = "visit_id";
            this.visit_id.HeaderText = "住院次数";
            this.visit_id.Name = "visit_id";
            this.visit_id.Width = 78;
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "病人姓名";
            this.patient_name.Name = "patient_name";
            this.patient_name.Width = 78;
            // 
            // 病人年龄
            // 
            this.病人年龄.DataPropertyName = "病人年龄";
            this.病人年龄.HeaderText = "病人年龄";
            this.病人年龄.Name = "病人年龄";
            this.病人年龄.Width = 78;
            // 
            // depted_time
            // 
            this.depted_time.DataPropertyName = "depted_time";
            this.depted_time.HeaderText = "离院时间";
            this.depted_time.Name = "depted_time";
            this.depted_time.Width = 78;
            // 
            // date_of_birth
            // 
            this.date_of_birth.DataPropertyName = "date_of_birth";
            this.date_of_birth.HeaderText = "出生时间";
            this.date_of_birth.Name = "date_of_birth";
            this.date_of_birth.Width = 78;
            // 
            // deptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 435);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "deptForm";
            this.Text = "deptForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组号;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn admission_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn visit_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人年龄;
        private System.Windows.Forms.DataGridViewTextBoxColumn depted_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_of_birth;
    }
}