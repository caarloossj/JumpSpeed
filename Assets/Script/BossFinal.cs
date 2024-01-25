using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public static BossFinal instance;

    private Animator bossAnimator;

    private void Start()
    {
        bossAnimator = GetComponent<Animator>();
    }
    public void StartAnimationBoss()
    {
        bossAnimator.SetTrigger("Death");
    }

    public void Awake()
    {
        instance = this;
    }
}
