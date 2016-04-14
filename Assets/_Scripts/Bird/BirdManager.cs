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
        public UIManager uiManager;
        public Sprite SquishyBird;

        private Sprite redSprite;
        private Vector2 lastInput;
        private bool BusyLoading;

        void Start()
        {
            Debug.Log("Load level " + SceneManager.GetActiveScene().name);
        }

        void Update()
        {
            CheckInput();
            CheckRestartInput();
            CheckWinCondition();
        }

        private void CheckRestartInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void CheckWinCondition()
        {
            if (Yellow.LevelDone && Red.LevelDone && !BusyLoading)
            {
                BusyLoading = true;
                Highscore.AddHighscoreAsync(new Highscore(SceneManager.GetActiveScene().name, uiManager.MovesMade));
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
            bool yellow = Yellow.OnMove(side, moveVal);
            bool red = Red.OnMove(side, moveVal * -1);
            if (yellow || red)
            {
                uiManager.MovesMade += 1;
            }
            if (Yellow.Transform.position == Red.Transform.position)
            {
                Yellow.SpriteRenderer.enabled = false;
                redSprite = Red.SpriteRenderer.sprite;
                Red.SpriteRenderer.sprite = SquishyBird;
            }
            else if (redSprite != null)
            {
                Red.SpriteRenderer.sprite = redSprite;
                Yellow.SpriteRenderer.enabled = Red.SpriteRenderer.enabled = true;
            }
        }
    }
}

