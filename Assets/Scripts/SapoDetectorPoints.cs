using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoDetectorPoints : MonoBehaviour
{
    [SerializeField] int[] valuePoints = { 9, 10, 12, 15, 20, 30, 70, 80, 90, 500};
    [SerializeField] int valuepointsArray = 0, totalPoints = 0; 
    [SerializeField] bool valid01 = false;
    int _count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(valid01)
        {
            totalPoints += valuePoints[valuepointsArray];
            valid01 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ring"))
        {
            valid01 = true;
        }
    }
}
