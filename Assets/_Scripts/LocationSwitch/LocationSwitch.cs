using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Assets._Scripts;
using UnityEngine.Networking.Match;

[RequireComponent(typeof(Transform))]
public class LocationSwitch : MonoBehaviour
{

    private Transform _transform;
    public BirdManager BirdManager;
    void Start ()
	{
	    _transform = GetComponent<Transform>();
	}

    void OnDrawGizmos()
    {
        if (_transform == null) Start();
        Gizmos.DrawWireCube(_transform.position, new Vector3(1, 1, 1));
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
