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
        public SpriteRenderer SpriteRenderer;
        private Transform goalTransform;

        public bool reFlip;
        public Color Color;
        public Goal Goal;

        void Start()
        {
            Transform = GetComponent<Transform>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
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
            if (CanMove(newPos))
            {
                return false;
            }

            PreviousPosition = Transform.position;
            Transform.position = newPos;

            SpriteRenderer.flipX = val == 1;
            if (reFlip) SpriteRenderer.flipX = !SpriteRenderer.flipX;
            return true;
        }

        public bool CanMove(Vector3 newPos)
        {
            return LevelManager.getInstance().InvalidTiles.Contains(newPos) || !LevelManager.getInstance().IsInside(newPos);
        }

        void OnDrawGizmos()
        {
            if (Transform == null) Transform = GetComponent<Transform>(); 
            Gizmos.DrawWireCube(Transform.position, new Vector3(1,1,0));
        }
    }
}
