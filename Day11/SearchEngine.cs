using System;
using System.Collections.Generic;
using System.Text;
using Day11.data;

namespace Day11
{
    public class SearchEngine
    {
        private int _currentDepth = 0;
        private List<State> _currentStates;
        public readonly HashSet<string> _allFoundStates;

        public SearchEngine(State initialState)
        {
            _currentStates = new List<State>();
            _allFoundStates = new HashSet<string>();

            _currentStates.Add(initialState);
            _allFoundStates.Add(initialState.GeneratePattern());
        }

        public int Run(State desiredState)
        {
            var desired = desiredState.GeneratePattern();
            var watchGlobal = System.Diagnostics.Stopwatch.StartNew();
            while (true)
            {
                
                if (!_allFoundStates.Contains(desired) && _currentStates.Count != 0)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    Iterate();
                    watch.Stop();
                    Console.WriteLine($"Depth: {_currentDepth}, number of states: {_currentStates.Count}, \t\t Took: {watch.ElapsedMilliseconds}");
                }
                else
                {
                    break;
                }
            }
            watchGlobal.Stop();
            Console.WriteLine($"Took: {watchGlobal.ElapsedMilliseconds}");
            return _currentDepth;
        }

        public void Iterate()
        {
            var nextStates = new List<State>();
            foreach (var s in _currentStates)
            {
                var transactions = TransactionGenerator.GetAllValidTransactions(s);
                foreach (var t in transactions)
                {
                    var newState = s.ExecuteTransaction(t);
                    if (newState != null)
                    {
                        var pattern = newState.GeneratePattern();
                        if (!_allFoundStates.Contains(pattern))
                        {
                            _allFoundStates.Add(pattern);
                            nextStates.Add(newState);
                        }
                    }
                }
            }
            _currentStates.Clear();
            _currentStates = nextStates;
            _currentDepth++;
        }
    }
}