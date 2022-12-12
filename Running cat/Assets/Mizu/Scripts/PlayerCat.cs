using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCat : MonoBehaviour
{
    private int _obstacleLayer = 0;
    private int _strayLayer = 0;
    private int _playingLayer = 0;

    private void Start()
    {
        _obstacleLayer = LayerMask.NameToLayer("Obstacle");
        _playingLayer = LayerMask.NameToLayer("Playing");
        _strayLayer = LayerMask.NameToLayer("Stray");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _strayLayer)
        {
            collision.gameObject.layer = gameObject.layer;
            collision.gameObject.transform.parent = gameObject.transform.parent;
            collision.gameObject.AddComponent<PlayerCat>();
        }

        if (collision.gameObject.layer == _obstacleLayer)
        {
            gameObject.layer = _playingLayer;
            gameObject.transform.parent = null;
            this.enabled = false;
        }
    }

    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, 90f - 45f, 90f);
    }

    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 90f + 45f, 90f);
    }

    public void LookForward()
    {
        transform.rotation = Quaternion.Euler(0, 90f, 90f);
    }
}
