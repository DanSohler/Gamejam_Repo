using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public Animator fade;

    public void Loadlevel()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
