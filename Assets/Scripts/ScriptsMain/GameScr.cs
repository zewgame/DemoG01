using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScr : MonoBehaviour
{
    private GameObject panelComfirm;
    private GameObject exchangeTable;
    
    private bool isPComfirm = false;
    private bool isETable = false;
    public GameObject[] items;
    public GameObject[] bulletPet;
    public GameObject[] Pets;
    public bool isPet;
    public GameObject messBox;
    private GameObject enemyPetAttack;
    private PlayerController plc;
    // Start is called before the first frame update
    void Start()
    {
        plc = GameObject.Find("Player").GetComponent<PlayerController>();
        panelComfirm = GameObject.Find("Panel Comfirm");
        exchangeTable= GameObject.Find("Exchange Table");
        panelComfirm.SetActive(false);
        exchangeTable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkPet();
        if(isETable)
        {
            GameObject.Find("Text Crystal Shop").GetComponent<Text>().text = "Số linh thạch hiện có: "+plc.getCrystal();
        }
    }
    public void ActivePanelComfirm()
    {
        isPComfirm = !isPComfirm;
        panelComfirm.SetActive(isPComfirm);
    }
    public void ActiveExchangeTable()
    {
        isETable = !isETable;
        exchangeTable.SetActive(isETable);
    }
    public void ClosePComfirm()
    {
        ActivePanelComfirm();
    }
    public void OpenExchangeTable()
    {

        ActivePanelComfirm();
        ActiveExchangeTable();
    }
    public void CloseExchangeTable()
    {
        ActiveExchangeTable();
    }
    public GameObject getItem(int idItem)
    {
        return items[idItem];
    }   
    private void checkPet()
    {
        try
        {
            GameObject pet = GameObject.FindGameObjectWithTag("Pet");
            if (pet != null)
            {
                isPet = true;
               
            }
            else
            {
                isPet = false;
               
            }
        }
        catch(Exception)
        {
            
        }
        
    }
    public void petAttackEnemy(GameObject objEnemy)
    {
        if(isPet)
        {
            GameObject pet = GameObject.FindGameObjectWithTag("Pet");
            Instantiate(bulletPet[0], pet.transform.position,Quaternion.identity);
            enemyPetAttack = objEnemy;
        }
    }
    public GameObject getEnemyPetAttack()
    {
        return enemyPetAttack;
    }
    private void TakePet(int price,int idPet)
    {
       
        int CountCrystal = plc.getCrystal();
        if (CountCrystal>=price)
        {
            plc.minusCrystal(price);
            if (isPet)
            {
                GameObject locationPet = GameObject.Find("LocationPet");
                GameObject pet = GameObject.FindGameObjectWithTag("Pet");
                Destroy(pet);
                Instantiate(Pets[idPet], locationPet.transform);
            }
            else
            {
                GameObject locationPet = GameObject.Find("LocationPet");
                Instantiate(Pets[idPet], locationPet.transform);
            }
        }else
        {
            GameObject cloneMesBox = GameObject.Find("MessageBox");
            if (cloneMesBox==null)
            {
                cloneMesBox = Instantiate(messBox, GameObject.Find("Canvas").transform);
                cloneMesBox.name = "MessageBox";

            }
            else
            {
                Destroy(cloneMesBox);
                cloneMesBox = Instantiate(messBox, GameObject.Find("Canvas").transform);
                cloneMesBox.name = "MessageBox";
            }    

        }
       

    }
    public void takeVulture()
    {
        TakePet(5, 0);
    }
    public void takeDino()
    {
        TakePet(5, 1);
    }
    public void takeDog()
    {
        TakePet(5, 2);
    }
    public void takeMagicSword()
    {
        // not
    }
}
