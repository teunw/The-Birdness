using UnityEngine;
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
        if (b != null && !b.CanMove(b.Transform.position + b.LastMove))
        {
            b.Transform.position += b.LastMove;
        }
    }

    public Bird CheckBird()
    {
        if (BirdManager.Red.Transform.position == _transform.position && BirdManager.Red.SpriteRenderer.enabled)
        {
            return BirdManager.Red;
        }
        if (BirdManager.Yellow.Transform.position == _transform.position && BirdManager.Yellow.SpriteRenderer.enabled)
        {
            return BirdManager.Yellow;
        }
        return null;
    }
}
