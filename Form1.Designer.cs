
namespace DependentTrial_Calculator_V1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Upbar = new System.Windows.Forms.Panel();
            this.label_Upbar = new System.Windows.Forms.Label();
            this.panel_Node = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_NodeList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Result_DT = new System.Windows.Forms.Panel();
            this.label_Downbar = new System.Windows.Forms.Label();
            this.dataGridView_Get = new System.Windows.Forms.DataGridView();
            this.dgg_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgg_node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgg_probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Node_Control = new System.Windows.Forms.Panel();
            this.button_SaveFileDirectory = new System.Windows.Forms.Button();
            this.button_SaveFile = new System.Windows.Forms.Button();
            this.panel_Guard4 = new System.Windows.Forms.Panel();
            this.button_Init = new System.Windows.Forms.Button();
            this.panel_Guard3 = new System.Windows.Forms.Panel();
            this.comboBox_PickCount = new System.Windows.Forms.ComboBox();
            this.label_PickCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.panel_Guard2 = new System.Windows.Forms.Panel();
            this.button_Delete = new System.Windows.Forms.Button();
            this.textBox_NodeProbability = new System.Windows.Forms.TextBox();
            this.label_NodeProbability = new System.Windows.Forms.Label();
            this.textBox_NodeName = new System.Windows.Forms.TextBox();
            this.label_NodeName = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_AddNode = new System.Windows.Forms.Button();
            this.panel_Upbar.SuspendLayout();
            this.panel_Node.SuspendLayout();
            this.panel_Result_DT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Get)).BeginInit();
            this.panel_Node_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Upbar
            // 
            this.panel_Upbar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_Upbar.Controls.Add(this.label_Upbar);
            this.panel_Upbar.Location = new System.Drawing.Point(0, 0);
            this.panel_Upbar.Name = "panel_Upbar";
            this.panel_Upbar.Size = new System.Drawing.Size(784, 30);
            this.panel_Upbar.TabIndex = 0;
            // 
            // label_Upbar
            // 
            this.label_Upbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Upbar.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Upbar.Location = new System.Drawing.Point(0, 0);
            this.label_Upbar.Name = "label_Upbar";
            this.label_Upbar.Size = new System.Drawing.Size(784, 30);
            this.label_Upbar.TabIndex = 0;
            this.label_Upbar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Node
            // 
            this.panel_Node.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel_Node.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Node.Controls.Add(this.flowLayoutPanel_NodeList);
            this.panel_Node.Location = new System.Drawing.Point(0, 30);
            this.panel_Node.Name = "panel_Node";
            this.panel_Node.Size = new System.Drawing.Size(588, 208);
            this.panel_Node.TabIndex = 1;
            // 
            // flowLayoutPanel_NodeList
            // 
            this.flowLayoutPanel_NodeList.AutoScroll = true;
            this.flowLayoutPanel_NodeList.AutoScrollMinSize = new System.Drawing.Size(0, 250);
            this.flowLayoutPanel_NodeList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel_NodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_NodeList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_NodeList.Name = "flowLayoutPanel_NodeList";
            this.flowLayoutPanel_NodeList.Padding = new System.Windows.Forms.Padding(9, 9, 5, 5);
            this.flowLayoutPanel_NodeList.Size = new System.Drawing.Size(586, 206);
            this.flowLayoutPanel_NodeList.TabIndex = 0;
            // 
            // panel_Result_DT
            // 
            this.panel_Result_DT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Result_DT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Result_DT.Controls.Add(this.label_Downbar);
            this.panel_Result_DT.Controls.Add(this.dataGridView_Get);
            this.panel_Result_DT.Location = new System.Drawing.Point(0, 236);
            this.panel_Result_DT.Name = "panel_Result_DT";
            this.panel_Result_DT.Size = new System.Drawing.Size(588, 260);
            this.panel_Result_DT.TabIndex = 2;
            // 
            // label_Downbar
            // 
            this.label_Downbar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_Downbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Downbar.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Downbar.Location = new System.Drawing.Point(0, 0);
            this.label_Downbar.Name = "label_Downbar";
            this.label_Downbar.Size = new System.Drawing.Size(586, 30);
            this.label_Downbar.TabIndex = 1;
            this.label_Downbar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_Get
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Get.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Get.ColumnHeadersHeight = 30;
            this.dataGridView_Get.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Get.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgg_order,
            this.dgg_node,
            this.dgg_probability});
            this.dataGridView_Get.Location = new System.Drawing.Point(0, 30);
            this.dataGridView_Get.Name = "dataGridView_Get";
            this.dataGridView_Get.ReadOnly = true;
            this.dataGridView_Get.RowHeadersVisible = false;
            this.dataGridView_Get.RowHeadersWidth = 30;
            this.dataGridView_Get.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Get.RowTemplate.Height = 30;
            this.dataGridView_Get.RowTemplate.ReadOnly = true;
            this.dataGridView_Get.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Get.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Get.Size = new System.Drawing.Size(586, 229);
            this.dataGridView_Get.TabIndex = 0;
            // 
            // dgg_order
            // 
            this.dgg_order.FillWeight = 76.14214F;
            this.dgg_order.HeaderText = "순서";
            this.dgg_order.Name = "dgg_order";
            this.dgg_order.ReadOnly = true;
            this.dgg_order.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgg_order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgg_order.Width = 50;
            // 
            // dgg_node
            // 
            this.dgg_node.FillWeight = 111.9289F;
            this.dgg_node.HeaderText = "경우의수";
            this.dgg_node.Name = "dgg_node";
            this.dgg_node.ReadOnly = true;
            this.dgg_node.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgg_node.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgg_node.Width = 360;
            // 
            // dgg_probability
            // 
            this.dgg_probability.FillWeight = 111.9289F;
            this.dgg_probability.HeaderText = "확률";
            this.dgg_probability.Name = "dgg_probability";
            this.dgg_probability.ReadOnly = true;
            this.dgg_probability.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgg_probability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgg_probability.Width = 207;
            // 
            // panel_Node_Control
            // 
            this.panel_Node_Control.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_Node_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Node_Control.Controls.Add(this.button_SaveFileDirectory);
            this.panel_Node_Control.Controls.Add(this.button_SaveFile);
            this.panel_Node_Control.Controls.Add(this.panel_Guard4);
            this.panel_Node_Control.Controls.Add(this.button_Init);
            this.panel_Node_Control.Controls.Add(this.panel_Guard3);
            this.panel_Node_Control.Controls.Add(this.comboBox_PickCount);
            this.panel_Node_Control.Controls.Add(this.label_PickCount);
            this.panel_Node_Control.Controls.Add(this.label1);
            this.panel_Node_Control.Controls.Add(this.button_Calculate);
            this.panel_Node_Control.Controls.Add(this.panel_Guard2);
            this.panel_Node_Control.Controls.Add(this.button_Delete);
            this.panel_Node_Control.Controls.Add(this.textBox_NodeProbability);
            this.panel_Node_Control.Controls.Add(this.label_NodeProbability);
            this.panel_Node_Control.Controls.Add(this.textBox_NodeName);
            this.panel_Node_Control.Controls.Add(this.label_NodeName);
            this.panel_Node_Control.Controls.Add(this.button_Save);
            this.panel_Node_Control.Controls.Add(this.button_AddNode);
            this.panel_Node_Control.Location = new System.Drawing.Point(588, 30);
            this.panel_Node_Control.Name = "panel_Node_Control";
            this.panel_Node_Control.Size = new System.Drawing.Size(196, 466);
            this.panel_Node_Control.TabIndex = 4;
            // 
            // button_SaveFileDirectory
            // 
            this.button_SaveFileDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.button_SaveFileDirectory.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_SaveFileDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_SaveFileDirectory.Location = new System.Drawing.Point(4, 428);
            this.button_SaveFileDirectory.Name = "button_SaveFileDirectory";
            this.button_SaveFileDirectory.Size = new System.Drawing.Size(186, 30);
            this.button_SaveFileDirectory.TabIndex = 18;
            this.button_SaveFileDirectory.Text = "파일 경로";
            this.button_SaveFileDirectory.UseVisualStyleBackColor = false;
            this.button_SaveFileDirectory.Click += new System.EventHandler(this.button_SaveFileDirectory_Click);
            // 
            // button_SaveFile
            // 
            this.button_SaveFile.BackColor = System.Drawing.SystemColors.Control;
            this.button_SaveFile.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_SaveFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_SaveFile.Location = new System.Drawing.Point(4, 393);
            this.button_SaveFile.Name = "button_SaveFile";
            this.button_SaveFile.Size = new System.Drawing.Size(186, 30);
            this.button_SaveFile.TabIndex = 17;
            this.button_SaveFile.Text = "파일 저장";
            this.button_SaveFile.UseVisualStyleBackColor = false;
            this.button_SaveFile.Click += new System.EventHandler(this.button_SaveFile_Click);
            // 
            // panel_Guard4
            // 
            this.panel_Guard4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel_Guard4.Location = new System.Drawing.Point(0, 385);
            this.panel_Guard4.Name = "panel_Guard4";
            this.panel_Guard4.Size = new System.Drawing.Size(196, 2);
            this.panel_Guard4.TabIndex = 16;
            // 
            // button_Init
            // 
            this.button_Init.BackColor = System.Drawing.SystemColors.Control;
            this.button_Init.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Init.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Init.Location = new System.Drawing.Point(5, 350);
            this.button_Init.Name = "button_Init";
            this.button_Init.Size = new System.Drawing.Size(186, 30);
            this.button_Init.TabIndex = 15;
            this.button_Init.Text = "초기화";
            this.button_Init.UseVisualStyleBackColor = false;
            this.button_Init.Click += new System.EventHandler(this.button_Init_Click);
            // 
            // panel_Guard3
            // 
            this.panel_Guard3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel_Guard3.Location = new System.Drawing.Point(0, 309);
            this.panel_Guard3.Name = "panel_Guard3";
            this.panel_Guard3.Size = new System.Drawing.Size(196, 2);
            this.panel_Guard3.TabIndex = 14;
            // 
            // comboBox_PickCount
            // 
            this.comboBox_PickCount.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_PickCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PickCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_PickCount.FormattingEnabled = true;
            this.comboBox_PickCount.Location = new System.Drawing.Point(5, 274);
            this.comboBox_PickCount.Name = "comboBox_PickCount";
            this.comboBox_PickCount.Size = new System.Drawing.Size(186, 29);
            this.comboBox_PickCount.TabIndex = 13;
            this.comboBox_PickCount.SelectedIndexChanged += new System.EventHandler(this.comboBox_PickCount_SelectedIndexChanged);
            // 
            // label_PickCount
            // 
            this.label_PickCount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_PickCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_PickCount.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_PickCount.Location = new System.Drawing.Point(5, 244);
            this.label_PickCount.Name = "label_PickCount";
            this.label_PickCount.Size = new System.Drawing.Size(186, 30);
            this.label_PickCount.TabIndex = 12;
            this.label_PickCount.Text = "뽑기 횟수";
            this.label_PickCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(161, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Calculate
            // 
            this.button_Calculate.BackColor = System.Drawing.SystemColors.Control;
            this.button_Calculate.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Calculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Calculate.Location = new System.Drawing.Point(5, 315);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(186, 30);
            this.button_Calculate.TabIndex = 10;
            this.button_Calculate.Text = "획득 확률 계산";
            this.button_Calculate.UseVisualStyleBackColor = false;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // panel_Guard2
            // 
            this.panel_Guard2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel_Guard2.Location = new System.Drawing.Point(0, 236);
            this.panel_Guard2.Name = "panel_Guard2";
            this.panel_Guard2.Size = new System.Drawing.Size(196, 2);
            this.panel_Guard2.TabIndex = 9;
            // 
            // button_Delete
            // 
            this.button_Delete.BackColor = System.Drawing.SystemColors.Control;
            this.button_Delete.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Delete.Location = new System.Drawing.Point(5, 170);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(186, 30);
            this.button_Delete.TabIndex = 7;
            this.button_Delete.Text = "아이템 삭제";
            this.button_Delete.UseVisualStyleBackColor = false;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // textBox_NodeProbability
            // 
            this.textBox_NodeProbability.Font = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_NodeProbability.Location = new System.Drawing.Point(5, 100);
            this.textBox_NodeProbability.Name = "textBox_NodeProbability";
            this.textBox_NodeProbability.Size = new System.Drawing.Size(156, 30);
            this.textBox_NodeProbability.TabIndex = 6;
            this.textBox_NodeProbability.Click += new System.EventHandler(this.textBox_NodeProbability_Click);
            this.textBox_NodeProbability.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NodeProbability_KeyPress);
            this.textBox_NodeProbability.Leave += new System.EventHandler(this.textBox_NodeProbability_Leave);
            // 
            // label_NodeProbability
            // 
            this.label_NodeProbability.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_NodeProbability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_NodeProbability.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_NodeProbability.Location = new System.Drawing.Point(5, 70);
            this.label_NodeProbability.Name = "label_NodeProbability";
            this.label_NodeProbability.Size = new System.Drawing.Size(186, 30);
            this.label_NodeProbability.TabIndex = 5;
            this.label_NodeProbability.Text = "획득 확률";
            this.label_NodeProbability.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_NodeName
            // 
            this.textBox_NodeName.Font = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_NodeName.Location = new System.Drawing.Point(5, 35);
            this.textBox_NodeName.Name = "textBox_NodeName";
            this.textBox_NodeName.Size = new System.Drawing.Size(186, 30);
            this.textBox_NodeName.TabIndex = 4;
            this.textBox_NodeName.Click += new System.EventHandler(this.textBox_NodeName_Click);
            // 
            // label_NodeName
            // 
            this.label_NodeName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_NodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_NodeName.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_NodeName.Location = new System.Drawing.Point(5, 5);
            this.label_NodeName.Name = "label_NodeName";
            this.label_NodeName.Size = new System.Drawing.Size(186, 30);
            this.label_NodeName.TabIndex = 3;
            this.label_NodeName.Text = "아이템 이름";
            this.label_NodeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.SystemColors.Control;
            this.button_Save.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Save.Location = new System.Drawing.Point(5, 135);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(186, 30);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "아이템 저장";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_AddNode
            // 
            this.button_AddNode.BackColor = System.Drawing.SystemColors.Control;
            this.button_AddNode.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_AddNode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_AddNode.Location = new System.Drawing.Point(5, 205);
            this.button_AddNode.Name = "button_AddNode";
            this.button_AddNode.Size = new System.Drawing.Size(186, 30);
            this.button_AddNode.TabIndex = 0;
            this.button_AddNode.Text = "새로운 아이템 추가";
            this.button_AddNode.UseVisualStyleBackColor = false;
            this.button_AddNode.Click += new System.EventHandler(this.button_AddNode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 496);
            this.Controls.Add(this.panel_Node_Control);
            this.Controls.Add(this.panel_Result_DT);
            this.Controls.Add(this.panel_Node);
            this.Controls.Add(this.panel_Upbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "다중 종속시행 확률 계산기 by배종원";
            this.panel_Upbar.ResumeLayout(false);
            this.panel_Node.ResumeLayout(false);
            this.panel_Result_DT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Get)).EndInit();
            this.panel_Node_Control.ResumeLayout(false);
            this.panel_Node_Control.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Upbar;
        private System.Windows.Forms.Panel panel_Node;
        private System.Windows.Forms.Panel panel_Result_DT;
        private System.Windows.Forms.Panel panel_Node_Control;
        private System.Windows.Forms.Label label_Upbar;
        private System.Windows.Forms.Button button_AddNode;
        private System.Windows.Forms.Label label_NodeName;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_NodeProbability;
        private System.Windows.Forms.TextBox textBox_NodeName;
        private System.Windows.Forms.TextBox textBox_NodeProbability;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.Panel panel_Guard2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_NodeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Guard3;
        private System.Windows.Forms.ComboBox comboBox_PickCount;
        private System.Windows.Forms.Label label_PickCount;
        public System.Windows.Forms.DataGridView dataGridView_Get;
        private System.Windows.Forms.Label label_Downbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgg_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgg_node;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgg_probability;
        private System.Windows.Forms.Button button_Init;
        private System.Windows.Forms.Button button_SaveFileDirectory;
        private System.Windows.Forms.Button button_SaveFile;
        private System.Windows.Forms.Panel panel_Guard4;
    }
}

