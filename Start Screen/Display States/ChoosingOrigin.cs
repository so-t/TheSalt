using System;
using Start_Screen;
using static GlobalVariables;
public class ChoosingOrigin : State
{
    // Private variables
    private InputParsing inputParser;
        
    // Public variables
    public ChoosingOrigin(InputParsing ip)
    {
        inputParser = ip;
    }

    public override State Parse(string str)
    {
        switch (str)
        {
            case "1":
                GameLog = "<align=center><size=16><b>The Olondian Empire</b>" +
                          "\n\nThe kingdoms of Olondi recently abandoned the chivalric custom, the dawn of a new era of reason for the people of the riverlands."+
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "2":
                GameLog = "<align=center><size=16><b>The Marches of Ela</b>" +
                          "\n\nSaid to be descended from a powerful and ancient lineage, the citizens of Ela hold great pride in their family names." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "3":
                GameLog = "<align=center><size=16><b>The Diarchy of Umbasa</b>" +
                          "\n\nA land that sees more rain than any other, their stone cities are built in the high peak, surrounded by tall trees with long weeping branches." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "4":
                GameLog = "<align=center><size=16><b>The Federation of Ore</b>" +
                          "\n\nThe great forests of Ore are without equal, as the Dwarves take great pride in their stewardship, their gift to the Maker." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "5":
                GameLog = "<align=center><size=16><b>Elhari</b>" +
                          "\n\nThe people of Elhari tamed the wyverns of the steppe, using them to construct kingdoms upon the mesas." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "6":
                GameLog = "<align=center><size=16><b>Khazian Republic</b>" +
                          "\n\nStruck by an object from space long ago, the newly formed lake turned the former desert region into a stunning moorland." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "7":
                GameLog = "<align=center><size=16><b>Dulumia</b>" +
                          "\n\nA coastal nation, the tall ivory towers of Dulimia, always filled with the light of magery, are a welcome sight after a long journey at sea." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "8":
                GameLog = "<align=center><size=16><b>The Heptarchy of Delren</b>" +
                          "\n\nThe seven territories of Delren are ruled by seven Lords. Usually opposed, they now stand together against the encroaching Elan Empire." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            case "9":
                GameLog = "<align=center><size=16><b>Caelesti</b>" +
                          "\n\nHome to the tallest mountain in the land, the sunsets here burn pink from the glow of the planet's rings." +
                          "\n\n\n\n\n\n<b>IS THIS YOUR HOMELAND?</b></size></align>";
                return new ConfirmingOrigin(inputParser);
            default:
                return this;
        }
    }
}