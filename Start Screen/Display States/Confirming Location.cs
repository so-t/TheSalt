using System;
using System.Text.RegularExpressions;
using Markov;
using Start_Screen;
using UnityEngine.SceneManagement;
using static GlobalVariables;

public class ConfirmingLocation : State
{
    // Private variables
    private InputParsing inputParser;
        
    // Public variables
    public ConfirmingLocation(InputParsing ip)
    {
        inputParser = ip;
    }

    public override State Parse(string str)
    {
        if (Regex.IsMatch(str, "^[Yy]e?s?"))
        {
            //     var chain = new MarkovChain<string>(1);
            //     
            //     chain.Add(new [] { "You", "have", "received", "a", "map", "from", "an", "aged","wizard."});
            //     chain.Add(new [] { "You", "have", "recovered", "some", "information", "from", "a", "wizened","fungus."});
            //     chain.Add(new [] { "A", "giant", "spoke", "to", "you", "in", "a", "dream","and","told","you","your","destiny","would","lead","you","to","the","salt"});
            //     chain.Add(new [] { "A", "builtin", "was", "posted", "requesting", "help", "from", "a","capable","adventurer."});
            //     chain.Add(new [] { "The", "winds", "of", "chance", "have", "lead", "you", "here."});
            //     chain.Add(new [] { "You", "have", "received", "a", "summons", "from", "a", "young","lord","who","requests","your","presence","posthaste."});
            //     chain.Add(new [] { "You", "were", "on", "holiday", "and", "one", "day", "you", "awoke", "here."});
            //
            //     GameLog = "<size=16>" + string.Join(" ", chain.Chain(Rand)) + "</size>";

            SceneManager.LoadScene("Scenes/Main Game Screen");
            return this;
        }

        if (Regex.IsMatch(str, "^[Nn]o?"))
        {
            DoSetDisplayAlignmentTop = true;
            GameLog = inputParser.saltMap.text;
            return new ChoosingLocation(inputParser);
        }
        
        return this;
    }
}