using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public Text infoPlayer;
    public GameObject pler;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        PlayerController pl = pler.GetComponent<PlayerController>();
        HealthPlayer hpl = pler.GetComponent<HealthPlayer>();
        infoPlayer.text = "Thông tin người chơi: \n Lượng Máu: " + hpl.getInfoHealth() + " \n Sát Thương Gây Ra: " + pl.Dame +"\n Level: "+pl.Level;
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
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Game Pause");
            

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
