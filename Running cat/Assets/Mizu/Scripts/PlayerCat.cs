using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCat : MonoBehaviour
{
    private int _obstacleLayer = 0;
    private int _strayLayer = 0;
    private int _playingLayer = 0;
    [SerializeField] private Material _mat;

    private void Start()
    {
        _obstacleLayer = LayerMask.NameToLayer("Obstacle");
        _playingLayer = LayerMask.NameToLayer("Playing");
        _strayLayer = LayerMask.NameToLayer("Stray");
        _mat = Resources.Load<Material>("Otter/Arts/Texture/NewCat");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _strayLayer)
        {
            var obj = collision.gameObject;
            obj.layer = gameObject.layer;
            obj.transform.parent = gameObject.transform.parent;
            obj.AddComponent<PlayerCat>();
            obj.GetComponent<Renderer>().material = _mat;
        }

        if (collision.gameObject.layer == _obstacleLayer)
        {
            gameObject.layer = _playingLayer;
            gameObject.transform.parent = null;
            this.enabled = false;
        }
    }

    public void TurnAngle(float yAngle = 0)
    {
        transform.rotation = Quaternion.Euler(0, -yAngle, 0);
    }

    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, -45f, 0);
    }

    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 45f, 0);
    }

    public void LookForward()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
