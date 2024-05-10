namespace CoolooAI.YOLOv3
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            listBox1 = new ListBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label6 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            row_id = new DataGridViewTextBoxColumn();
            obj_name = new DataGridViewTextBoxColumn();
            prob = new DataGridViewTextBoxColumn();
            x = new DataGridViewTextBoxColumn();
            y = new DataGridViewTextBoxColumn();
            width = new DataGridViewTextBoxColumn();
            hight = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1075, 892);
            button1.Name = "button1";
            button1.Size = new Size(194, 83);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(1077, 79);
            label1.Name = "label1";
            label1.Size = new Size(90, 28);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 28F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DeepPink;
            label2.Location = new Point(1068, 130);
            label2.Name = "label2";
            label2.Size = new Size(90, 66);
            label2.TabIndex = 2;
            label2.Text = "--";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(1145, 158);
            label3.Name = "label3";
            label3.Size = new Size(38, 28);
            label3.TabIndex = 3;
            label3.Text = "ms";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 28F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(1068, 208);
            label4.Name = "label4";
            label4.Size = new Size(90, 66);
            label4.TabIndex = 4;
            label4.Text = "--";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.loading;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1287, 989);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Consolas", 14F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1078, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(204, 41);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(1140, 235);
            label5.Name = "label5";
            label5.Size = new Size(51, 28);
            label5.TabIndex = 8;
            label5.Text = "fps";
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(1077, 302);
            listBox1.Margin = new Padding(4, 5, 4, 5);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(191, 554);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 955);
            label6.Name = "label6";
            label6.Size = new Size(637, 23);
            label6.TabIndex = 10;
            label6.Text = "YOLOv3, RTX 2080 Ti, CUDA 10.2, Custom Dataset, 2023/6/28";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Menu;
            textBox1.Location = new Point(12, 826);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(947, 117);
            textBox1.TabIndex = 11;
            textBox1.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Left;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { row_id, obj_name, prob, x, y, width, hight });
            dataGridView1.Location = new Point(2, 718);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1020, 225);
            dataGridView1.TabIndex = 12;
            dataGridView1.Visible = false;
            // 
            // row_id
            // 
            row_id.DataPropertyName = "row_id";
            row_id.HeaderText = "#";
            row_id.MinimumWidth = 8;
            row_id.Name = "row_id";
            row_id.ReadOnly = true;
            row_id.Width = 50;
            // 
            // obj_name
            // 
            obj_name.DataPropertyName = "obj_name";
            obj_name.HeaderText = "obj_name";
            obj_name.MinimumWidth = 8;
            obj_name.Name = "obj_name";
            obj_name.ReadOnly = true;
            obj_name.Width = 150;
            // 
            // prob
            // 
            prob.DataPropertyName = "prob";
            dataGridViewCellStyle1.Format = "P";
            dataGridViewCellStyle1.NullValue = null;
            prob.DefaultCellStyle = dataGridViewCellStyle1;
            prob.HeaderText = "prob";
            prob.MinimumWidth = 8;
            prob.Name = "prob";
            prob.ReadOnly = true;
            prob.Width = 150;
            // 
            // x
            // 
            x.DataPropertyName = "x";
            x.HeaderText = "x";
            x.MinimumWidth = 8;
            x.Name = "x";
            x.ReadOnly = true;
            x.Width = 150;
            // 
            // y
            // 
            y.DataPropertyName = "y";
            y.HeaderText = "y";
            y.MinimumWidth = 8;
            y.Name = "y";
            y.ReadOnly = true;
            y.Width = 150;
            // 
            // width
            // 
            width.DataPropertyName = "w";
            width.HeaderText = "width";
            width.MinimumWidth = 8;
            width.Name = "width";
            width.ReadOnly = true;
            width.Width = 150;
            // 
            // hight
            // 
            hight.DataPropertyName = "h";
            hight.HeaderText = "hight";
            hight.MinimumWidth = 8;
            hight.Name = "hight";
            hight.ReadOnly = true;
            hight.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 989);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(listBox1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YOLOv3 Object Detection  v2.1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Label label5;
        private ListBox listBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label6;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn row_id;
        private DataGridViewTextBoxColumn obj_name;
        private DataGridViewTextBoxColumn prob;
        private DataGridViewTextBoxColumn x;
        private DataGridViewTextBoxColumn y;
        private DataGridViewTextBoxColumn width;
        private DataGridViewTextBoxColumn hight;
    }
}