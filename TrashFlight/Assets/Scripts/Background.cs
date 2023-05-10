using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 배경 이미지 위로 올리기
        // Time.deltaTime : 플랫폼마다 컴퓨터의 성능이 다르기 때문에, 이를 맞춰주는 역할을 한다.
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0,20f,0);
        }
    }
}
