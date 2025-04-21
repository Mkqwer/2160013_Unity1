using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform[] backgrounds; // BG1, BG2 등
    public float backgroundHeight;  // 배경 이미지의 높이

    public Transform player; // 플레이어 또는 카메라 위치 기준

    void Update()
    {
        foreach (Transform bg in backgrounds)  // 배경이미지 반복
        {
            if (player.position.y - bg.position.y > backgroundHeight) // 플레이어가 배경1 보다 위에있을때
            {
                // 배경을 가장위로 옮기며 backgrounds.Length를 사용한 이유 여러 배경을 사용했을때 자연스럽게 이어지도록 하기 위해
                bg.position += new Vector3(0, backgroundHeight * backgrounds.Length, 0); 
            }
        }
    }
}
