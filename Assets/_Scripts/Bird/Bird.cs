using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets._Scripts
{
    [RequireComponent(typeof(Transform), typeof(SpriteRenderer))]
    public class Bird : MonoBehaviour, MovementListener
    {
        public bool LevelDone = false;

        public Transform Transform;
        public Vector3 PreviousPosition;
        public Vector3 LastMove;
        private SpriteRenderer spriteRenderer;
        private Transform goalTransform;

        public bool reFlip;
        public Color Color;
        public Goal Goal;

        void Start()
        {
            Transform = GetComponent<Transform>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            goalTransform = Goal.GetComponent<Transform>();
        }

        void Update()
        {
            LevelDone = Transform.position == goalTransform.position;
        }

        public bool OnMove(MovementDirection md, int val)
        {
            Vector3 p = Transform.position;
            Vector3 newPos;
            if (md == MovementDirection.HORIZONTAL)
            {
                newPos = new Vector3(p.x + val, p.y, p.z);
                LastMove = new Vector3(val, 0, 0);
            }
            else if (md == MovementDirection.VERTICAL)
            {
                newPos = new Vector3(p.x, p.y + val, p.z);
                LastMove = new Vector3(0, val, 0);
            }
            else
            {
                return false;
            }

            if (LevelManager.getInstance().InvalidTiles.Contains(newPos) || !LevelManager.getInstance().IsInside(newPos))
            {
                return false;
            }
            PreviousPosition = Transform.position;
            Transform.position = newPos;

            spriteRenderer.flipX = val == 1;
            if (reFlip) spriteRenderer.flipX = !spriteRenderer.flipX;
            return true;
        }

        void OnDrawGizmos()
        {
            if (Transform == null) Transform = GetComponent<Transform>(); 
            Gizmos.DrawWireCube(Transform.position, new Vector3(1,1,0));
        }
    }
}
