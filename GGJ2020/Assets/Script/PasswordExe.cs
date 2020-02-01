using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

public class PasswordExe : MonoBehaviour
{
    [SerializeField] private PasswordCollection _passwords = null;
    [SerializeField] private FontsCollection _fonts = null;
    [SerializeField] private FontSizeCollection _fontSize = null;

    private TMP_InputField _inputField;
    private string _currentTyping;

    private void Start()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            text.font = _fonts.list[TimeShifter.era];
            text.fontSize = _fontSize.list[TimeShifter.era];
        }
        _inputField = GetComponentInChildren<TMP_InputField>();
    }

    public void OnEditPassword(string input)
    {        
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;

        if(_inputField.text != _passwords.list[TimeShifter.era])
        {
            Destroy(gameObject);
        }
        else
        { 
            FindObjectOfType<GameManager>().ChangeEra(TimeShifter.era - 1);
        }
    }
}
