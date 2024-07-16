using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player_;
    Transform Target;
    
    public float smoothing;
    Vector3 offset;
    float lowY;
    void Start()
    {
        Target = Player_.transform;
        offset =transform.position - Target.position;
        lowY = transform.position.y;
        Screen.SetResolution(1100, 850, false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetCamPos = Target.position+offset;
        transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing * Time.deltaTime);
    }
}
