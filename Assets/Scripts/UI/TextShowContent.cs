
using UnityEngine;
using UnityEngine.UI;

public class TextShowContent : MonoBehaviour
{
    public Text txtShow;
    private Text clone;
    private Transform trss;
    public void Start()
    {
        Destroy(gameObject,2f);
    }
    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(trss.position);
        clone.transform.position = screenPos;

    }
    public void showText(string txt, Color color, Transform trs)
    {
        trss = trs;
        txtShow.text = txt.ToString();
        txtShow.color = color;
        //txtShow.transform.position = screenPos01;
        clone = Instantiate(txtShow, transform);
       
    }

}
