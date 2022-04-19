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

    //Bools to stop decay
    public bool socialRegen = false;
    public bool physicalRegen = false;
    public bool academicRegen = false;
    public bool moneyRegen = false;


    // Update is called once per frame
    void Update()
    {
        TimerManager();
        SliderChange();
        DeathCheck();

        //Debug section
        /*
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
        */

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


    //Regens over time values
   


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
        if (socialRegen)
        {
            //StartCoroutine(RegenSocial()); //
            StopCoroutine(SocialDecrease());

            StartCoroutine(PhysicalDecrease());
            StartCoroutine(AcademicDecrease());
            StartCoroutine(MoneyDecrease());
        }
        else if (physicalRegen)
        {
            StartCoroutine(SocialDecrease());

            //StartCoroutine(RegenPhysical()); //
            StopCoroutine(PhysicalDecrease());

            StartCoroutine(AcademicDecrease());
            StartCoroutine(MoneyDecrease());
        }
        else if (academicRegen)
        {
            StartCoroutine(SocialDecrease());
            StartCoroutine(PhysicalDecrease());

            //StartCoroutine(RegenAcademic()); //
            StopCoroutine(AcademicDecrease());

            StartCoroutine(MoneyDecrease());
        }
        else if (moneyRegen)
        {
            StartCoroutine(SocialDecrease());
            StartCoroutine(PhysicalDecrease());
            StartCoroutine(AcademicDecrease());

            //StartCoroutine(RegenMoney()); //
            StopCoroutine(MoneyDecrease());
        }
        else
        {
            StartCoroutine(SocialDecrease());
            StartCoroutine(PhysicalDecrease());
            StartCoroutine(AcademicDecrease());
            StartCoroutine(MoneyDecrease());
        }
    }

    // Decays stats
    public IEnumerator SocialDecrease()
    {
        socialVal = (socialVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    public IEnumerator PhysicalDecrease()
    {
        physicalVal = (physicalVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    public IEnumerator AcademicDecrease()
    {
        academicVal = (academicVal - fallSpeed * Time.deltaTime);
        yield return null;
    }

    public IEnumerator MoneyDecrease()
    {
        moneyVal = (moneyVal - fallSpeed * Time.deltaTime);
        yield return null;
    }



}
