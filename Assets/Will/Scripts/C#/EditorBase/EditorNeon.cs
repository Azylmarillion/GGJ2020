using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
#pragma warning disable 0649
public class EditorNeon : MonoBehaviour
{
    #region F/P
    [SerializeField, Space]
    Image image = null;

    [SerializeField, Space]
    bool enableGlow = true;

    [SerializeField, Space]
    Color firstColor = Color.white;

    [SerializeField, Range(0, 3), Space]
    float firstGlowIntensity = 1.0f;

    [SerializeField, Space]
    bool enablePulseFirstGlow = false;

    [SerializeField, Range(0, 3), Space]
    float maxPulseIntensityFirstGlow;

    [SerializeField, Space]
    Color secondColor = Color.white;

    [SerializeField, Range(0, 3), Space]
    float secondGlowIntensity = 1.0f;

    [SerializeField, Space]
    bool enablePulseSecondGlow = false;
    
    [SerializeField, Range(0, 3), Space]
    float maxPulseIntensitySecondGlow;

    [SerializeField, Range(0, 1), Space]
    float speedPulse = .5f;

    [SerializeField, Range(0, 1), Space]
    float colorBlend = 0f;    
    
    Material newMat, oldMat;
    #endregion

    #region Meths
    #region MyRegion
    void DisableGlow()
    {
        newMat.SetFloat("_AlphaIntensity_Fade_1", 0f);
        newMat.SetFloat("_AlphaIntensity_Fade_2", 0f);
    }

    void EnableGlow()
    {
        newMat.SetColor("_TintRGBA_Color_1", firstColor);
        newMat.SetColor("_TintRGBA_Color_2", secondColor);
        newMat.SetFloat("_AlphaIntensity_Fade_1", firstGlowIntensity);
        newMat.SetFloat("_AlphaIntensity_Fade_2", secondGlowIntensity);
        newMat.SetFloat("_OperationBlend_Fade_1", colorBlend);
    }

    void MakeItPulse()
    {
        if (enablePulseFirstGlow)
        {
            firstGlowIntensity = Mathf.PingPong(Time.time * speedPulse, maxPulseIntensityFirstGlow);

        }
        if (enablePulseSecondGlow)
        {
            secondGlowIntensity = Mathf.PingPong(Time.time * speedPulse, maxPulseIntensitySecondGlow);
        }
    }
    #endregion
    #region UnityMeths
    void OnEnable()
    {
        image = GetComponent<Image>();
        oldMat = image.material;
        newMat = new Material(image.material);
        image.material = newMat;
    }

    void OnDisable()
    {
        DisableGlow();
    }

    void Update()
    {
        if (enabled)
        {
            if (!enableGlow) DisableGlow();
            if (enableGlow) EnableGlow();
        }
        if (enablePulseFirstGlow || enablePulseSecondGlow)
            MakeItPulse();
    }
    #endregion
    #endregion
}