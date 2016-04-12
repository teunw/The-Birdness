using UnityEngine;
using System.Collections;

namespace Assets._Scripts
{
    public class Goal : MonoBehaviour
    {
        private Transform transform;

        public Color BirdColor = Color.black;

        void Start()
        {
            transform = GetComponent<Transform>();
        }

        void OnDrawGizmos()
        {
            if (transform == null) transform = GetComponent<Transform>();
            Color c = Color.yellow;

            if (BirdColor != Color.black)
            {
                c = BirdColor;
            }
            Gizmos.color = c;

            Gizmos.DrawWireCube(transform.position, new Vector3(1,1,0));   
        }


    }
}
