using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject cloudPrefab; // 랜덤 생성할 구름 프리팹
    private float spawnInterval = 2f; // 생성 간격
    private float minX = -2.0f; // X축의 최소범위
    private float maxX = 2.0f; // X축의 최대범위
    public float yOffset = 5f;  // 플레이어 위로 구름이 생성되는 범위 값
    public Transform player;

    private float nextSpawnY = 0f; // 다음 구름위치를 갱신하는 코드

    void Start()
    {
        nextSpawnY = player.position.y + yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 플레이어의 위치를 확인해서, 플레이어가 nextSpawnY보다 올라갔다면 구름을 하나 생성한다.
        if (player.position.y + yOffset > nextSpawnY)
        {
            CreateCloud(); // 구름 생성 함수
            nextSpawnY += spawnInterval; // 다음 구름의 생성위치를 spawnInterval 만큼 위에서 생성한다
        }
    }

    void CreateCloud()
    {
        // minX maxX 사이의 좌표값
        float randomX = Random.Range(minX, maxX);
        // 구름을 생성할 랜덤 위치 설정 
        Vector3 spawnPosition = new Vector3(randomX, nextSpawnY, 0f);
        //해당 위치에 구름 프리팹 생성
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
    }
}
