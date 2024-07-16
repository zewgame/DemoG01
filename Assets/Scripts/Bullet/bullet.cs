using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    private PlayerController PLCT;
    private Text infoMob;
    private GameScr gameScr;
    void Start()
    {

        Destroy(gameObject, 2f);
        pSpaw = gameObject.transform;
        pSpaw.position = new Vector3(pSpaw.position.x, pSpaw.position.y + 1f, pSpaw.position.z);
        gameObject.transform.position = pSpaw.position;
        PLCT = GameObject.Find("Player").GetComponent<PlayerController>();
        dame = PLCT.Dame;
        infoMob = GameObject.Find("InfoMob").GetComponent<Text>();
        gameScr = GameObject.Find("GameScreen").GetComponent<GameScr>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * 10f * Time.deltaTime);
    }
    
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mob")
        {
            
            HealthEnemy he = collision.gameObject.GetComponent<HealthEnemy>();
            he.TakeDame(this.dame);
            PetAtack(he.health,collision.gameObject);
            MeleeEnemy melee = collision.gameObject.GetComponent<MeleeEnemy>();
            infoMob.text = "Thông tin quái vật: \n Lượng Máu: " + he.health + " \n Sát Thương Gây Ra: "+melee.infoDame();
            PLCT.plusExp(this.dame);
            Destroy(gameObject);
        }
    }
    private void PetAtack(float healthEnemy,GameObject objEnemy)
    {
        if(healthEnemy>0)
        {
            gameScr.petAttackEnemy(objEnemy);
        }
    }    
    private Transform pSpaw;
    private float dame;

}
