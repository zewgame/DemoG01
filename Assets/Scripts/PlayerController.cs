using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        faceRight = true;
        isAttack = false;
        sHP = GetComponent<HealthPlayer>();
        createNameAbove();
    }

    // Update is called once per frame
    private void Update()
    {
        checkLevelUp();
        checkInput();
        updateText();
    }
   
    // kiểm tra đầu vào của bàn phím
    private void checkInput()
    {
        if(isAttack)
        {
            cooldownTimerMove += Time.deltaTime;
            if(cooldownTimerMove > 0.5f)
            {
                cooldownTimerMove = 0;
                isAttack = false;
            }
        }
        else
        {
            move = Input.GetAxis("Horizontal");
            myBody.velocity = new Vector2(move * Speed, myBody.velocity.y);
            if (Input.GetKeyDown(KeyCode.G))
            {
                myAnim.SetBool("moving", false);
                myAnim.SetTrigger("attack");
                isAttack = true;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space)&& CountJump >0)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x,Jump);
                    CountJump -= 1;
                }
                if (move == 0)
                {
                    myAnim.SetBool("moving", false);
                }
                if (move != 0)
                {
                    myAnim.SetBool("moving", true);
                    if (move > 0 && !faceRight)
                    {
                        flip();
                    }
                    else if (move < 0 && faceRight)
                    {
                        flip();
                    }
                }
            }
         
        }
    }
    // Tạo Text phía trên nhân vật
    private void createNameAbove()
    {
        
        txtFl.createTextName(true,0,pointPl);
        txtAbovePlayer = GameObject.Find("TextAbovePlayer").GetComponent<Text>();
    }
    // Scale Hướng mặt của nhân vật
    private void flip()
    {
        faceRight = !faceRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // Sử dụng Skill Magic khi tấn công
    private void useSkillAttack()
    {
        if (faceRight == true)
        {
            Instantiate(bullet_magic, transform.position, Quaternion.Euler(0, 0, 0));
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
        if (faceRight == false)
        {
            Instantiate(bullet_magic, transform.position, Quaternion.Euler(0, 0, 180));
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }

    }
    // Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            CountJump = 2;
          
        }
        if (collision.gameObject.tag == "Lava")
        {
            transform.position = GameObject.Find("LocationSpawn").transform.position;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject orther = collision.gameObject;
        if(orther.tag == "items")
        {
            if(orther.name.IndexOf("Crystal")!=-1)
            {
                plusCrystal(1);
                Destroy(orther);
            }
        }
    }
    // end Colission
    // Kiểm tra cấp độ
    private void checkLevelUp()
    {
        ExpPercent = (CurrentExp / ExpRequired) * 100;
        txtAbovePlayer.text = "Player - Lv." + Level + " - " + ExpPercent + "%";
        if (CurrentExp>= ExpRequired)
        {
            updateAfterLevelUp();
        }
    }
    // Nhận Exp khi farm
    public void plusExp(float dameEXP)
    {
        CurrentExp += dameEXP;
        string plusExp = "+" + dameEXP.ToString() + " EXP";
        //Debug.Log(minusHP);
        txtFl.showText(plusExp, Color.green, transform);
    }
    // Nâng cấp thuộc tính khi lên cấp
    private void updateAfterLevelUp()
    {
        Level += 1;
        Dame += 30*Level*2;
        Health += 100*Level;
        CurrentExp -= ExpRequired;
        ExpRequired += 1000;
        sHP.updateHPDefault(Health);

    } 
    // Crystal
    public int getCrystal()
    {
        return CountCryStal;
    }
    public void setCrystal(int countCrystal)
    {
        this.CountCryStal = countCrystal;
    }
    public void plusCrystal(int countCrystal)
    {
        this.CountCryStal += countCrystal;
    }
    public void minusCrystal(int countCrystal)
    {
        this.CountCryStal -= countCrystal;
    }
    
    // cập nhập số lượng crystal
    private void updateText()
    {
        Textcrystal.text = CountCryStal.ToString();
    }
    // End CryStal
    private float ExpPercent;
    [Header("Kinh Nghiệm Yêu Cầu Để lên Level")]
    public float ExpRequired = 0;
    [Header("Kinh Nghiệm Hiện Tại")]
    public float CurrentExp = 0;
    private Rigidbody2D myBody;
    private Animator myAnim;
    private bool faceRight;
    private float move = 0;
    private int CountJump = 2;
    [Header("Thông số nhân vật")]
    public int Level;
    public int Speed;
    public int Jump;
    public float Dame;
    public float Health;
    [Header("Vị trí xuất hiện tên nhân vật")]
    private Text txtAbovePlayer;
    public GameObject pointPl;
    [Header("Kĩ năng bắn của nhân vật")]
    public GameObject bullet_magic;
    private bool isAttack;
    private float cooldownTimerMove = Mathf.Infinity;
    public TextFollow txtFl;
    [Header("Text Crystal")]
    public Text Textcrystal;
    private HealthPlayer sHP;
    private int CountCryStal = 0;
   
    
}
