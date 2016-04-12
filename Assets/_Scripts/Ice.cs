﻿using UnityEngine;
using System.Collections;
using Assets._Scripts;

public class Ice : MonoBehaviour
{
    public BirdManager BirdManager;

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        Bird b = CheckBird();
        if (b != null)
        {
            b.Transform.position += b.LastMove;
        }
    }

    public Bird CheckBird()
    {
        if (BirdManager.Red.Transform.position == _transform.position)
        {
            return BirdManager.Red;
        }
        if (BirdManager.Yellow.Transform.position == _transform.position)
        {
            return BirdManager.Yellow;
        }
        return null;
    }
}