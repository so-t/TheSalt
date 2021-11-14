using System;
using Start_Screen;
using static GlobalVariables;
[CLSCompliant(false)]

public class ChoosingLocation : State{

    // Private variables
    private InputParsing inputParser;
        
    // Public variables
    public ChoosingLocation(InputParsing ip)
    {
        inputParser = ip;
    }
    
    public override State Parse(string str)
    {

        switch (str)
        { 
            case "1":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b>The Algal Forest</b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b></size></align>";
                return new ConfirmingLocation(inputParser);
            case "2":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b>The Chromatic Desert</b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b></size></align>";
                return new ConfirmingLocation(inputParser);
            case "3":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b>The Coral Steppes</b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b> </size></align>";
                return new ConfirmingLocation(inputParser);
            case "4":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b>The Salt Sea</b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b></size></align>";
                return new ConfirmingLocation(inputParser);
            case "5":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b><Area still needs a name></b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b></size></align>";
                return new ConfirmingLocation(inputParser);
            case "6":
                DoSetDisplayAlignmentMiddle = true;
                GameLog = "<align=center><size=16><b><Area still needs a name></b>" +
                          "\n\n\n\n\n\n<b>ARE YOU SURE?</b></size></align>";
                return new ConfirmingLocation(inputParser);
            default:
                return this;
            
        }
                
    }
}