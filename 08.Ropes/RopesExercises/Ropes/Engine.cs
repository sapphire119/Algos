namespace Ropes
{
    using System.Linq;

    internal class Engine
    {
        private TextEditor textEditor;

        public Engine(TextEditor textEditor)
        {
            this.textEditor = textEditor;
        }

        public void Run(string input)
        {
            var tokens = input.Trim().Split();
            var genericCommand = tokens[0];

            switch (genericCommand)
            {
                case "login": this.textEditor.Login(tokens[1]); break;
                case "logout": this.textEditor.Logout(tokens[1]); break;
                case "users": this.textEditor.Users(tokens[1]); break;
                default:
                    break;
            }

            var userName = tokens[0];
            var userCommand = tokens[1];
            var userTokens = tokens.Skip(2).ToArray();

            switch (userCommand)
            {
                case "insert":
                    {
                        this.textEditor.Insert(userName, int.Parse(userTokens[0]), userTokens[1]);
                    }
                    break;
                case "prepend":
                    {
                        this.textEditor.Prepend(userName, userTokens[0]);
                    }
                    break;
                case "substring": this.textEditor.Substring(userName, int.Parse(userTokens[0]), int.Parse(userTokens[1])); break;
                case "delete": this.textEditor.Delete(userName, int.Parse(userTokens[0]), int.Parse(userTokens[1])); break;
                case "clear": this.textEditor.Clear(userName); break;
                case "length": this.textEditor.Length(userName); break;
                case "print": this.textEditor.Print(userName); break;
                case "undo": this.textEditor.Undo(userName); break;
                default:
                    break;
            }

            //var tokens = ;
        }
    }
}