using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowScore : MonoBehaviour
{
    [SerializeField] Transform _targetPlayer;
    [SerializeField] int posObject = 0;

    [SerializeField] bool valid01 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            Vector3 v3 = gameObject.transform.position - _targetPlayer.transform.position;
            v3.y = 0.0f;
            _targetPlayer.transform.rotation = Quaternion.LookRotation(-v3);
            _targetPlayer.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posObject, gameObject.transform.position.z + posObject);
            valid01 = false;
        }
    }

}
