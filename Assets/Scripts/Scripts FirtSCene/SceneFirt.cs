using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFirt : MonoBehaviour
{
    // Start is called before the first frame update
    private float CDShowButton = Mathf.Infinity;
    private int count;
    [SerializeField] private GameObject buttonStart;
    [SerializeField] private GameObject buttonQuit;

    void Awake()
    {
        CDShowButton = 0;
        count = 1;
        buttonStart.SetActive(false);
        buttonQuit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CDShowButton<=2f)
        {
            CDShowButton += Time.deltaTime;
        }
        if(CDShowButton>2f&&count == 1)
        {
            count = 0;
            buttonStart.SetActive(true);
            buttonQuit.SetActive(true);
        }
        
    }
}
