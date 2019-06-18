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
        public int StartVariable { get; }
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
                            indexOfLeftSide = Transitions.Count;
                            Transitions.Add(new Tuple<List<char>, List<int>, List<int>>
                                (new List<char>(), new List<int>(), new List<int>()));
                            Transitions[indexOfLeftSide].Item1.Add(transition.Item2[i]);
                            Transitions[indexOfLeftSide].Item2.Add(-1);
                            Transitions[indexOfLeftSide].Item3.Add(-1);
                        }
                        if (source == npda.InitialState &&
                            transition.Item3[i] == npda.StackInitialSymbol &&
                            transition.Item1[i] == npda.FinalStates[0]) //We should only have one final state
                            StartVariable = indexOfLeftSide;
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
                                    StartVariable = indexOfRightSide1;

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
                                    StartVariable = indexOfRightSide2;

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
                                    StartVariable = indexOfLeftSide;
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

        public string HasWord(string word)
        {
            List<List<char>> derivation = new List<List<char>>();
            bool hasDerivation = FindDerivation(word, 0, new List<int>() { StartVariable }, derivation);
            List<char> result = new List<char>();
            result.AddRange(hasDerivation.ToString());
            result.Add('\n');
            if (hasDerivation)
            {
                for (int i = derivation.Count - 1; i > 0; i--)
                {
                    result.AddRange(derivation[i]);
                    result.AddRange(" => ");
                }
                result.AddRange(derivation[0]);
            }
            return string.Concat(result);
        }

        private bool FindDerivation(string word, int currentIndex, List<int> variables, List<List<char>> derivation)
        {
            int variable;
            if (currentIndex == word.Length)
                if (variables.Count == 0)
                {
                    List<char> step = new List<char>();
                    step.AddRange(word);
                    derivation.Add(step);
                    return true;
                }
                else
                {
                    variable = variables[variables.Count - 1];
                    variables.RemoveAt(variables.Count - 1);
                    for (int i = 0; i < Transitions[variable].Item1.Count; i++)
                    {
                        if (Transitions[variable].Item1[i] != '_')
                            continue;

                        List<int> newVariables = new List<int>(variables.Count);
                        newVariables.AddRange(variables);
                        if (Transitions[variable].Item2[i] != -1)
                        {
                            newVariables.Add(Transitions[variable].Item3[i]);
                            newVariables.Add(Transitions[variable].Item2[i]);
                        }
                        if (FindDerivation(word, currentIndex, newVariables, derivation))
                        {
                            List<char> step = new List<char>();
                            step.AddRange(word);
                            step.AddRange(NumberToVariable[variable]);
                            for (int j = variables.Count - 1; j >= 0; j--)
                                step.AddRange(NumberToVariable[variables[j]]);
                            derivation.Add(step);
                            return true;
                        }
                    }
                    return false;
                }


            if (variables.Count == 0)
                return false;
            variable = variables[variables.Count - 1];
            variables.RemoveAt(variables.Count - 1);
            bool currentIndexAdded;
            for (int i = 0; i < Transitions[variable].Item1.Count; i++)
            {
                currentIndexAdded = false;
                if (Transitions[variable].Item1[i] == word[currentIndex])
                {
                    currentIndex++;
                    currentIndexAdded = true;
                }
                else if (Transitions[variable].Item1[i] != '_')
                    continue;

                List<int> newVariables = new List<int>(variables.Count);
                newVariables.AddRange(variables);
                if (Transitions[variable].Item2[i] != -1)
                {
                    newVariables.Add(Transitions[variable].Item3[i]);
                    newVariables.Add(Transitions[variable].Item2[i]);
                }
                if (FindDerivation(word, currentIndex, newVariables, derivation))
                {
                    List<char> step = new List<char>();
                    if (currentIndexAdded)
                        for (int j = 0; j < currentIndex - 1; j++)
                            step.Add(word[j]);
                    else
                        for (int j = 0; j < currentIndex - 1; j++)
                            step.Add(word[j]);

                    step.AddRange(NumberToVariable[variable]);
                    for (int j = variables.Count - 1; j >= 0; j--)
                        step.AddRange(NumberToVariable[variables[j]]);
                    derivation.Add(step);
                    return true;
                }
                else if (currentIndexAdded)
                    currentIndex--;

            }
            return false;
        }
    }
}
