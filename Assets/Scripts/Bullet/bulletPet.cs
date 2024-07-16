using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPet : MonoBehaviour
{
    private GameScr gameScr;
    private Vector3 enemyPos;
    private PlayerController PLCT;
    private float dame;
    void Start()
    {
        Destroy(gameObject, 2f);
        gameScr = GameObject.Find("GameScreen").GetComponent<GameScr>();
        PLCT = GameObject.Find("Player").GetComponent<PlayerController>();
        dame =  (PLCT.Dame*1.5f) ;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos = gameScr.getEnemyPetAttack().transform.position;
        Vector3 rotation = enemyPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ-90);
        transform.Translate(Vector3.up * 20f * Time.deltaTime);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {

            HealthEnemy he = collision.gameObject.GetComponent<HealthEnemy>();
            he.TakeDame(this.dame);
            MeleeEnemy melee = collision.gameObject.GetComponent<MeleeEnemy>();
            PLCT.plusExp(this.dame);
            Destroy(gameObject);
        }
    }
}
