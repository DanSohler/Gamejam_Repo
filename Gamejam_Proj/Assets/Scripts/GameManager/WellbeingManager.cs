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

    public float damageValue;

    public bool isDead;

    // Update is called once per frame
    void Update()
    {
        TimerManager();
        SliderChange();
        DeathCheck();

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

    void DeathCheck()
    {
        if (socialVal <= 0 || physicalVal <= 0 || academicVal <= 0|| moneyVal <= 0)
        {
            isDead = true;
        }
    }


    //Value Bump
    public void SocialAdd()
    {
        socialVal = socialVal + socialAdd;
        if (socialVal > 1)
        {
            socialVal = 1;
        }
    }
    
    public void PhysicalAdd()
    {
        physicalVal = physicalVal + physicalAdd;
        if (physicalVal > 1)
        {
            physicalVal = 1;
        }
    }

    public void AcademicAdd()
    {
        academicVal = academicVal + academicAdd;
        if (academicVal > 1)
        {
            academicVal = 1;
        }
    }

    public void MoneyAdd()
    {
        moneyVal = moneyVal + moneyAdd;
        if (moneyVal > 1)
        {
            moneyVal = 1;
        }
    }

    //Damage Voids
    //Hit means, it hurts everything but the labelled stat

    public void HitSocial()
    {
        physicalVal = physicalVal - damageValue;
        academicVal = academicVal - damageValue;
        moneyVal = moneyVal - damageValue;
    }

    public void HitPhysical()
    {
        socialVal = socialVal - damageValue;
        academicVal = academicVal - damageValue;
        moneyVal = moneyVal - damageValue;
    }

    public void HitAcademic()
    {
        socialVal = socialVal - damageValue;
        physicalVal = physicalVal - damageValue;
        moneyVal = moneyVal - damageValue;
    }   
    
    public void HitMoney()
    {
        socialVal = socialVal - damageValue;
        physicalVal = physicalVal - damageValue;
        academicVal = academicVal - damageValue;
    }

        //Functional Voids

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
