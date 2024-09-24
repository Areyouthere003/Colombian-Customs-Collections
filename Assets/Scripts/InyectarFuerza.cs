using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InyectarFuerza : MonoBehaviour
{
    [SerializeField] InputActionProperty tiggerValue;
    [SerializeField] GameObject _player;
    [SerializeField] InputActionProperty triggerGrab;
    [SerializeField] GameObject _ball;
    [SerializeField, Tooltip("Added Force"), Range(0,100)] float _force;
    [SerializeField] bool valid01 = false, valid02 = false;
    float _triggerValue, _triggerGrab;
/*    [SerializeField]*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _triggerValue = tiggerValue.action.ReadValue<float>();
        _triggerGrab = triggerGrab.action.ReadValue<float>();

        if (_triggerValue == 1)
        {
            valid01 = true;

            //if (_triggerGrab == 1)
            //{
                triggerGrab.action.Disable();
            Debug.Log(_triggerGrab);
            //}

        }

        if (valid01 && valid02)
        {
            _ball.GetComponent<Rigidbody>().velocity = (Vector3.forward * _force);
            valid02 = false;
            valid01 = false;
            //triggerGrab.action.Enable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            _ball = other.GetComponent<GameObject>();
            Debug.Log(_ball);
            valid02 = true;
        }
    }
}
