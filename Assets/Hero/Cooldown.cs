using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cooldown : MonoBehaviour
{
    public Image imageCD;
    public float cooldown = HeroScript.cooldown;
    bool isCooldown;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            isCooldown = true;
        }

        if(isCooldown)
        {
            imageCD.fillAmount += cooldown * Time.deltaTime;

            if(imageCD.fillAmount == 1)
            {
                imageCD.fillAmount = 0;
                isCooldown=false;
            }
                
        }
    }
}
