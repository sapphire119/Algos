namespace Ropes
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class TextEditor : ITextEditor
    {
        //This trie is for all users
        private Trie<bool> trie;

        //Current Users with their respecitve strings
        private Dictionary<string, BigList<char>> usersStrings;

        //Users, with last command executed which contains commandName & stringState
        private Dictionary<string, Queue<CommandState>> usersCommandStates;


        public TextEditor()
        {
            this.trie = new Trie<bool>();
            this.usersStrings = new Dictionary<string, BigList<char>>();
            this.usersCommandStates = new Dictionary<string, Queue<CommandState>>();
        }

        public void Login(string username)
        {
            this.trie.Insert(username, true);
            this.usersStrings[username] = new BigList<char>("".ToCharArray());
            this.usersCommandStates[username] = new Queue<CommandState>();
            this.usersCommandStates[username].Enqueue(new CommandState
            {
                CommandName = "initial",
                StringState = string.Empty
            });
        }

        public void Logout(string username)
        {
            this.usersCommandStates.Remove(username);
            this.usersStrings.Remove(username);
            //throw new System.NotImplementedException();
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            if (prefix == string.Empty)
            {
                //Dictionary<string, Queue<CommandState>>.KeyCollection test = this.userCommandStringState.Keys;
                return this.usersStrings.Keys;
            }
            else
            {
                return this.trie.GetByPrefix(prefix);
            }
        }

        public void Insert(string username, int index, string str)
        {
            if (!IsUserLoggedIn(username)) return;


            //var bigList = new BigList<string>();
            //bigList.Insert(index, str);
            //this.userCommandStringState[username].Enqueue(new CommandState
            //{
            //    CommandName = nameof(this.Insert).ToLower(),
            //    StringState =
            //});
            //throw new System.NotImplementedException();
        }

        public void Prepend(string username, string str)
        {
            if (!IsUserLoggedIn(username)) return;


        }

        public void Undo(string username)
        {
            if (!IsUserLoggedIn(username)) return;
            throw new System.NotImplementedException();
        }


        public void Clear(string username)
        {
            if (!IsUserLoggedIn(username)) return;
            throw new System.NotImplementedException();
        }

        public void Delete(string username, int startIndex, int length)
        {
            if (!IsUserLoggedIn(username)) return;
            throw new System.NotImplementedException();
        }

        public int Length(string username)
        {
            if (!IsUserLoggedIn(username)) return default;

            throw new System.NotImplementedException();
        }

        public string Print(string username)
        {
            if (!IsUserLoggedIn(username)) return default;

            throw new System.NotImplementedException();
        }

        public void Substring(string username, int startIndex, int length)
        {
            if (!IsUserLoggedIn(username)) return;

            throw new System.NotImplementedException();
        }


        private bool IsUserLoggedIn(string username)
        {
            if (this.usersStrings.ContainsKey(username) && this.usersCommandStates.ContainsKey(username))
            {
                return true;
            }

            return false;
        }
    }
}
