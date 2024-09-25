using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoDetectorPoints : MonoBehaviour
{
    [SerializeField] Transform[] _pointsBase;
    [SerializeField] Vector3[] _poinstPosition;
    int _count = 0;

    // Start is called before the first frame update
    void Start()
    {
       _pointsBase = gameObject.GetComponentsInChildren<Transform>();

        while (_pointsBase.Length > _count)
        {
            _poinstPosition[_count] = new Vector3(_poinstPosition[_count].x, _poinstPosition[_count].y, _poinstPosition[_count].z);
            _count++;
        }
    //    for (int i = 0; i < _pointsBase.Length; i++) 
    //    {
    //        _poinstPosition[i] = new Vector3(_poinstPosition[i].x, _poinstPosition[i].y, _poinstPosition[i].z);
    //    }
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
