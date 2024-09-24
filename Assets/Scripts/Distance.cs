using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Distance : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    [SerializeField] bool _valid01 = false;
    float _distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_valid01)
        {
            _distance = Vector3.Distance(player.transform.position, target.transform.position);
            Debug.Log(_distance);
        }
    }
}
