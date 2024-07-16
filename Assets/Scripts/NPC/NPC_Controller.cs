using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    private GameScr gameScr;
    // Start is called before the first frame update
    void Start()
    {
        gameScr = GameObject.Find("GameScreen").GetComponent<GameScr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Kiểm tra khi người chơi click chuột trái
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("NPC")) // Kiểm tra xem va chạm với NPC
            {
                gameScr.ActivePanelComfirm();
            }
        }
    }
}
