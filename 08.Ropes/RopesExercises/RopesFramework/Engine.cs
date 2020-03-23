namespace RopesFramework
{
    using System;
    using System.Linq;

    public class Engine
    {
        private ITextEditor userCommands;

        public Engine(ITextEditor userCommands)
        {
            this.userCommands = userCommands;
        }

        public void Run(string input)
        {
            var tokens = input.Split();
            var genericCommand = tokens[0];
            var args = tokens.Skip(1).ToArray();

            switch (genericCommand)
            {
                case "login": this.userCommands.Login(args[0]); return;
                case "logout": this.userCommands.Logout(args[0]); return;
                case "users":
                    {
                        var result = this.userCommands.Users(args[0]);
                        Console.WriteLine(string.Join("\n", result));
                    }
                    return;
                default:
                    break;
            }

            var userCommand = args[0];
            var userArgs = args.Skip(1).ToArray();
            var userName = genericCommand;

            switch (userCommand)
            {
                case "insert":
                    {
                        var index = int.Parse(userArgs[0]);
                        var str = userArgs[1];
                        this.userCommands.Insert(userName, index, str);
                    }
                    break;
                case "prepend":
                    {
                        this.userCommands.Prepend(userName, userArgs[0]);
                    }
                    break;
                case "substring":
                    {
                        var startIndex = int.Parse(userArgs[0]);
                        var length = int.Parse(userArgs[1]);
                        this.userCommands.Substring(userName, startIndex, length);
                    }
                    break;
                case "delete":
                    {
                        var startIndex = int.Parse(userArgs[0]);
                        var length = int.Parse(userArgs[1]);
                        this.userCommands.Delete(userName, startIndex, length);
                    }
                    break;
                case "clear": this.userCommands.Clear(userName); break;
                case "length": this.userCommands.Length(userName); break;
                case "print": this.userCommands.Print(userName); break;
                case "undo": this.userCommands.Undo(userName); break;
                default:
                    break;
            }
        }
    }
}
