using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPause : MonoBehaviour
{
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickP()
    {
        TogglePause();
    }
    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Dừng thời gian khi tạm dừng
    }

    private void OnGUI()
    {
        if (isPaused)
        {
            // Hiển thị UI Box
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Pause Menu");

            // Thêm các nút tiếp tục và thoát game
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20, 160, 30), "Tiếp tục"))
            {
                TogglePause();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 20, 160, 30), "Thoát game"))
            {
                Application.Quit();
            }
        }
    }
}
