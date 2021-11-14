using System;
using System.Text.RegularExpressions;
using Start_Screen;
using TMPro;
using UnityEngine;

public class InputParsing : MonoBehaviour
{
    // Private Variables
    private State _state;

    // Public Variables
    public TextAsset saltMap;
    public TMP_InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        _state = new ChoosingOrigin(this);
        var submit = new TMP_InputField.SubmitEvent();
        submit.AddListener(Submit);
        inputField.onEndEdit = submit;
        inputField.ActivateInputField();
    }
    
    private void Submit(string str)
    {
        if(Regex.IsMatch(str, "[Qq]uit")) Application.Quit();
        _state = _state.Parse(str);
        inputField.SetTextWithoutNotify("");
        inputField.ActivateInputField();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
