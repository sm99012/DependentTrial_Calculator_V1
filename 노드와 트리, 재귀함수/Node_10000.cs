using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependentTrial_Calculator_V1
{
    // 종속시행 확률을 계산함에 있어 각각의 노드(아이템) 정보(노드(아이템) 이름, 노드 번호, 이전ㆍ이후 노드 번호, 획득 확률)가 저장되는 클래스이다.
    // 노드(아이템) 획득 확률은 0.01% ~ 100% 까지 지정이 가능하다. 이 범위를 넘어선 확률은 지정이 불가능하다.
    // 생성된 노드(아이템)는 DT_V1 클래스에서 List로 관리되며, 이중 연결 리스트 구조를 가진 트리가 생성될때 사용된다. 트리는 종속시행의 경우에 해당하고 해당 경우의 확률을 결과로 출력한다.
    public class Node_10000
    {
        public string sNodeName; // 노드(아이템) 이름
        public int nCode;        // 노드 번호. 고유의 노드 번호이며 중복된 노드 번호를 가진 노드가 존재하지 않는다.
        
        // 이전ㆍ이후 노드 번호는 -1로 초기화된다. -1의 의미는 이전 또는 이후 노드 번호가 존재하지 않음을 의미한다.
        // 이전 노드 번호 == -1 && 이후 노드 번호 != -1 인 경우 : 최초의 노드(트리 최상단)
        // 이전 노드 번호 != -1 && 이후 노드 번호 == -1 인 경우 : 최후의 노드(트리 최하단)
        // 이전 노드 번호 == -1 && 이후 노드 번호 == -1 인 경우 : 연결되지 않은 노드(트리에 존재하지 않는 노드)
        public int nCode_After;  // 이전 노드 번호(초기값 = -1)
        public int nCode_Before; // 이후 노드 번호(초기값 = -1)

        public int nNumerator;   // 분자(0 ~ 10000 사이값)
        public int nDenominator; // 분모(10000 고정값. 분자(n) / 10000 >= 0.01)

        // 생성자
        public Node_10000(string name, int ncode, int nn = 0, int nd = 10000)
        {
            sNodeName = name;
            nCode = ncode;
            
            nCode_After = -1;
            nCode_Before = -1;

            nNumerator = nn;
            nDenominator = nd;

            // 생성된 노드(아이템)는 DT_V1 클래스의 List(m_sl_NodeList)에 저장되어 관리된다.
            if (DT_V1.m_sl_NodeList.Count == 0)
            {
                DT_V1.m_sl_NodeList.Add(this);
            }
            else if (DT_V1.m_sl_NodeList.Count > 0)
            {
                if (DT_V1.m_sl_NodeList.Exists(Node_100 => Node_100.nCode == nCode) == true)
                {
                    Console.WriteLine("Node_10000.nCode 중복");
                    //System.Environment.Exit(0);
                }
                else
                {
                    DT_V1.m_sl_NodeList.Add(this);
                }
            }
        }

        // 노드(아이템) 이름 설정 함수
        public void SetNodeName(string name)
        {
            sNodeName = name;
        }
        // 노드(아이템) 획득 확률 설정 함수
        public void SetFraction(int nn, int nd)
        {
            nNumerator = nn;
            nDenominator = nd;
        }
    }
}
