namespace Ropes
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        public static void Main()
        {
            var tset = new BigList<string>();
            tset.Add("asdas");
            tset.Add("123");
            tset.Add("ffff");
            tset.Add("ggg");
            tset.Add("ddddd");
            tset.Add("eeeeeeee");
            ;
            //var test = new Dictionary<string, string>();
            //test["asd"] = "dsa";
            //test["asd3"] = "dsa4";
            //test["asd4"] = "dsa2";
            //test["asd5"] = "dsa3";
            //test["asd2"] = "dsa5";
            //test["asd1"] = "dsa6";
            //test["asd77"] = "dssd1a";
            //test["asd6"] = "dsad23";

            //var keys = test.Keys;
            

            var textEditor = new TextEditor();
            var engine = new Engine(textEditor);
            string input;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                engine.Run(input);
            }
        }
    }
}
