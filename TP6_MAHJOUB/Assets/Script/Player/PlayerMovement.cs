using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 5.0f;

    private PlayerMain _playerMain;
    private Rigidbody _rb;

    public event Action OnJump;

    private void Start()
    {
        this._rb = this.GetComponent<Rigidbody>();
        this._playerMain = this.GetComponent<PlayerMain>();
        this._playerMain.OnLose += () =>
        {
            this.enabled = false;
        };
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
    }

    private void Jump()
    {
        this._rb.velocity = Vector3.zero;
        this._rb.AddForce(new Vector3(0, this._jumpForce, 0), ForceMode.VelocityChange);
        this.OnJump?.Invoke();
    }
}
