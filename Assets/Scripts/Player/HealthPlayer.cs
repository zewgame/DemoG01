using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    private float health;
    public float healthDefault;
    public Slider slider;
    public TextFollow txtFl;
    private float CDRecoverHPTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (health/healthDefault)*100;
        RecoverHP();
    }
    public void TakeDame(int damage)
    {
        health -= damage;
        GetComponent<Animator>().SetTrigger("hust"); 
        // lùi lại khi nhận sát thương
        transform.position = new Vector3(transform.position.x + (1f * (- transform.localScale.x)), transform.position.y, transform.position.z);
        string minusHP = "-" + damage.ToString() + " hp";
        //Debug.Log(minusHP);
        txtFl.showText(minusHP, Color.red, transform);
        checkDie();
    }
    public void updateHPDefault(float HP)
    {
        healthDefault = HP;
       
    }
    private void RecoverHP()
    {
        if (health < healthDefault)
        {
            CDRecoverHPTimer += Time.deltaTime;
            if (CDRecoverHPTimer>5f)
            {
                float PercentHP = (health / healthDefault) * 100;
                if (PercentHP > 10f)
                {
                    string plusHP = "+" + (healthDefault / 10).ToString() + " hp";
                    health += (healthDefault / 10);
                    txtFl.showText(plusHP, Color.green, transform);
                    CDRecoverHPTimer = 0;
                }
                else if(PercentHP < 10f)
                {
                    string plusHP = "+" + (healthDefault - health).ToString() + " hp";
                    health = healthDefault;
                    txtFl.showText(plusHP, Color.green, transform);
                    CDRecoverHPTimer = 0;
                }
            }    
            
        }    
    }
    private void checkDie()
    {
        if (health<=0)
        {
            transform.position = new Vector3(0,0,0);
            health = healthDefault;
        }
    }    
    public string getInfoHealth()
    {
        return health+"/"+healthDefault;
    }    
}
