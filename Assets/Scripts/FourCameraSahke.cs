using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FourCameraSahke : MonoBehaviour
{

    public float shakeDuration = 0.3f;
    public float shakeStrength = 0.7f;

    private Vector3 originalPosition;
    private bool isShaking = false;

    public void ShakeCamera()
    {
        if (!isShaking)
        {
            isShaking = true;

            originalPosition = transform.position;

            transform.DOShakePosition(shakeDuration, shakeStrength).OnComplete(() =>
            {
                // Reset the camera position after shaking is complete
                transform.position = originalPosition;
                isShaking = false;
            });
        }
    }

}
