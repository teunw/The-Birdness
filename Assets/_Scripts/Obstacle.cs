using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts
{
    public class Obstacle : MonoBehaviour
    {
        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();
            LevelManager.getInstance().InvalidTiles.Add(_transform.position);
        }

        void Update()
        {
            
        }

        void OnDrawGizmos()
        {
            if (_transform == null)
                _transform = GetComponent<Transform>();
            Gizmos.DrawWireCube(_transform.position, new Vector3(1, 1, 0));
        }
    }
}
