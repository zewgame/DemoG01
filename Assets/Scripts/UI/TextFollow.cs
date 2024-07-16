
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour
{
    public Transform _Obj; // Kéo và thả quái vật vào đây
    public Text text; // Kéo và thả Text component vào đây
    public Text txtShow;
    private List<Text> cloneText = new List<Text>();
    private List<GameObject> cloneCharacter = new List<GameObject>();
    private int textIndex;
    private void Update()
    {
        
        if(cloneText.Count >0 && cloneCharacter.Count> 0)
        {
            int k = 0;
            foreach(GameObject clone in cloneCharacter)
            {
                
                Vector3 screenPosClone = Camera.main.WorldToScreenPoint(clone.transform.position);
                cloneText[k].transform.position = screenPosClone;
                k++;
            }
           
        }
    }
    public void createTextName(bool isplayer,int indexText,GameObject gObj)
    {
        Text cloneName = Instantiate(text, transform);
        cloneText.Add(cloneName);
        cloneCharacter.Add(gObj);
        if(isplayer)
        {
            cloneText[cloneText.Count-1].name = "TextAbovePlayer";
          
        }else
        {
            cloneText[cloneText.Count - 1].name = "TextAboveMob"+indexText;
        }
    }
    public int GetIndexText()
    {
        textIndex += 1;
        return textIndex;
    }
    public void showText(string txt,Color color,Transform trs)
    {
        txtShow.text = txt.ToString();
        txtShow.color = color;
        Text Clone = Instantiate(txtShow, transform);
        Vector3 screenPosClone = Camera.main.WorldToScreenPoint(trs.position);
        Clone.transform.position = screenPosClone;
    }

}
