using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTriggerScript : MonoBehaviour
{
    public GameObject canvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trigger")
        {
            canvas.SetActive(true);
        }
    }
}
