﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts
{
    public class LevelManager : MonoBehaviour
    {
        #region Singleton
        private static LevelManager instance;

        public static LevelManager getInstance()
        {
            return instance;
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            
            else if (instance != this)
                Destroy(gameObject);
        }
        #endregion

        [HideInInspector]
        public List<Vector3> InvalidTiles = new List<Vector3>();

        public Vector2 LevelSize;

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        public bool IsInside(Vector2 pos)
        {
            Rect rect = new Rect(_transform.position.x - (LevelSize.x / 2), _transform.position.y - (LevelSize.y / 2), LevelSize.x, LevelSize.y);
            return rect.Contains(pos);
        }

        void OnDrawGizmos()
        {
            if (_transform == null) _transform = GetComponent<Transform>();
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_transform.position, new Vector3(LevelSize.x, LevelSize.y, 0));
        }

    }
}
