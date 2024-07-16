using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    
    void Start()
    {
        txtFl = GameObject.Find("CanvasAbove").GetComponent<TextFollow>();
        healthCtrler = GetComponent<HealthEnemy>();
        createNameAbove();
    }

    // Update is called once per frame
    void Update()
    {
        updateInfoMob();
    }
    private void updateInfoMob()
    {
        float health = healthCtrler.health;
       
            txtAboveMob.text = "Mob" + indexName + " - Level: " + level + " - HP: " + health + "/" + healthCtrler.healthDefault;
       
    }   
    public void ClearText()
    {
        txtAboveMob.text = " ";
    }
    private void createNameAbove()
    {
        indexName= txtFl.GetIndexText();
        txtFl.createTextName(false,indexName, pointMob);
        txtAboveMob = GameObject.Find("TextAboveMob"+indexName).GetComponent<Text>();
    }
    public int level;
    private HealthEnemy healthCtrler;
    private int indexName;
    [Header("Vị trí xuất hiện tên Mob")]
    private Text txtAboveMob;
    public GameObject pointMob;

    private TextFollow txtFl;
}
