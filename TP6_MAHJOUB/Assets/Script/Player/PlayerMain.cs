using System;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    public event Action OnLose;

    private void OnCollisionEnter(Collision other)
    {
        this.OnLose?.Invoke();
    }
}
