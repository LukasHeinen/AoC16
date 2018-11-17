using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day11.data
{
    public class State
    {
        public int ElevatorPosition { get; set; }
        public List<Floor> Floors { get; set; }

        private readonly Dictionary<string, int> Positions;

        public State()
        {
            Floors = new List<Floor>();
            Positions = new Dictionary<string, int>();
        }

        public State(string[] floors, int pos = 0)
        {
            Positions = new Dictionary<string, int>();
            Floors = new List<Floor>();
            foreach (var floor in floors)
            {
                Floors.Add(new Floor(floor.Split(",")));
            }

            ElevatorPosition = pos;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(ElevatorPosition);
            for (var i = 0; i < Floors.Count; i++)
            {
                builder.Append(i + " ");
                builder.Append(Floors[i].ToString());
            }
            return builder.ToString();
        }

        public string GeneratePattern()
        {
            for (var i =0;i<Floors.Count;i++)
            {
                var items = Floors[i].GetAll();
                foreach (var item in items)
                {
                    Positions.Add(item,i);
                }
            }
            var chipProperties = new List<Tuple<int, int>>();
            foreach (var keyValuePair in Positions.Where(k => k.Key.Contains('M')))
            {
                Positions.TryGetValue((keyValuePair.Key[0] + "G"), out var posGen);
                chipProperties.Add(new Tuple<int, int>(keyValuePair.Value,posGen));
            }

            var ordered = chipProperties.OrderBy(t => t.Item1).ThenBy(i => i.Item2);
            var builder = new StringBuilder();
            builder.Append(ElevatorPosition);
            foreach (var tuple in ordered)
            {
                builder.Append(tuple.Item1 + "," + tuple.Item2);
            }
            return builder.ToString();
        }

        public State ExecuteTransaction(Transaction action)
        {
            var elevatorPos = ElevatorPosition + action.Direction;
            var floors = new List<Floor>();
            foreach (var o in action.Objects)
            {
                Ignoration.ToIgnore.Add(o);
            }
            floors.AddRange(Floors.Select(f => f.Clone()));
            foreach (var o in action.Objects)
            {
                floors[elevatorPos].Add(o);
            }
            Ignoration.ToIgnore.Clear();
            
            if (floors[elevatorPos].IsValid())
            {
                var resultingState = new State() {ElevatorPosition = elevatorPos, Floors = floors};
                return resultingState;
            }

            return null;
        }

        public int GetEmptiness()
        {
            var count = 0;
            for (var i = 0; i < Floors.Count; i++)
            {
                if (Floors[i].IsEmpty())
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
