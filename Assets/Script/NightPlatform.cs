using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NightPlatform : MonoBehaviour
{ 
    Material m_nightPlatform;
    Collider m_collider;
    Color originalColor;
    Color transparentColor;

    private void Awake()
    {
        m_nightPlatform = GetComponent<Renderer>().sharedMaterial;
        m_collider = GetComponent<Collider>();

        originalColor = m_nightPlatform.GetColor("_Color");
        originalColor.a = 1f;

        transparentColor = originalColor;
        transparentColor.a = 0f;

        Tween fadeIn = m_nightPlatform.DOColor(transparentColor, "_Color", 0.5f);
    }

    public void SetDay()
    {
        m_collider.enabled = false; 
        Tween fadeIn = m_nightPlatform.DOColor(transparentColor, "_Color", 0.5f);
    }

    public void SetNight()
    {
        if(m_collider != null)
        {
            m_collider.enabled = true;
            Tween fadeIn = m_nightPlatform.DOColor(originalColor, "_Color", 0.5f);
        }
    }
}
