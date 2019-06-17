using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CFG_with_NPDA_input
{
    class CFG
    {
        public Tuple<List<long>, List<char>, List<string>, List<string>>[] Transitions { get; }
        public long StateCount { get; }
        public List<char> Alphabet { get; }
        private Stack<char> Stack { get; }
        public List<char> StackAlphabet { get; }
        public char StackInitialSymbol { get; }
        public long InitialState { get; private set; }
        bool InitialStateSet { get; }
        public List<long> FinalStates { get; }
        static readonly Exception InputIncorrectException = new Exception("Input Was Not In Correct Format!");

        public CFG(string CFGPath)
        {
            StreamReader reader = new StreamReader(CFGPath);
            InitialStateSet = false;
            Alphabet = new List<char>();
            StackAlphabet = new List<char>();
            try
            {
                StateCount = long.Parse(reader.ReadLine());
                foreach (var alphabet in reader.ReadLine().Split(','))
                    Alphabet.Add(alphabet[0]);
                foreach (var stackAlphabet in reader.ReadLine().Split(','))
                    StackAlphabet.Add(stackAlphabet[0]);
                StackInitialSymbol = reader.ReadLine()[0];

            }
            catch
            {
                throw InputIncorrectException;
            }
            Transitions = new Tuple<List<long>, List<char>, List<string>, List<string>>[StateCount];
            for (int i = 0; i < StateCount; i++)
                Transitions[i] = new Tuple<List<long>, List<char>, List<string>, List<string>>
                    (new List<long>(), new List<char>(), new List<string>(), new List<string>());
            FinalStates = new List<long>();
            string[] lines = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
                ParsLine(line);
            reader.Close();
        }

        private void ParsLine(string line)
        {
            string[] transition = line.Split(',');
            long source;
            long destination;

            //Recognize initial and final states and set source and destination.
            if (transition[0][0] == '*')
            {
                source = long.Parse(transition[0].Substring(2));
                if (source >= StateCount)
                    throw InputIncorrectException;

                if (!FinalStates.Contains(source))
                    FinalStates.Add(source);
            }
            else if (transition[0][0] == '-' && transition[0][1] == '>')
            {
                source = long.Parse(transition[0].Substring(3));
                if (!InitialStateSet)
                    InitialState = source;
                else if (InitialState != source || source >= StateCount)
                    throw InputIncorrectException;
            }
            else
                source = long.Parse(transition[0].Substring(1));

            if (transition[4][0] == '*')
            {
                destination = long.Parse(transition[4].Substring(2));
                if (destination >= StateCount)
                    throw InputIncorrectException;

                if (!FinalStates.Contains(destination))
                    FinalStates.Add(destination);
            }
            else if (transition[4][0] == '-' && transition[4][1] == '>')
            {
                destination = long.Parse(transition[4].Substring(3));
                if (!InitialStateSet)
                    InitialState = destination;
                else if (InitialState != destination || destination >= StateCount)
                    throw InputIncorrectException;
            }
            else
                destination = long.Parse(transition[4].Substring(1));

            //Check for transition alphabet correctness
            if (transition[1] != "_" && !Alphabet.Contains(transition[1][0]))
                throw InputIncorrectException;

            //Add transition
            Transitions[source].Item1.Add(destination);
            Transitions[source].Item2.Add(transition[1][0]);

            //Check for stack alphabet correctness
            foreach (char chr in transition[2])  //pop element
            {
                if (chr != '_' && chr != StackInitialSymbol && !StackAlphabet.Contains(chr))
                    throw InputIncorrectException;
            }
            foreach (char chr in transition[3]) //push element
            {
                if (chr != '_' && chr != StackInitialSymbol && !StackAlphabet.Contains(chr))
                    throw InputIncorrectException;
            }

            //Add pop and push elements
            Transitions[source].Item3.Add(transition[2]);
            Transitions[source].Item4.Add(transition[3]);
        }
    }
}
