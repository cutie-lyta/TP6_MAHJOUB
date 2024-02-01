using System.Collections;
using UnityEngine;

public class PlayerAnimationPhleauppy : MonoBehaviour
{
    private PlayerMain _playerMain;
    private Animator _animator;

    private void Start()
    {
        this._animator = this.GetComponent<Animator>();
        this._playerMain = this.GetComponent<PlayerMain>();
        this._playerMain.PlayerMovement.OnJump += () =>
        {
            this._animator.SetTrigger("Jump");

            // Stop the previous coroutine without saving it.
            // Also useful if, for some kind of obscure reason, the coroutine was started in another way.
            this.StopAllCoroutines();
            this.StartCoroutine(this.RotateTowardDirection());
        };
        this._playerMain.OnLose += () =>
        {
            this._animator.enabled = false;
        };
    }

    // TODO: Try to find if there's a better way to do it, it might be unoptimized
    private IEnumerator RotateTowardDirection()
    {
        float startAngle = 45;
        float endAngle = -90;

        float t = 0;
        float speed = 0.0000001f;

        while (t < 1)
        {
            if (speed < 0.05f)
            {
                speed *= 2;
            }

            t += speed;

            var angles = this.transform.rotation.eulerAngles;
            angles.x = Mathf.Lerp(startAngle, endAngle, t);

            this.transform.rotation = Quaternion.Euler(angles);

            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
