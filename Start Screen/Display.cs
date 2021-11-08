using System;
using TMPro;
using UnityEngine;
using static GlobalVariables;
[CLSCompliant(false)]

public class Display : MonoBehaviour
{
    // Private variables
    
    // Public variables
    public TMP_Text tmpText;
    
    // Start is called before the first frame update
    void Start()
    {
        tmpText.alignment = TextAlignmentOptions.Midline;
        GameLog = "<align=left><size=14>" +
                  "\n\n   1. The Olondian Empire       2. The Marches of Ela          3. The Diarchy of Umbasa"+
                  "\n\n   4. The Federation of Ore     5. Elhari                      6. Khazian Republic" +
                  "\n\n   7. Dulumia                   8. The Heptarchy of Delren     9. Caelesti" +
                  "\n\n           " +
                  "\n\n\n\n\n\n<align=center><size=16><b>WHAT LANDS DO YOU HAIL FROM?</b></align></size>";
    }

    // Update is called once per frame
    void Update()
    {
        if (DoSetDisplayAlignmentMiddle)
        {
            tmpText.alignment = TextAlignmentOptions.Midline;
            DoSetDisplayAlignmentMiddle = false;
        }

        if (DoSetDisplayAlignmentTop)
        {
            tmpText.alignment = TextAlignmentOptions.TopLeft;
            DoSetDisplayAlignmentTop = false;
        }
        if (GameLog == "") return;
        tmpText.text = GameLog;
        GameLog = "";

    }
}
