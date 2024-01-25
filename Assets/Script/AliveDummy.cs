using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AliveDummy : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] bool rotateClockwise = true;
    [SerializeField] Ease ease = Ease.Linear;
    private void Start()
    {
        transform.DORotate(Vector3.forward * 
            360f * 
            (rotateClockwise ? 1f : -1f), 
            
      duration, 
            RotateMode.FastBeyond360).
        SetEase(ease).
        SetLoops(-1);


    }
}
