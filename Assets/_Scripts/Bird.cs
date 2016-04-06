using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts
{
    [RequireComponent(typeof(Transform), typeof(SpriteRenderer))]
    public class Bird : MonoBehaviour, MovementListener
    {
        private Transform _transform;
        private SpriteRenderer spriteRenderer;
        private Transform goalTransform;

        public bool reFlip;
        public Color Color;
        public Goal Goal;

        void Start()
        {
            _transform = GetComponent<Transform>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            goalTransform = Goal.GetComponent<Transform>();
        }

        void Update()
        {
            if (_transform.position == goalTransform.position)
            {
                Debug.Log("Done");
            }
        }

        public void OnMove(MovementDirection md, int val)
        {
            Vector3 p = _transform.position;
            Vector3 newPos;
            if (md == MovementDirection.HORIZONTAL)
            {
                newPos = new Vector3(p.x + val, p.y, p.z);
            }
            else if (md == MovementDirection.VERTICAL)
            {
                newPos = new Vector3(p.x, p.y + val, p.z);
            }
            else
            {
                return;
            }

            if (LevelManager.getInstance().InvalidTiles.Contains(newPos))
            {
                return;
            }
            _transform.position = newPos;

            spriteRenderer.flipX = val == 1;
            if (reFlip) spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        void OnDrawGizmos()
        {
            if (_transform == null) _transform = GetComponent<Transform>(); 
            Gizmos.DrawWireCube(_transform.position, new Vector3(1,1,0));
        }
    }
}
