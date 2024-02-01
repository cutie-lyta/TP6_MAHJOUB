using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public float Speed = 2;
    public float Frequency = 4;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }
}
