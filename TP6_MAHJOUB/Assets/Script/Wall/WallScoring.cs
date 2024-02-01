using TMPro;
using UnityEngine;

public class WallScoring : MonoBehaviour
{
    public TextMeshProUGUI TmpScore;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Score++;
        Destroy(this.GetComponent<Collider>());
        this.TmpScore.text = GameManager.Instance.Score.ToString();
    }
}
