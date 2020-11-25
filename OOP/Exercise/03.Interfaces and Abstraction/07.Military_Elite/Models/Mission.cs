using System;

using _07.Military_Elite.Contracts;
using _07.Military_Elite.Enumerations;
using _07.Military_Elite.Exceptions;

namespace _07.Military_Elite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string stateArg)
        {
            CodeName = codeName;
            State = TryParseState(stateArg);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            State = State.Finished;
        }

        private State TryParseState(string stateArg)
        {
            State state;
            bool isParsed = Enum.TryParse<State>(stateArg, out state);

            if (!isParsed)
            {
                throw new InvalidStateException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
