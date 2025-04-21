using UnityEngine;
using TMPro;

public class High : MonoBehaviour
{
    public Transform player; // 플레이어 오브젝트
    public TextMeshProUGUI highText; // 높이를 표시할 UI Text

    private float maxHeight = 0f; // 최고 높이 기록

    void Update()
    {
        // 플레이어가 이전 최고 높이보다 높이 올라갔을 경우 갱신
        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
            highText.text = maxHeight.ToString("F1") + "m";
        }
    }
}
