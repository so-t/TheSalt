using System;
using Start_Screen;
using System.Text.RegularExpressions;
using static GlobalVariables;

public class ConfirmingOrigin : State
{
    // Private variables
    private InputParsing inputParser;
        
    // Public variables
    public ConfirmingOrigin(InputParsing ip)
    {
        inputParser = ip;
    }
    
    public override State Parse(string str)
    {
        
        if (Regex.IsMatch(str, "^[Yy]e?s?"))
        {
            DoSetDisplayAlignmentTop = true;
            GameLog = inputParser.saltMap.text;
            return new ChoosingLocation(inputParser);
        }

        if (Regex.IsMatch(str, "^[Nn]o?"))
        {
            GameLog = "<align=left><size=14>" +
                      "\n\n   1. The Olondian Empire       2. The Marches of Ela          3. The Diarchy of Umbasa"+
                      "\n\n   4. The Federation of Ore     5. Elhari                      6. Khazian Republic" +
                      "\n\n   7. Dulumia                   8. The Heptarchy of Delren     9. Caelesti" +
                      "\n\n           " +
                      "\n\n\n\n\n\n<align=center><size=16><b>WHAT LANDS DO YOU HAIL FROM?</b></align></size>";
            return new ChoosingOrigin(inputParser);
        }
        
        return this;
    }
}