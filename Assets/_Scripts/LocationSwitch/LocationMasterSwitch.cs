using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._Scripts;

public class LocationMasterSwitch : MonoBehaviour
{

    public LocationSwitch LocationSwitch;
    private Transform _transform;
    private bool _switched;

    public BirdManager BirdManager;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update ()
    {
        Bird b = CheckBird();
        Bird b2 = LocationSwitch.CheckBird();

        if (b == null && b2 == null)
        {
            _switched = false;
        }
        if (b != null && b2 != null && !_switched)
        {
            _switched = true;
            Vector3 bPosition = new Vector3(b.Transform.position.x, b.Transform.position.y, b.Transform.position.z);
            b.Transform.position = b2.Transform.position;
            b2.Transform.position = bPosition;
        }
    }

    void OnDrawGizmos()
    {
        if (_transform == null) Start();
        Gizmos.DrawWireCube(_transform.position, new Vector3(1,1,1));  
    }

    public Bird CheckBird()
    {
        if (BirdManager.Red.Transform.position == _transform.position)
        {
            return BirdManager.Red;
        }
        if (BirdManager.Yellow.Transform.position == _transform.position)
        {
            return BirdManager.Yellow;
        }
        return null;
    }
}
