using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CreateRing : MonoBehaviour
{
    [SerializeField] GameObject _referencia;
    [SerializeField] int posObject = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratorObject(string name)
    {
        GameObject prefab = Resources.Load(name) as GameObject;

        GameObject create = Instantiate(prefab) as GameObject;

        create.transform.position = new Vector3(_referencia.transform.position.x, _referencia.transform.position.y + posObject, _referencia.transform.position.z);
    }
}
