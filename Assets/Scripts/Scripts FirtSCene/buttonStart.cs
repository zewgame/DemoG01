using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonStart : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
