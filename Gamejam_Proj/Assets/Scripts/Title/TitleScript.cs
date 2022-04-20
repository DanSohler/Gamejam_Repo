using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public Animator fade;
    public AudioSource click;
    public void Loadlevel()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fade.SetTrigger("Fade");
        click.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
