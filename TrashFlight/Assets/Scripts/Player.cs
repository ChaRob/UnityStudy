using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // 이는 유니티에서 moveSpeed의 값을 조절할 수 있게 해준다.
    private float moveSpeed;

    // GameObject를 만들어서 unity 내에서 미사일을 선택할 수 있게 된다.
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastshoottime = 0f;

    // Update is called once per frame
    void Update()
    {
        // // 각각 가로, 세로를 입력한 것을 의미한다.
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        
        // // 새로운 벡터를 만들어서 이를 해당 객체의 위치를 움직이도록 한다.
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;
        
        // keyCode를 받아서 해당 키를 눌렀을 때 움직이는 방향을 조절하게 한다.
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -= moveTo;
        // }
        // else if(Input.GetKey(KeyCode.RightArrow)) {
        //     transform.position += moveTo;
        // }

        // 마우스로 제어
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Mathf.Clapm로 min, max값을 지정하여 캐릭터가 화면 밖으로 나가지 못하게 한다.
        float toX = Mathf.Clamp(mousePos.x, -2.4f, 2.4f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot(){
        if(Time.time - lastshoottime > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastshoottime = Time.time;
        }
    }
}
