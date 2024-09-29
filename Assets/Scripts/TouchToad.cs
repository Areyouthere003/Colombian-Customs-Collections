using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToad : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Ring"))
        {
            if(!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }

    }
}
