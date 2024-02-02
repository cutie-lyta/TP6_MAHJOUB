using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWallMain : WallMain
{
    public float MovementSpeed = 5f;

    private bool _direction = false;

    private float _destroyYMinus;
    private float _destroyYMaxi;
    private Camera _cam;

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        this.transform.Translate(0, (this.MovementSpeed / 20f) * (this._direction ? 1 : -1), 0);

        if ((this.transform.position.y < this._destroyYMinus) && !this._direction)
        {
            this._direction = true;
        }
        else if ((this.transform.position.y > this._destroyYMaxi) && this._direction)
        {
            this._direction = false;
        }

        base.FixedUpdate();
    }

    private void Start()
    {
        this._cam = FindAnyObjectByType<Camera>();
        var position = this._cam.transform.position;

        this._destroyYMinus = this._cam.ScreenToWorldPoint(new Vector3(0, Screen.height / 8, -position.z)).y;
        this._destroyYMaxi = this._cam.ScreenToWorldPoint(new Vector3(0, Screen.height - (Screen.height / 8), -position.z)).y;
    }
}
