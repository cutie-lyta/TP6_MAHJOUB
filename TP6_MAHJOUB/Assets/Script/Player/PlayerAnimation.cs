using System.Collections;
using System.Threading;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMain _playerMain;

    private void Start()
    {
        this._playerMain = this.GetComponent<PlayerMain>();
        this._playerMain.PlayerMovement.OnJump += () =>
        {

            // Stop the previous coroutine without saving it.
            // Also useful if, for some kind of obscure reason, the coroutine was started in another way.
            this.StopAllCoroutines();
            this.StartCoroutine(this.RotateTowardDirection());
        };
    }

    // TODO : Change to an animator
    private IEnumerator RotateTowardDirection()
    {
        float startAngle = -0;
        float endAngle = -360;

        float t = 0;
        float speed = 0.05f;

        while (t < 1)
        {
            t += speed;
            var angles = this.transform.rotation.eulerAngles;
            angles.x = Mathf.Lerp(startAngle, endAngle, t);

            this.transform.rotation = Quaternion.Euler(angles);

            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
