using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependentTrial_Calculator_V1
{
    public class Node_10000
    {
        public string sNodeName;

        public int nCode;
        public int nCode_After;
        public int nCode_Before;

        public int nNumerator;
        public int nDenominator;

        public Node_10000(string name, int ncode, int nn = 0, int nd = 10000)
        {
            sNodeName = name;

            nCode = ncode;
            nCode_After = -1;
            nCode_Before = -1;

            nNumerator = nn;
            nDenominator = nd;

            if (DT_V1.m_sl_NodeList.Count == 0)
            {
                DT_V1.m_sl_NodeList.Add(this);
            }
            else if (DT_V1.m_sl_NodeList.Count > 0)
            {
                if (DT_V1.m_sl_NodeList.Exists(Node_100 => Node_100.nCode == nCode) == true)
                {
                    Console.WriteLine("Node_100.nCode 중복");
                    //System.Environment.Exit(0);
                }
                else
                {
                    DT_V1.m_sl_NodeList.Add(this);
                }
            }
        }

        public void SetNodeName(string name)
        {
            sNodeName = name;
        }
        public void SetFraction(int nn, int nd)
        {
            nNumerator = nn;
            nDenominator = nd;
        }
    }
}
