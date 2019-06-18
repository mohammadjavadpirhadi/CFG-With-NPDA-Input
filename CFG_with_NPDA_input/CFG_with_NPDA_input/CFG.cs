using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_with_NPDA_input
{
    class CFG
    {
        private List<string> NumberToVariable { get; }
        public List<Tuple<List<char>, List<int>, List<int>>> Transitions { get; }
        public int InitialState { get; }
        public int StateCount { get; }

        public CFG(NPDA npda)
        {
            if (npda.FinalStates.Count != 1)
                throw new Exception("Can not convert this NPDA to CFG beacuase it has more than 1 final state!");
            NumberToVariable = new List<string>();
            Transitions = new List<Tuple<List<char>, List<int>, List<int>>>();
            string leftSide;
            string rightSide1;
            string rightSide2;
            int indexOfLeftSide;
            int indexOfRightSide1;
            int indexOfRightSide2;
            for (int source = 0; source < npda.Transitions.Length; source++)
            {
                var transition = npda.Transitions[source];
                for (int i = 0; i < transition.Item4.Count; i++)
                {
                    if (transition.Item4[i] == "_")
                    {
                        leftSide = string.Format("(q{0}{1}q{2})", source, transition.Item3[i], transition.Item1[i]);
                        indexOfLeftSide = NumberToVariable.IndexOf(leftSide);
                        if (indexOfLeftSide != -1)
                        {
                            Transitions[indexOfLeftSide].Item1.Add(transition.Item2[i]);
                            Transitions[indexOfLeftSide].Item2.Add(-1);
                            Transitions[indexOfLeftSide].Item3.Add(-1);
                        }
                        else
                        {
                            NumberToVariable.Add(leftSide);
                            indexOfLeftSide = Transitions.Count - 1;
                            Transitions.Add(new Tuple<List<char>, List<int>, List<int>>
                                (new List<char>(), new List<int>(), new List<int>()));
                            Transitions[indexOfLeftSide].Item1.Add(transition.Item2[i]);
                            Transitions[indexOfLeftSide].Item2.Add(-1);
                            Transitions[indexOfLeftSide].Item3.Add(-1);
                        }
                        if (source == npda.InitialState &&
                            transition.Item3[i] == npda.StackInitialSymbol &&
                            transition.Item1[i] == npda.FinalStates[0]) //We should only have one final state
                            InitialState = indexOfLeftSide;
                    }
                    else
                    {
                        for (int l = 0; l < npda.StateCount; l++)
                        {
                            for (int k = 0; k < npda.StateCount; k++)
                            {
                                leftSide = string.Format("(q{0}{1}q{2})", source, transition.Item3[i], k);
                                rightSide1 = string.Format("(q{0}{1}q{2})", transition.Item1[i], transition.Item4[i][0], l);
                                rightSide2 = string.Format("(q{0}{1}q{2})", l, transition.Item4[i][1], k);

                                indexOfRightSide1 = NumberToVariable.IndexOf(rightSide1);
                                if (indexOfRightSide1 == -1)
                                {
                                    indexOfRightSide1 = NumberToVariable.Count;
                                    NumberToVariable.Add(rightSide1);
                                    Transitions.Add(new Tuple<List<char>, List<int>, List<int>>
                                        (new List<char>(), new List<int>(), new List<int>()));
                                }
                                if (source == npda.InitialState &&
                                    transition.Item3[i] == npda.StackInitialSymbol &&
                                    k == npda.FinalStates[0]) //We should only have one final state
                                    InitialState = indexOfRightSide1;

                                indexOfRightSide2 = NumberToVariable.IndexOf(rightSide2);
                                if (indexOfRightSide2 == -1)
                                {
                                    indexOfRightSide2 = NumberToVariable.Count;
                                    NumberToVariable.Add(rightSide2);
                                    Transitions.Add(new Tuple<List<char>, List<int>, List<int>>
                                        (new List<char>(), new List<int>(), new List<int>()));
                                }
                                if (transition.Item1[i] == npda.InitialState &&
                                    transition.Item4[i][0] == npda.StackInitialSymbol &&
                                    l == npda.FinalStates[0]) //We should only have one final state
                                    InitialState = indexOfRightSide2;

                                indexOfLeftSide = NumberToVariable.IndexOf(leftSide);
                                if (indexOfLeftSide != -1)
                                {
                                    Transitions[indexOfLeftSide].Item1.Add(transition.Item2[i]);
                                    Transitions[indexOfLeftSide].Item2.Add(indexOfRightSide1);
                                    Transitions[indexOfLeftSide].Item3.Add(indexOfRightSide2);
                                }
                                else
                                {
                                    NumberToVariable.Add(leftSide);
                                    Transitions.Add(new Tuple<List<char>, List<int>, List<int>>
                                        (new List<char>(), new List<int>(), new List<int>()));
                                    Transitions[Transitions.Count - 1].Item1.Add(transition.Item2[i]);
                                    Transitions[Transitions.Count - 1].Item2.Add(indexOfRightSide1);
                                    Transitions[Transitions.Count - 1].Item3.Add(indexOfRightSide2);
                                }
                                if (l == npda.InitialState &&
                                    transition.Item4[i][1] == npda.StackInitialSymbol &&
                                    k == npda.FinalStates[0]) //We should only have one final state
                                    InitialState = indexOfLeftSide;
                            }
                        }
                    }
                }
            }
        }

        public void ToTextFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            List<char> transition;
            List<int> firstKind;
            for (int i = 0; i < NumberToVariable.Count; i++)
            {
                if (Transitions[i].Item1.Count == 0)
                    continue;
                transition = new List<char>();
                firstKind = new List<int>();
                transition.AddRange(NumberToVariable[i]);
                transition.AddRange("->");
                for (int j = 0; j < Transitions[i].Item1.Count; j++)
                {
                    if (Transitions[i].Item2[j] == -1)
                    {
                        firstKind.Add(j);
                        continue;
                    }
                    transition.Add(Transitions[i].Item1[j]);
                    transition.AddRange(NumberToVariable[Transitions[i].Item2[j]]);
                    transition.AddRange(NumberToVariable[Transitions[i].Item3[j]]);
                    transition.Add('|');
                }
                for (int j = 0; j < firstKind.Count; j++)
                {
                    transition.Add(Transitions[i].Item1[firstKind[j]]);
                    transition.Add('|');
                }
                transition.RemoveAt(transition.Count - 1);
                writer.WriteLine(string.Concat(transition));
            }
            writer.Close();
        }
    }
}
