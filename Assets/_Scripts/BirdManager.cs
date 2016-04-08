using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets._Scripts;
using UnityEngine.SceneManagement;

namespace Assets._Scripts
{
    public class BirdManager : MonoBehaviour
    {
        // Yellow is the player
        public Bird Yellow, Red;
        public string NextScene; 

        private Vector2 lastInput;

        void Start()
        {

        }

        void Update()
        {
            CheckInput();
            CheckWinCondition();
        }

        private void CheckWinCondition()
        {
            if (Yellow.LevelDone && Red.LevelDone)
            {
                SceneManager.LoadScene(NextScene);
            }
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
