
namespace CreateProjectDesign
{
    partial class ShowAllClient
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMAILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pASSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHONENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICTUREDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.cLIENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wINFORM_DMDataSet1 = new CreateProjectDesign.WINFORM_DMDataSet1();
            this.button1 = new System.Windows.Forms.Button();
            this.wINFORMDMDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLIENTTableAdapter = new CreateProjectDesign.WINFORM_DMDataSet1TableAdapters.CLIENTTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHONENUMBERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMOUNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wINFORM_DMDataSet2 = new CreateProjectDesign.WINFORM_DMDataSet2();
            this.pAYMENTTableAdapter = new CreateProjectDesign.WINFORM_DMDataSet2TableAdapters.PAYMENTTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORM_DMDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORMDMDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORM_DMDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIDDataGridViewTextBoxColumn,
            this.nAMEDataGridViewTextBoxColumn,
            this.eMAILDataGridViewTextBoxColumn,
            this.pASSDataGridViewTextBoxColumn,
            this.pHONENODataGridViewTextBoxColumn,
            this.aDDRESSDataGridViewTextBoxColumn,
            this.pICTUREDataGridViewImageColumn});
            this.dataGridView1.DataSource = this.cLIENTBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(63, 118);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(962, 291);
            this.dataGridView1.TabIndex = 0;
            // 
            // nIDDataGridViewTextBoxColumn
            // 
            this.nIDDataGridViewTextBoxColumn.DataPropertyName = "NID";
            this.nIDDataGridViewTextBoxColumn.HeaderText = "NID";
            this.nIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nIDDataGridViewTextBoxColumn.Name = "nIDDataGridViewTextBoxColumn";
            this.nIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nAMEDataGridViewTextBoxColumn
            // 
            this.nAMEDataGridViewTextBoxColumn.DataPropertyName = "NAME";
            this.nAMEDataGridViewTextBoxColumn.HeaderText = "NAME";
            this.nAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nAMEDataGridViewTextBoxColumn.Name = "nAMEDataGridViewTextBoxColumn";
            this.nAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // eMAILDataGridViewTextBoxColumn
            // 
            this.eMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eMAILDataGridViewTextBoxColumn.Name = "eMAILDataGridViewTextBoxColumn";
            this.eMAILDataGridViewTextBoxColumn.Width = 125;
            // 
            // pASSDataGridViewTextBoxColumn
            // 
            this.pASSDataGridViewTextBoxColumn.DataPropertyName = "PASS";
            this.pASSDataGridViewTextBoxColumn.HeaderText = "PASS";
            this.pASSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pASSDataGridViewTextBoxColumn.Name = "pASSDataGridViewTextBoxColumn";
            this.pASSDataGridViewTextBoxColumn.Width = 125;
            // 
            // pHONENODataGridViewTextBoxColumn
            // 
            this.pHONENODataGridViewTextBoxColumn.DataPropertyName = "PHONENO";
            this.pHONENODataGridViewTextBoxColumn.HeaderText = "PHONENO";
            this.pHONENODataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pHONENODataGridViewTextBoxColumn.Name = "pHONENODataGridViewTextBoxColumn";
            this.pHONENODataGridViewTextBoxColumn.Width = 125;
            // 
            // aDDRESSDataGridViewTextBoxColumn
            // 
            this.aDDRESSDataGridViewTextBoxColumn.DataPropertyName = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.HeaderText = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aDDRESSDataGridViewTextBoxColumn.Name = "aDDRESSDataGridViewTextBoxColumn";
            this.aDDRESSDataGridViewTextBoxColumn.Width = 125;
            // 
            // pICTUREDataGridViewImageColumn
            // 
            this.pICTUREDataGridViewImageColumn.DataPropertyName = "PICTURE";
            this.pICTUREDataGridViewImageColumn.HeaderText = "PICTURE";
            this.pICTUREDataGridViewImageColumn.MinimumWidth = 6;
            this.pICTUREDataGridViewImageColumn.Name = "pICTUREDataGridViewImageColumn";
            this.pICTUREDataGridViewImageColumn.Width = 125;
            // 
            // cLIENTBindingSource
            // 
            this.cLIENTBindingSource.DataMember = "CLIENT";
            this.cLIENTBindingSource.DataSource = this.wINFORM_DMDataSet1;
            // 
            // wINFORM_DMDataSet1
            // 
            this.wINFORM_DMDataSet1.DataSetName = "WINFORM_DMDataSet1";
            this.wINFORM_DMDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(1033, 728);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wINFORMDMDataSet1BindingSource
            // 
            this.wINFORMDMDataSet1BindingSource.DataSource = this.wINFORM_DMDataSet1;
            this.wINFORMDMDataSet1BindingSource.Position = 0;
            // 
            // cLIENTTableAdapter
            // 
            this.cLIENTTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentMethodDataGridViewTextBoxColumn,
            this.pHONENUMBERDataGridViewTextBoxColumn,
            this.aMOUNTDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.pAYMENTBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(63, 459);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(962, 250);
            this.dataGridView2.TabIndex = 3;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentMethodDataGridViewTextBoxColumn.Width = 125;
            // 
            // pHONENUMBERDataGridViewTextBoxColumn
            // 
            this.pHONENUMBERDataGridViewTextBoxColumn.DataPropertyName = "PHONENUMBER";
            this.pHONENUMBERDataGridViewTextBoxColumn.HeaderText = "PHONENUMBER";
            this.pHONENUMBERDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pHONENUMBERDataGridViewTextBoxColumn.Name = "pHONENUMBERDataGridViewTextBoxColumn";
            this.pHONENUMBERDataGridViewTextBoxColumn.ReadOnly = true;
            this.pHONENUMBERDataGridViewTextBoxColumn.Width = 125;
            // 
            // aMOUNTDataGridViewTextBoxColumn
            // 
            this.aMOUNTDataGridViewTextBoxColumn.DataPropertyName = "AMOUNT";
            this.aMOUNTDataGridViewTextBoxColumn.HeaderText = "AMOUNT";
            this.aMOUNTDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aMOUNTDataGridViewTextBoxColumn.Name = "aMOUNTDataGridViewTextBoxColumn";
            this.aMOUNTDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMOUNTDataGridViewTextBoxColumn.Width = 125;
            // 
            // pAYMENTBindingSource
            // 
            this.pAYMENTBindingSource.DataMember = "PAYMENT";
            this.pAYMENTBindingSource.DataSource = this.wINFORM_DMDataSet2;
            // 
            // wINFORM_DMDataSet2
            // 
            this.wINFORM_DMDataSet2.DataSetName = "WINFORM_DMDataSet2";
            this.wINFORM_DMDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pAYMENTTableAdapter
            // 
            this.pAYMENTTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ShowAllClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1205, 776);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ShowAllClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAllClient";
            this.Load += new System.EventHandler(this.ShowAllClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORM_DMDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORMDMDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINFORM_DMDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource wINFORMDMDataSet1BindingSource;
        private WINFORM_DMDataSet1 wINFORM_DMDataSet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource cLIENTBindingSource;
        private WINFORM_DMDataSet1TableAdapters.CLIENTTableAdapter cLIENTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMAILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pASSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHONENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRESSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pICTUREDataGridViewImageColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private WINFORM_DMDataSet2 wINFORM_DMDataSet2;
        private System.Windows.Forms.BindingSource pAYMENTBindingSource;
        private WINFORM_DMDataSet2TableAdapters.PAYMENTTableAdapter pAYMENTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHONENUMBERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMOUNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}