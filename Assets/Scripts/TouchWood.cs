using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchWood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wood"))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

    }
}
