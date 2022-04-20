using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Animator fade;

    public void Loadlevel()
    {
        StartCoroutine(FadeOut());
    }

    public void Start()
    {
        fade.SetBool("GameOver", true);
    }

    IEnumerator FadeOut()
    {
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
