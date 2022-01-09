using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    public GameObject restartBtn;

    [SerializeField]
    public Animator animator;
    // Start is called before the first frame update
    public void SetUp()
    {
        FindObjectOfType<FadingPanel>().FadeIn(1f);
        StartCoroutine(PopUp());
    }

    public void Restart()
    {
        StartCoroutine(PopOut());
        FindObjectOfType<FadingPanel>().FadeOut(1f);
        StartCoroutine(RestartAnim());
    }

    IEnumerator PopUp()
    {
        float t = 0.0f;
        
        Vector3 destination = new Vector3(200f, 200f, 200f);

        while (t < 1)
        {
            t += Time.deltaTime / 1f;

            restartBtn.transform.localScale = Vector3.Lerp(restartBtn.transform.localScale, destination, t);
            yield return null;
        }
    }

    IEnumerator PopOut()
    {
        float t = 0.0f;
        
        Vector3 destination = new Vector3(0f, 0f, 0f);

        while (t < 1)
        {
            t += Time.deltaTime / 1f;

            restartBtn.transform.localScale = Vector3.Lerp(restartBtn.transform.localScale, destination, t);
            yield return null;
        }
    }

    IEnumerator RestartAnim()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        FindObjectOfType<MainPanelScript>().NewGame();
        animator.SetTrigger("FadeIn");
    }
}
