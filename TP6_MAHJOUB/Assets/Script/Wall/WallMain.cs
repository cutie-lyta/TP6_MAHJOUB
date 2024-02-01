using UnityEngine;

public class WallMain : MonoBehaviour
{
    public float Speed;
    public float DestroyX;

    protected virtual void FixedUpdate()
    {
        this.transform.Translate(-(this.Speed / 10), 0, 0);
        if (this.transform.position.x < this.DestroyX)
        {
            Destroy(this.gameObject);
        }
    }
}
