using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets._Scripts
{
    public class UIManager : MonoBehaviour
    {
        [HideInInspector]
        public int MovesMade;

        public Text MoveText;
        public InputField nameInputField;

        void Start()
        {
            if (nameInputField != null)
            {
                nameInputField.text = PlayerPrefs.GetString(Highscore.UsernameKey);
            }
        }

        // Update is called once per framed
        void Update()
        {
            if (nameInputField != null)
            {
                PlayerPrefs.SetString(Highscore.UsernameKey, nameInputField.text);
            }
            MoveText.text = "Moves made: " + MovesMade;
        }
    }
}
