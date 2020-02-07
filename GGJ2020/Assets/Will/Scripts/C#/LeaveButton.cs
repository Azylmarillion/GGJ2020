using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeaveButton : MonoBehaviour
{
    #region F/P
    [SerializeField]
        float deltaPulse = 0f;

    private Image LeaveImg;
    #endregion

    #region Meths
    #region MyMeths
    void LeaveGame()
    {
        Application.Quit();        
    }

    IEnumerator Pulse()
    {
        float pulse = 1;
        while (true)
        {
            LeaveImg.color = new Color(1, 1, 1, pulse);
            if (pulse > 1)
                deltaPulse *= -1;
            if (pulse < 0.7)
                deltaPulse *= -1;
            pulse += deltaPulse;
            yield return null;
        }
    }
    #endregion
    #region UnityMeths
    public void OnClick()
    {
        LeaveGame();
    }

    private void Start()
    {
        LeaveImg = GetComponent<Image>();
        StartCoroutine(Pulse());
    }
    #endregion
    #endregion
}
