using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class MainDisplay : MonoBehaviour
{
    // Private Variables
    private List<string> EventLog = new List<string>();

    private void AddEvent(string eventString){
        if (DoUpdateLogDisplay)
        {
            EventLog.Clear();
            DoUpdateLogDisplay = false;
        }
        EventLog.Add(eventString);
        
        log.text = string.Empty;

        foreach (string logEvent in EventLog) {
            log.text += logEvent;
            log.text += "\n";
        }
        
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
    
    // Public Variables
    public TMP_Text log;
    public ScrollRect scrollRect;
    

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (GameLog == "") return;
        AddEvent(GameLog);
        GameLog = "";


    }
}
