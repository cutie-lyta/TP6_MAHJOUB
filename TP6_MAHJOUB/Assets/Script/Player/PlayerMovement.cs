using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private TextMeshProUGUI _tutorial;

    [SerializeField]
    private AudioSource _listener;

    [SerializeField]
    private Animator _animator;

    private PlayerMain _playerMain;
    private Rigidbody _rb;

    private bool _lost = false;

    public event Action OnJump;

    private void Start()
    {
        this._rb = this.GetComponent<Rigidbody>();
        Time.timeScale = 0;

        this._playerMain = this.GetComponent<PlayerMain>();
        this._playerMain.OnLose += () =>
        {
            this._lost = true;
        };
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            this._tutorial.enabled = false;

            if (!this._listener.isPlaying)
            {
                this._listener.Play();
                this._animator.SetTrigger("StartBeat");
            }

            if (!this._lost)
            {
                this.Jump();
            }
            else
            {
                GameManager.Instance.Score = 0;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void Jump()
    {
        this._rb.velocity = Vector3.zero;
        this._rb.AddForce(new Vector3(0, this._jumpForce, 0), ForceMode.VelocityChange);
        this.OnJump?.Invoke();
    }
}
