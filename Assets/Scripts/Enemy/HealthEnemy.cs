using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public float health;
    public float healthDefault;
    private TextFollow txtFl;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = healthDefault;
        txtFl = GameObject.Find("CanvasAbove").GetComponent<TextFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void TakeDame(float damage)
    {
        health -= damage;
        string minusHP = "-" + damage.ToString() + " hp";
        //Debug.Log(minusHP);
        txtFl.showText(minusHP, Color.red, transform);
        if (health>0)
        {
            anim.SetTrigger("hust");
        }
        if (health<=0)
        {
            GetComponent<EnemyController>().ClearText();
            anim.SetTrigger("die");
            DropItems();
            gameObject.SetActive(false);
        }
    }
    private void DropItems()
    {
        int i = Random.Range(0,10);
        if(i>1)
        {
            GameScr gameScr = GameObject.Find("GameScreen").GetComponent<GameScr>();
            Instantiate(gameScr.getItem(0), transform.position, Quaternion.Euler(0, 0, 0));
            
        }
    }
    public void resetHealth()
    {
        health = healthDefault;
    }
}
