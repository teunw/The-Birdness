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

        // Update is called once per frame
        void Update()
        {
            MoveText.text = "Moves made: " + MovesMade;
        }
    }
}
