﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependentTrial_Calculator_V1
{
    public class DT_V1
    {
        Form1 m_Form; // 윈폼과의 연계를 위한 Form1 변수

        public static List<Node_10000> m_sl_NodeList; // 생성된 노드(아이템)을 관리하기 위한 저장소
        
        public static int m_sn_CaseCount; // 종속시행 경우의수 번호(개수)
        public int m_nPickCount; // 현재 노드(아이템) 획득 개수. 재귀함수의 진행 시점, 되돌아가는 시점, 정보 출력 시점 판단에 사용된다.

        public decimal m_dTotal;              // 노드(아이템) 획득ㆍ미획득 확률 총합
        public decimal m_dProbability_Total;  // 각 경우 별 확률
        public decimal m_dProbability;        // 각 경우 별 노드(아이템) 획득 확률
        public decimal m_dDenominator_Before; // 종속시행 확률 계산에 사용되는 변수(분모 - 이전 노드 획득 확률(분자))

        // 윈폼에서 호출되는 DT_V1 클래스 생성자. 각종 변수 초기화
        public DT_V1(Form1 form)
        {
            m_Form = form;

            m_sl_NodeList = new List<Node_10000>();
            m_sn_CaseCount = 0;

            m_nPickCount = 0;

            m_dTotal = 0;
            m_dProbability_Total = 0;
            m_dProbability = 0;
            m_dDenominator_Before = 0;
        }

        // 다중 종속시행 확률 계산 함수 1
        // 전체 nnode_count개 노드(아이템) 중에서 npick_count개를 획득할때(뽑을때) 노드번호가 nnode_code인 노드(아이템)를 획득할(뽑을) 확률 출력
        public void DT_V1_Get(int nnode_count, int npick_count, int nnode_code) // nnode_count : 전체 노드(아이템) 개수, npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            DT_V1_Init_All(); // 모든 변수를 초기화하는 함수. 단 m_sl_NodeList(생성된 노드(아이템)을 관리하기 위한 저장소) 에 저장된 노드 자체는 삭제되지 않지만 이전ㆍ이후 노드 번호는 초기화된다.(이중 연결 리스트 구조의 트리 초기화)
                              // 이중 연결 리스트 구조의 트리 : 각각의 다중 종속시행 경우

            DT_V1_Check_Get(npick_count, nnode_code); // 다중 종속시행 확률 계산 함수 2
            
            m_dTotal += m_dProbability_Total; // 노드(아이템) 획득 확률 총합
            m_Form.Total_Result_Calculate((m_dProbability_Total * 100).ToString("000.0000000000000000") + " %", 0); // 윈폼UI 에 노드번호가 nnode_code인 노드(아이템)를 획득할(뽑을) 확률 출력

        }
        // 다중 종속시행 확률 계산 함수 2
        // 노드(아이템) 획득 개수에 따라 재귀함수의 적용이 필요 없을수도 있기에 구분 적용했다.
        void DT_V1_Check_Get(int npick_count, int nnode_code) // npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            if (npick_count > 1) // 재귀함수 적용이 필요한 경우
            {
                for (int i = 0; i < m_sl_NodeList.Count; i++)
                {
                    List<int> rlist = Return_Node_Index_Null(); // 사용하지 않은 노드(아이템)list를 반환하는 함수
                    m_nPickCount = 0;
                    DT_V1_Reflection_Get(rlist, i, npick_count, nnode_code); // 다중 종속시행 확률 계산 함수 3 (재귀함수)
                    DT_V1_Init(); // 이중 연결 리스트 구조의 트리를 초기화하는 함수
                }
            }
            else if (npick_count == 1) // 재귀함수 적용이 필요하지 않은 경우. 계산이 필요하지 않은 경우
            {
                for (int i = 0; i < m_sl_NodeList.Count; i++)
                {
                    if (nnode_code == m_sl_NodeList[i].nCode)
                    {
                        nOrder = 0; sNode = string.Empty; dprobability = 0;
                        nOrder = m_sn_CaseCount += 1;
                        sNode += "[" + m_sl_NodeList[i].sNodeName + "]";

                        m_dProbability = (decimal)m_sl_NodeList[i].nNumerator / (decimal)m_sl_NodeList[i].nDenominator;
                        m_dProbability_Total += (decimal)m_sl_NodeList[i].nNumerator / (decimal)m_sl_NodeList[i].nDenominator;
                        m_Form.Add_Result_Calculate(nOrder, sNode, m_dProbability * 100); // 윈폼UI 에 노드번호가 nnode_code인 노드(아이템)을 획득할(뽑을) 확률 출력
                    }
                }
            }
        }
        // 다중 종속시행 확률 계산 함수 3 (재귀함수)
        // m_nPickCount(현재 노드(아이템) 획득 개수)와 npick_count(노드(아이템) 획득 개수)의 관계를 따져 진행하거나, 되돌아가거나, 정보를 출력한다.
        // 함수 실행 매커니즘
        // 1. DT_V1_Check_Get(ㆍㆍㆍ) 함수에서 DT_V1_Reflection_Get(ㆍㆍㆍ) 함수를 실행한다.
        // 2_1. DT_V1_Reflection_Get(ㆍㆍㆍ) 함수에서 매개변수 nNode_10000index 와 다른 배열의 노드를 이용해 트리를 작성한다.
        // 2_2. Return_Node_Index_Null() 함수를 이용해 사용하지 않은 노드(아이템)list를 반환하여 트리를 작성한다.
        // 3. DT_V1_Init(ㆍㆍㆍ) 함수를 이용해 한단계 되돌아간다.
        // 위 과정을 반복해 모든 아이템 획득 경우를 구한다. 시간복잡도 = n(노드의 수)^m(뽑기 시행 횟수)
        void DT_V1_Reflection_Get(List<int> list, int nNode_10000index, int npick_count, int nnode_code) // list : 사용하지 않는 노드(아이템) list, nNode_10000index : 사용한 노드(아이템) 배열 번호, npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            m_nPickCount += 1;
            if (m_nPickCount < npick_count) // 트리 최하단이 지정되지 않은 경우. 트리 생성이 미완성된 경우(종속시행 경우 생성이 미완성된 경우)
            {
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != nNode_10000index)
                        {
                            // 사용하지 않은 노드(아이템)로 트리(이중 연결 리스트)를 구현(연결)
                            m_sl_NodeList[nNode_10000index].nCode_After = m_sl_NodeList[list[i]].nCode;
                            m_sl_NodeList[list[i]].nCode_Before = m_sl_NodeList[nNode_10000index].nCode;
                            
                            // 사용하지 않은 노드(아이템)list를 반환하는 함수
                            List<int> rlist = Return_Node_Index_Null();
                            // 재귀함수(진행)
                            DT_V1_Reflection_Get(rlist, list[i], npick_count, nnode_code);
                            // 한단계 되돌아가는 함수
                            DT_V1_Init(m_sl_NodeList[nNode_10000index].nCode_After);
                        }
                    }
                }
            }
            else if (m_nPickCount == npick_count) // 트리 최하단이 지정된 경우
            {
                // 노드(아이템)번호가 nnode_code인 노드(아이템)가 제대로 연결되어 있는지 판단(제대로 트리를 구성하고 있는지 판단)
                if (Check_Node_Exist(nnode_code, -1) == true)
                {
                    // 구성된 트리(노드(아이템) 경우의수)의 확률 정보 출력
                    DT_V1_Print2();
                }
            }
            m_nPickCount -= 1;
        }

        // 다중 종속시행 확률 계산 함수 1
        // 전체 nnode_count개 노드 중에서 npick_count개를 뽑을때 노드번호가 nnode_code인 노드를 뽑지 못할 확률
        public void DT_V1_NotGet(int nnode_count, int npick_count, int nnode_code) // nnode_count : 전체 노드(아이템) 개수, npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            DT_V1_Init_All(); // 모든 변수를 초기화하는 함수. 단 m_sl_NodeList(생성된 노드(아이템)을 관리하기 위한 저장소) 에 저장된 노드 자체는 삭제되지 않지만 이전ㆍ이후 노드 번호는 초기화된다.(이중 연결 리스트 구조의 트리 초기화)
                              // 이중 연결 리스트 구조의 트리 : 각각의 다중 종속시행 경우

            int nrowindex = m_Form.dataGridView_Get.RowCount - 2;
            
            DT_V1_Check_NotGet(npick_count, nnode_code); // 다중 종속시행 확률 계산 함수 2
            
            m_dTotal += m_dProbability_Total; // 노드(아이템) 미획득 확률 총합
            m_Form.Total_Result_Calculate((m_dProbability_Total * 100).ToString("000.0000000000000000") + " %", nrowindex); // 윈폼UI 에 노드번호가 nnode_code인 노드(아이템)를 획득하지 못할(뽑지 못할) 확률 출력
        }
        // 다중 종속시행 확률 계산 함수 2
        // 노드(아이템) 획득 개수에 따라 재귀함수의 적용이 필요 없을수도 있기에 구분 적용했다.
        void DT_V1_Check_NotGet(int npick_count, int nnode_code) // npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            if (npick_count > 1) // 재귀함수 적용이 필요한 경우
            {
                for (int i = 0; i < m_sl_NodeList.Count; i++)
                {
                    List<int> rlist = Return_Node_Index_Null(); // 사용하지 않은 노드(아이템)list를 반환하는 함수
                    m_nPickCount = 0;
                    DT_V1_Reflection_NotGet(rlist, i, npick_count, nnode_code); // 다중 종속시행 확률 계산 함수 3 (재귀함수)
                    DT_V1_Init(); // 이중 연결 리스트 구조의 트리를 초기화하는 함수
                }
            }
            else if (npick_count == 1) // 재귀함수 적용이 필요하지 않은 경우. 계산이 필요하지 않은 경우
            {
                for (int i = 0; i < m_sl_NodeList.Count; i++)
                {
                    if (nnode_code != m_sl_NodeList[i].nCode)
                    {
                        nOrder = 0; sNode = string.Empty; dprobability = 0;
                        nOrder = m_sn_CaseCount += 1;
                        sNode += "[" + m_sl_NodeList[i].sNodeName + "]";

                        m_dProbability = (decimal)m_sl_NodeList[i].nNumerator / (decimal)m_sl_NodeList[i].nDenominator;
                        m_dProbability_Total += (decimal)m_sl_NodeList[i].nNumerator / (decimal)m_sl_NodeList[i].nDenominator;
                        m_Form.Add_Result_Calculate(nOrder, sNode, m_dProbability * 100); // 윈폼UI 에 노드번호가 nnode_code인 노드(아이템)을 획득할(뽑을) 확률 출력
                    }
                }
            }
            else if (npick_count < 1)
            {
                Console.WriteLine("[00000]\n");
            }
        }
        // 다중 종속시행 확률 계산 함수 3 (재귀함수)
        // m_nPickCount(현재 노드(아이템) 획득 개수)와 npick_count(노드(아이템) 획득 개수)의 관계를 따져 진행하거나, 되돌아가거나, 정보를 출력한다.
        // 함수 실행 매커니즘
        // 1. DT_V1_Check_Get(ㆍㆍㆍ) 함수에서 DT_V1_Reflection_Get(ㆍㆍㆍ) 함수를 실행한다.
        // 2_1. DT_V1_Reflection_Get(ㆍㆍㆍ) 함수에서 매개변수 nNode_10000index 와 다른 배열의 노드를 이용해 트리를 작성한다.
        // 2_2. Return_Node_Index_Null() 함수를 이용해 사용하지 않은 노드(아이템)list를 반환하여 트리를 작성한다.
        // 3. DT_V1_Init(ㆍㆍㆍ) 함수를 이용해 한단계 되돌아간다.
        // 위 과정을 반복해 모든 아이템 획득 경우를 구한다. 시간복잡도 = n(노드의 수)^m(뽑기 시행 횟수)
        void DT_V1_Reflection_NotGet(List<int> list, int nNode_100index, int npick_count, int nnode_code) // list : 사용하지 않는 노드(아이템) list, nNode_10000index : 사용한 노드(아이템) 배열 번호, npick_count : 노드(아이템) 획득 개수, nnode_code : 획득할 노드(아이템) 번호
        {
            m_nPickCount += 1;
            if (m_nPickCount < npick_count) // 트리 최하단이 지정되지 않은 경우. 트리 생성이 미완성된 경우(종속시행 경우 생성이 미완성된 경우)
            {
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != nNode_100index)
                        {
                            // 사용하지 않은 노드(아이템)로 트리(이중 연결 리스트)를 구현(연결)
                            m_sl_NodeList[nNode_100index].nCode_After = m_sl_NodeList[list[i]].nCode;
                            m_sl_NodeList[list[i]].nCode_Before = m_sl_NodeList[nNode_100index].nCode;

                            // 사용하지 않은 노드(아이템)list를 반환하는 함수
                            List<int> rlist = Return_Node_Index_Null();
                            // 재귀함수(진행)
                            DT_V1_Reflection_NotGet(rlist, list[i], npick_count, nnode_code);
                            // 한단계 되돌아가는 함수
                            DT_V1_Init(m_sl_NodeList[nNode_100index].nCode_After);
                        }
                    }
                }
            }
            else if (m_nPickCount == npick_count) // 트리 최하단이 지정된 경우
            {
                // 노드(아이템)번호가 nnode_code인 노드(아이템)가 제대로 연결되어 있는지 판단(제대로 트리를 구성하고 있는지 판단)
                if (Check_Node_Exist(nnode_code, -1) == false)
                {
                    // 구성된 트리(노드(아이템) 경우의수)의 확률 정보 출력
                    DT_V1_Print2();
                }
            }
            m_nPickCount -= 1;
        }

        // 노드번호가 nnode_code인 노드가 현재 연결되어 있는지 판단하는 조건부 재귀함수
        // 람다식을 이용해 List 내부 배열 번호를 검색했다.
        bool Check_Node_Exist(int nnode_code, int nnode_code_start)
        {
            int nindex;
            if (nnode_code_start == -1)
                nindex = m_sl_NodeList.FindIndex(Node => (Node.nCode_Before == -1 && Node.nCode_After != -1));
            else
                nindex = m_sl_NodeList.FindIndex(Node => Node.nCode == nnode_code_start);

            if (m_sl_NodeList[nindex].nCode == nnode_code)
                return true;
            else
            {
                if (m_sl_NodeList[nindex].nCode_After != -1)
                    return Check_Node_Exist(nnode_code, m_sl_NodeList[nindex].nCode_After);
                else
                    return false;
            }
        }
        // 사용하지 않은 노드(아이템)list를 반환하는 함수
        List<int> Return_Node_Index_Null()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < m_sl_NodeList.Count; i++)
            {
                if (m_sl_NodeList[i].nCode_After == -1 && m_sl_NodeList[i].nCode_Before == -1)
                {
                    list.Add(i);
                }
            }

            return list;
        }
        // 이중 연결 리스트 구조의 트리를 초기화하는 함수
        void DT_V1_Init()
        {
            for (int i = 0; i < m_sl_NodeList.Count; i++)
            {
                m_sl_NodeList[i].nCode_After = -1;
                m_sl_NodeList[i].nCode_Before = -1;
            }
        }
        // 모든 변수를 초기화하는 함수. 단 m_sl_NodeList(생성된 노드(아이템)을 관리하기 위한 저장소) 에 저장된 노드는 삭제되지 않지만 이중 연결 리스트 구조의 트리는 초기화된다.
        void DT_V1_Init_All()
        {
            m_sn_CaseCount = 0;

            m_nPickCount = 0;

            m_dTotal = 0;
            m_dProbability_Total = 0;
            m_dProbability = 0;
            m_dDenominator_Before = 0;

            for (int i = 0; i < m_sl_NodeList.Count; i++)
            {
                m_sl_NodeList[i].nCode_After = -1;
                m_sl_NodeList[i].nCode_Before = -1;
            }
        }
        // 노드번호가 nnode_code인 노드와 해당 노드 이후의 모든 노드 초기화
        void DT_V1_Init(int nnode_code)
        {
            if (m_sl_NodeList.Exists(Node_100 => Node_100.nCode == nnode_code) == true)
            {
                int nindex = m_sl_NodeList.FindIndex(Node_100 => Node_100.nCode == nnode_code);

                if (m_sl_NodeList[nindex].nCode_After != -1)
                {
                    DT_V1_Init(m_sl_NodeList[nindex].nCode_After);
                }

                m_sl_NodeList[nindex].nCode_After = -1;
                m_sl_NodeList[nindex].nCode_Before = -1;
            }
        }
        // 트리(종속시행 경우)의 확률을 출력하는 조건부 재귀함수
        int nOrder;
        string sNode;
        decimal dprobability;
        void DT_V1_Print2()
        {
            nOrder = 0; sNode = string.Empty; dprobability = 0;
            int nindex = m_sl_NodeList.FindIndex(Node_100 => (Node_100.nCode_Before == -1 && Node_100.nCode_After != -1));

            nOrder = m_sn_CaseCount += 1;
            sNode += "[" + m_sl_NodeList[nindex].sNodeName + "]";

            m_dProbability = (decimal)m_sl_NodeList[nindex].nNumerator / (decimal)m_sl_NodeList[nindex].nDenominator;
            m_dDenominator_Before = 10000;
            if (m_sl_NodeList[nindex].nCode_After != -1)
            {
                DT_V1_Print_2(m_sl_NodeList.FindIndex(Node_100 => Node_100.nCode == m_sl_NodeList[nindex].nCode_After), nindex);
            }

            m_Form.Add_Result_Calculate(nOrder, sNode, m_dProbability * 100);
        }
        void DT_V1_Print_2(int nindex, int nindex_before)
        {
            sNode += " - [" + m_sl_NodeList[nindex].sNodeName + "]";

            m_dDenominator_Before -= m_sl_NodeList[nindex_before].nNumerator;
            m_dProbability *= (decimal)m_sl_NodeList[nindex].nNumerator / m_dDenominator_Before;

            if (m_sl_NodeList[nindex].nCode_After != -1)
                DT_V1_Print_2(m_sl_NodeList.FindIndex(Node_100 => Node_100.nCode == m_sl_NodeList[nindex].nCode_After), nindex);
            else
            {
                m_dProbability_Total += m_dProbability;

                dprobability = m_dProbability * 100;
            }
        }
    }
}
