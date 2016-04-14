using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Flipper : MonoBehaviour
{

    public static System.Random Random;

    void Start ()
    {
        if (Random == null) Random = new System.Random();
        GetComponent<SpriteRenderer>().flipX = Random.NextDouble() > .5;
    }
}
