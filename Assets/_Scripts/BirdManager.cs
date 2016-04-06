using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets._Scripts;

namespace Assets._Scripts
{
    public class BirdManager : MonoBehaviour
    {
        // Yellow is the player
        public Bird Yellow, Red;

        private Vector2 lastInput;

        void Start()
        {

        }

        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            Vector2 movement = new Vector2(0f, 0f);
            if (Input.GetKeyDown(KeyCode.D))
            {
                movement.x = 1f;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                movement.x = -1f;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                movement.y = 1f;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                movement.y = -1f;
            }

            if (movement.x != 0f && movement.y != 0f)
            {
                Debug.Log("Invalid Movement");
                return;
            }
            if (movement == lastInput) return;
            lastInput = movement;

            MovementDirection side = MovementDirection.NONE;
            if (movement.x != 0f)
            {
                side = MovementDirection.HORIZONTAL;
            }else if (movement.y != 0f)
            {
                side = MovementDirection.VERTICAL;
            }
            if (side == MovementDirection.NONE) return;
            int moveVal = (side == MovementDirection.HORIZONTAL) ? (int) movement.x : (int) movement.y;
            Yellow.OnMove(side, moveVal);
            Red.OnMove(side, moveVal * -1);
        }
    }
}
