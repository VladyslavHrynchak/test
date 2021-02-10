namespace БД_магазину
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productgroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kursovaGrinchakDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kursovaGrinchakDataSet = new БД_магазину.KursovaGrinchakDataSet();
            this.product_groupsTableAdapter = new БД_магазину.KursovaGrinchakDataSetTableAdapters.Product_groupsTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productgroupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaGrinchakDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaGrinchakDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(69, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(406, 257);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // productgroupsBindingSource
            // 
            this.productgroupsBindingSource.DataMember = "Product_groups";
            this.productgroupsBindingSource.DataSource = this.kursovaGrinchakDataSetBindingSource;
            // 
            // kursovaGrinchakDataSetBindingSource
            // 
            this.kursovaGrinchakDataSetBindingSource.DataSource = this.kursovaGrinchakDataSet;
            this.kursovaGrinchakDataSetBindingSource.Position = 0;
            // 
            // kursovaGrinchakDataSet
            // 
            this.kursovaGrinchakDataSet.DataSetName = "KursovaGrinchakDataSet";
            this.kursovaGrinchakDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // product_groupsTableAdapter
            // 
            this.product_groupsTableAdapter.ClearBeforeFill = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Код групи";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Назва групи";
            this.Column2.Name = "Column2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productgroupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaGrinchakDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaGrinchakDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource kursovaGrinchakDataSetBindingSource;
        private KursovaGrinchakDataSet kursovaGrinchakDataSet;
        private System.Windows.Forms.BindingSource productgroupsBindingSource;
        private KursovaGrinchakDataSetTableAdapters.Product_groupsTableAdapter product_groupsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

