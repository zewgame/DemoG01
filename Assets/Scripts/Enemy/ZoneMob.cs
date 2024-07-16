using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMob : MonoBehaviour
{
    
    private void Update()
    {
        CheckMobActive();
    }
    private void CheckMobActive()
    {
        timeResetMob += Time.deltaTime;
        if (MobObject.activeSelf)
        {
            timeResetMob = 0;
        }
        else
        {
            if(timeResetMob > 5f)
            {
                
                healthMob = MobObject.GetComponent<HealthEnemy>();
                healthMob.resetHealth();
                anim = MobObject.GetComponent<Animator>();
                anim.SetTrigger("idle");
                MobObject.SetActive(true);
            }       
        }
    }
    public GameObject MobObject;
    private HealthEnemy healthMob;
    private Animator anim;
    private float timeResetMob = 0;
}
