using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ThreeUiManager : MonoBehaviour
{

    public static ThreeUiManager Instance;

    [SerializeField] private Image failImage;

    [SerializeField] private float failImageDuration;

    private void Awake()
    {

        Instance = this;

    }

    public void OpenFailmage()

    {

        failImage.DOFade(1, failImageDuration).OnComplete((() => failImage.DOFade(0, failImageDuration)));

    }

}
