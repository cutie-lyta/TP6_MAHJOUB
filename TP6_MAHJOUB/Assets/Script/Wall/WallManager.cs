using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private float _movableWallSpeed = 5f;

    [SerializeField]
    private float _frequency = 4;

    [SerializeField]
    private PlayerMain _playerMain;

    [SerializeField]
    private TextMeshProUGUI _tmpScore;

    [SerializeField]
    private GameObject _pipe;

    private Camera _cam;
    private float _destroyX;

    private void Start()
    {
        this._cam = FindObjectOfType<Camera>();
        // this._speed = GameManager.Instance.Speed;
        // this._frequency = GameManager.Instance.Frequency;
        this._destroyX = this._cam.ScreenToWorldPoint(new Vector3(-100.0f, 0, -this._cam.transform.position.z)).x;

        this.StartCoroutine(this.SpawnNewWall());

        this._playerMain.OnLose += this.StopAllCoroutines;
        this._playerMain.OnLose += () =>
        {
            foreach (var obj in FindObjectsByType<WallMain>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
            {
                obj.enabled = false;
            }
        };
    }

    private IEnumerator SpawnNewWall()
    {
        for (; ;)
        {
            GameObject obj = Instantiate(this._pipe);

            float variation = Random.Range(Screen.height - (Screen.height / 8), Screen.height / 8);
            Vector3 position =
                this._cam.ScreenToWorldPoint(new Vector3(Screen.width + 40, Screen.height - variation, -this._cam.transform.position.z));

            obj.transform.position = position;
            if (Random.Range(0, 2) == 0)
            {
                var wall = obj.AddComponent<WallMain>();
                wall.Speed = this._speed;
                wall.DestroyX = this._destroyX;
            }
            else
            {
                var wall = obj.AddComponent<MovableWallMain>();
                wall.Speed = this._speed;
                wall.DestroyX = this._destroyX;
                wall.MovementSpeed = this._movableWallSpeed;
            }

            obj.GetComponentInChildren<WallScoring>().TmpScore = this._tmpScore;

            yield return new WaitForSeconds(1 - (this._frequency - 1) / 30);
        }
    }
}
