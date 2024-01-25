using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AutoSavedSlider : MonoBehaviour
{
    [SerializeField] string playerPrefsKey;
    [SerializeField] float defaultValue = 0.5f;

    //Component Cache
    Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.onValueChanged.AddListener(OnValueChanged);
        slider.value = PlayerPrefs.GetFloat(playerPrefsKey, defaultValue);
    }

    public void Start()
    {
        InternalValueChange(slider.value);

    }

    void OnValueChanged(float newValue)
    {
        PlayerPrefs.SetFloat(playerPrefsKey, newValue);
        PlayerPrefs.Save();
        InternalValueChange(newValue);
    }

    protected virtual void InternalValueChange(float newValue)
    {
        Debug.Log("Holi");
    }
}
