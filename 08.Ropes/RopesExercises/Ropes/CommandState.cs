namespace Ropes
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class CommandState
    {
        public CommandState() { }

        public CommandState(string commandName, string stringState)
            : this()
        {
            this.CommandName = commandName;
            this.StringState = stringState;
        }

        public string CommandName { get; set; }

        public string StringState { get; set; }
    }
}
