using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text timer;
    public GameObject victory;

    float currentTime;
    float startingTime = 10;
    bool timerbool;

    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
        timer.text = "01:00";
        currentTime = startingTime;
        timerbool = true;
    }


    void PreTimeCheck()
    {
        StartCoroutine(SetTimeCheck());
    }

    IEnumerator SetTimeCheck()
    {
        yield return new WaitForSeconds(1);
        timerbool = true;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timer.text = currentTime.ToString("0") + "s";

        if (timer.text == "5s" || timer.text == "4s" || timer.text == "3s" || timer.text == "2s" || timer.text == "1s")
        {
            if (timerbool)
            {
                timerbool = false;
                PreTimeCheck();
                FindObjectOfType<AudioManagerScript>().Play("Tick");
            }
        }


        if (currentTime <= 0)
        {
            currentTime = 0;
            victory.SetActive(true);
            BeatGame();
        }
    }

    void BeatGame()
    {
        StartCoroutine(WaitForEndGame());
    }

    IEnumerator WaitForEndGame()
    {
        FindObjectOfType<AudioManagerScript>().StopPlaying("OST");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }


}
