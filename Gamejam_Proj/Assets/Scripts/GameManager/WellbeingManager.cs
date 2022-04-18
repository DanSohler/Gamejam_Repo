using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellbeingManager : MonoBehaviour
{
    //Slider
    public Slider social;
    public Slider physical;
    public Slider academic;
    public Slider money;

    //float values
    public float socialVal;
    public float physicalVal;
    public float academicVal;
    public float moneyVal;

    //timer value
    public float fallSpeed = 0.02f;

    public float socialAdd;
    public float physicalAdd;
    public float academicAdd;
    public float moneyAdd;

    // Update is called once per frame
    void Update()
    {
        TimerManager();
        SliderChange();

        if (Input.GetKeyDown(KeyCode.E))
        {
            SocialAdd();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PhysicalAdd();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AcademicAdd();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            MoneyAdd();
        }


    }

    //Value Bump
    void SocialAdd()
    {
        socialVal = socialVal + socialAdd;
        if (socialVal > 1)
        {
            socialVal = 1;
        }
    }
    
    void PhysicalAdd()
    {
        physicalVal = physicalVal + physicalAdd;
        if (physicalVal > 1)
        {
            physicalVal = 1;
        }
    }

    void AcademicAdd()
    {
        academicVal = academicVal + academicAdd;
        if (academicVal > 1)
        {
            academicVal = 1;
        }
    }

    void MoneyAdd()
    {
        moneyVal = moneyVal + moneyAdd;
        if (moneyVal > 1)
        {
            moneyVal = 1;
        }
    }


    void SliderChange()
    {
        social.value = socialVal;
        physical.value = physicalVal;
        academic.value = academicVal;
        money.value = moneyVal;
    }

    //Timer
    void TimerManager()
    {
        StartCoroutine(SocialDecrease());
        StartCoroutine(PhysicalDecrease());
        StartCoroutine(AcademicDecrease());
        StartCoroutine(MoneyDecrease());
    }

    IEnumerator SocialDecrease()
    {
        socialVal = (socialVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    IEnumerator PhysicalDecrease()
    {
        physicalVal = (physicalVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    IEnumerator AcademicDecrease()
    {
        academicVal = (academicVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    IEnumerator MoneyDecrease()
    {
        moneyVal = (moneyVal - fallSpeed * Time.deltaTime);
        yield return null;
    }
}
