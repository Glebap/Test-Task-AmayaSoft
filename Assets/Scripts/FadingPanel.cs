using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CanvasGroup canvasRestarGroup;

    private Tween fadeTween;

    public void FadeIn(float duration)
    {
        Fade(0.72f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        },  canvasGroup);
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        },  canvasGroup);
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd, CanvasGroup canvasGroup)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }
}