using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class DimmerManager : MonoBehaviour
{
    private const string GLOBAL_DIMMER_TEXT = "Global Dimmer";

    [SerializeField]
    private TextMeshProUGUI globalDimmerText;

    [SerializeField]
    private Slider globalDimmerSlider;

    void Start()
    {
        globalDimmerSlider.value = 0;
        globalDimmerText.text = $"{GLOBAL_DIMMER_TEXT} {0.00}";
        SetGlobalDimmer(0);
        globalDimmerSlider.onValueChanged.AddListener((newValue) =>
        {
            SetGlobalDimmer(newValue);
            globalDimmerText.text = $"{GLOBAL_DIMMER_TEXT} {newValue:0.00}";
            Logger.Instance.LogInfo($"{GLOBAL_DIMMER_TEXT} {newValue:0.00}");
        });
    }

    void SetGlobalDimmer(float newValue) => MLGlobalDimmer.SetValue(newValue);
}
