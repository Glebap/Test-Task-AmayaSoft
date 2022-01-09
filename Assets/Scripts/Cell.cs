using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private bool isAnswer = false;

    public void MarkAsAnswer()
    {
        isAnswer = true;
    }

    public void CheckAnswer()
    {
        if (isAnswer)
        {
            GetComponent<Button>().enabled = false;
            StartCoroutine(CorrectAnswer());
        }
        else
        {
            transform.GetChild(0).DOShakePosition(1.2f, strength: new Vector3(8, 0, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        }
    }

    IEnumerator CorrectAnswer()
    {
        FindObjectOfType<ParticleController>().SpawnParticles(transform.position);
        transform.GetChild(0).DOPunchScale(new Vector3 (10, 10, 10), 1f, vibrato: 2);
        yield return new WaitForSeconds(1);
        FindObjectOfType<MainPanelScript>().NextLevel();
    }
}
