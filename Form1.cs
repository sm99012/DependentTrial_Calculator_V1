using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependentTrial_Calculator_V1
{
    public partial class Form1 : Form
    {
        // 종속시행 계산 관련 클래스
        DT_V1 DV;
        // 노드 항목
        Dictionary<int, Label> m_Dictionary_LabelNode;
        // 현재 선택중인 노드
        Label m_Label_Current = null;
        // 생성된 노드코드
        static int m_sn_NodeCode;
        // 계산된 결과가 존재 하는지 판단
        bool m_bCalculate;

        public Form1()
        {
            InitializeComponent();

            DV = new DT_V1(this);

            m_Dictionary_LabelNode = new Dictionary<int, Label>();

            m_sn_NodeCode = 0;

            m_bCalculate = false;

            dataGridView_Get.Rows.Clear();
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");

            Load_SaveFileDirectory();
        }

        private void button_AddNode_Click(object sender, EventArgs e)
        {
            m_sn_NodeCode += 1;
            Node_10000 Node = new Node_10000("아이템 " + (m_sn_NodeCode).ToString(), m_sn_NodeCode);

            Label label = new Label();
            label.Name = "label_Node" + m_sn_NodeCode.ToString();
            label.Text = Node.sNodeName + "\r\n" + (Node.nNumerator / Node.nDenominator).ToString("000.00") + "%";
            label.Size = new Size(106, 60);
            label.BackColor = System.Drawing.SystemColors.ControlDark;
            label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label.Location = new System.Drawing.Point(9, 9);
            label.Margin = new System.Windows.Forms.Padding(0, 0, 5, 9);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Click += new System.EventHandler(this.label_Node_Click);

            m_Dictionary_LabelNode.Add(m_sn_NodeCode, label);

            flowLayoutPanel_NodeList.Controls.Add(label);

            SetComboBox_PickCount();
            label_Node_Click(label, e);
        }
        private void label_Node_Click(object sender, EventArgs e)
        {
            InitLabel_Color();

            Label label = (Label)sender;
            label.BackColor = SystemColors.Control;

            m_Label_Current = label;

            int nindex = Return_LabelNodeCode(m_Label_Current);
            nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);
            textBox_NodeName.Text = DT_V1.m_sl_NodeList[nindex].sNodeName;
            textBox_NodeProbability.Text = ((decimal)((decimal)DT_V1.m_sl_NodeList[nindex].nNumerator / (decimal)DT_V1.m_sl_NodeList[nindex].nDenominator) * 100).ToString("000.00");

            SetTitle();
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (m_Label_Current != null)
            {
                if (textBox_NodeName.Text != string.Empty && textBox_NodeProbability.Text != string.Empty)
                {
                    int nindex = Return_LabelNodeCode(m_Label_Current);
                    nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);

                    DT_V1.m_sl_NodeList[nindex].sNodeName = textBox_NodeName.Text;

                    textBox_NodeProbability_Leave();
                    decimal dfraction = decimal.Parse(textBox_NodeProbability.Text);
                    DT_V1.m_sl_NodeList[nindex].nNumerator = (int)(dfraction * (decimal)100);
                    DT_V1.m_sl_NodeList[nindex].nDenominator = 10000;

                    m_Label_Current.Text = DT_V1.m_sl_NodeList[nindex].sNodeName + "\r\n" + ((decimal)((decimal)DT_V1.m_sl_NodeList[nindex].nNumerator / (decimal)DT_V1.m_sl_NodeList[nindex].nDenominator) * 100).ToString("000.00") + "%";

                    SetTitle();
                }
            }
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (m_Label_Current != null)
            {
                int nindex = Return_LabelNodeCode(m_Label_Current);
                m_Dictionary_LabelNode.Remove(nindex);
                flowLayoutPanel_NodeList.Controls.Remove(m_Label_Current);
                m_Label_Current = null;

                nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);       
                DT_V1.m_sl_NodeList.RemoveAt(nindex);

                InitInput();

                int nodecount = 0;
                foreach(KeyValuePair<int, Label> item in m_Dictionary_LabelNode)
                {
                    nodecount += 1;

                    if (nodecount == m_Dictionary_LabelNode.Count)
                    {
                        label_Node_Click(m_Dictionary_LabelNode[item.Key], e);
                        break;
                    }
                }


                SetComboBox_PickCount();
                SetTitle();
            }
        }


        // Upbar 제목 설정
        void SetTitle()
        {
            int nindex = -1;
            if (m_Label_Current != null)
            {
                nindex = Return_LabelNodeCode(m_Label_Current);
                nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);
            }

            if (comboBox_PickCount.Text == string.Empty)
            {
                label_Upbar.Text = "전체 " + m_Dictionary_LabelNode.Count.ToString() + "개 중에서 " +
                    "0개를 뽑을때 '";
            }
            else
            {
                label_Upbar.Text = "전체 " + m_Dictionary_LabelNode.Count.ToString() + "개 중에서 " +
                    comboBox_PickCount.Text + "개를 뽑을때 '";
            }


            if (nindex != -1)
            {
                label_Upbar.Text += DT_V1.m_sl_NodeList[nindex].sNodeName + "'을(를) 뽑을 확률";
            }
            else
            {
                label_Upbar.Text += " '을(를) 뽑을 확률";
            }
        }
        // 뽑기 횟수 설정
        void SetComboBox_PickCount()
        {
            comboBox_PickCount.Items.Clear();
            for (int i = 0; i < DT_V1.m_sl_NodeList.Count; i++)
            {
                comboBox_PickCount.Items.Add(i + 1);
            }
        }
        private void comboBox_PickCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTitle();
        }
        // 노드 번호 반환
        int Return_LabelNodeCode(Label label)
        {
            return int.Parse(label.Name.Substring(10, (label.Name.Length - 10)));
        }

        // 노드 색상 초기화
        void InitLabel_Color()
        {
            foreach (KeyValuePair<int, Label> item in m_Dictionary_LabelNode)
            {
                m_Dictionary_LabelNode[item.Key].BackColor = SystemColors.ControlDark;
            }
        }
        // 입력란 초기화
        void InitInput()
        {
            textBox_NodeName.Text = "";
            textBox_NodeProbability.Text = "";
        }

        private void textBox_NodeProbability_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && (e.KeyChar != '.') && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }
        private void textBox_NodeName_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void textBox_NodeProbability_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void textBox_NodeProbability_Leave(object sender = null, EventArgs e = null)
        {
            if (m_Label_Current != null)
            {
                int nindex = Return_LabelNodeCode(m_Label_Current);
                nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);

                decimal dTotal = 0;

                for (int i = 0; i < DT_V1.m_sl_NodeList.Count; i++)
                {
                    if (i != nindex)
                    {
                        dTotal += DT_V1.m_sl_NodeList[i].nNumerator;
                    }
                }
                dTotal = dTotal / 100;

                textBox_NodeProbability.Text = decimal.Parse(textBox_NodeProbability.Text).ToString("000.00");

                if (decimal.Parse(textBox_NodeProbability.Text) > 100)
                {
                    textBox_NodeProbability.Text = "100.00";
                }
                if (decimal.Parse(textBox_NodeProbability.Text) < 0)
                {
                    textBox_NodeProbability.Text = "0";
                }
                if (decimal.Parse(textBox_NodeProbability.Text) > 100 - dTotal)
                {
                    textBox_NodeProbability.Text = (100 - dTotal).ToString("000.00");
                }
                else
                    textBox_NodeProbability.Text = decimal.Parse(textBox_NodeProbability.Text).ToString("000.00");
            }
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            if (m_Dictionary_LabelNode.Count > 0)
            {
                if (comboBox_PickCount.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    dataGridView_Get.Rows.Clear();
                    dataGridView_Get.Rows.Add("", "", "");
                    dataGridView_Get.Rows.Add("", "", "");
                    dataGridView_Get.Rows.Add("", "", "");
                    dataGridView_Get.Rows.Add("", "", "");
                    dataGridView_Get.Rows.Add("", "", "");

                    int nindex = Return_LabelNodeCode(m_Label_Current);
                    nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);

                    dataGridView_Get.Rows.Clear();
                    dataGridView_Get.Rows.Add("", "획득 확률", "");
                    DV.DT_V1_Get(m_Dictionary_LabelNode.Count, int.Parse(comboBox_PickCount.Text), DT_V1.m_sl_NodeList[nindex].nCode);
                    dataGridView_Get.Rows.Add("", "미획득 확률", "");
                    DV.DT_V1_NotGet(m_Dictionary_LabelNode.Count, int.Parse(comboBox_PickCount.Text), DT_V1.m_sl_NodeList[nindex].nCode);

                    m_bCalculate = true;

                    nindex = -1;
                    if (m_Label_Current != null)
                    {
                        nindex = Return_LabelNodeCode(m_Label_Current);
                        nindex = DT_V1.m_sl_NodeList.FindIndex(Node_10000 => Node_10000.nCode == nindex);
                    }

                    if (comboBox_PickCount.Text == string.Empty)
                    {
                        label_Downbar.Text = "전체 " + m_Dictionary_LabelNode.Count.ToString() + "개 중에서 " +
                            "0개를 뽑을때 '";
                    }
                    else
                    {
                        label_Downbar.Text = "전체 " + m_Dictionary_LabelNode.Count.ToString() + "개 중에서 " +
                            comboBox_PickCount.Text + "개를 뽑을때 '";
                    }


                    if (nindex != -1)
                    {
                        label_Downbar.Text += DT_V1.m_sl_NodeList[nindex].sNodeName + "'을(를) 뽑을 확률";
                    }
                    else
                    {
                        label_Downbar.Text += "아무것도 안뽑을 확률";
                    }
                }
            }
            else
                return;
        }

        // DataGridView 확률 계산 표 출력
        public void Add_Result_Calculate(int norder, string snode, decimal dprobability)
        {
            dataGridView_Get.Rows.Add(norder.ToString().PadLeft(6, '0'), snode, dprobability.ToString("000.0000000000000000") + " %");

            //Console.WriteLine(" : [" + (m_dProbability * 100).ToString("0.00000000000000").PadRight(16, '0') + "%)]\n");
        }
        public void Total_Result_Calculate(string stotalprobability, int rowindex)
        {
            dataGridView_Get.Rows[rowindex].Cells[2].Value = stotalprobability;
            dataGridView_Get.Rows[rowindex].DefaultCellStyle.BackColor = SystemColors.ControlDark;
        }

        // 초기화
        private void button_Init_Click(object sender, EventArgs e)
        {
            DT_V1.m_sl_NodeList.Clear();

            foreach (KeyValuePair<int, Label> item in m_Dictionary_LabelNode)
            {
                m_Dictionary_LabelNode[item.Key].Dispose();
            }
            m_Dictionary_LabelNode.Clear();

            textBox_NodeName.Text = string.Empty;
            textBox_NodeProbability.Text = string.Empty;

            m_bCalculate = false;

            dataGridView_Get.Rows.Clear();
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");
            dataGridView_Get.Rows.Add("", "", "");

            label_Upbar.Text = string.Empty;
            label_Downbar.Text = string.Empty;

            SetComboBox_PickCount();
            SetTitle();
        }

        private void button_SaveFile_Click(object sender, EventArgs e)
        {
            if (m_bCalculate == true)
            {
                DateTime dt = DateTime.Now;

                if (Directory.Exists(m_sPath_Directory) == false)
                    Directory.CreateDirectory(m_sPath_Directory);

                string spath_file = "/" + dt.Year + dt.Month.ToString("00") + dt.Day.ToString("00") + "." + dt.Hour + "." + dt.Minute + "." + dt.Second + ".csv";
                if (File.Exists(m_sPath_Directory + spath_file) == false)
                {
                    StreamWriter SW = new StreamWriter(m_sPath_Directory + spath_file);
                    for (int i = 0; i < dataGridView_Get.RowCount - 1; i++)
                    {
                        SW.WriteLine(dataGridView_Get.Rows[i].Cells[0].Value.ToString() + "," + dataGridView_Get.Rows[i].Cells[1].Value.ToString() + "," + dataGridView_Get.Rows[i].Cells[2].Value.ToString());
                    }
                    SW.Close();
                }

                MessageBox.Show(m_sPath_Directory + spath_file, "데이터 저장 완료", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("계산된 데이터가 존재하지 않습니다.", "데이터 저장 실패", MessageBoxButtons.OK);
        }
        string m_sPath_Directory = "./SaveData";
        private void button_SaveFileDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                m_sPath_Directory = FBD.SelectedPath;
                Save_SaveFileDirectory(m_sPath_Directory);
            }
        }


        // RunData 불러오기
        // 파일 저장경로 불러오기
        void Load_SaveFileDirectory()
        {
            if (File.Exists("./RunData.csv") == true)
            {
                StreamReader SR = new StreamReader("./RunData.csv");

                m_sPath_Directory = SR.ReadLine();
                SR.Close();
            }
            else
            {
                m_sPath_Directory = "./SaveData";
            }
        }
        // RunData 저장
        // 파일 저장경로 저장
        void Save_SaveFileDirectory(string spath)
        {
            StreamWriter SW = new StreamWriter("./RunData.csv");

            SW.Write(spath);
            SW.Close();
        }
    }
}
