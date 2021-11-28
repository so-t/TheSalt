using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class MainDisplay : MonoBehaviour
{
    // Private Variables
    private readonly List<string> _eventLog = new List<string>();

    private void AddEvent(string eventString){
        if (DoUpdateLogDisplay)
        {
            _eventLog.Clear();
            DoUpdateLogDisplay = false;
        }
        _eventLog.Add(eventString);
        
        log.text = string.Empty;

        foreach (string logEvent in _eventLog) {
            log.text += logEvent;
            log.text += "\n";
        }
        
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
    
    // Public Variables
    public TMP_Text log;
    public ScrollRect scrollRect;
    
    void Update()
    {
        if (GameLog == "") return;
        AddEvent(GameLog);
        GameLog = "";


    }
}
