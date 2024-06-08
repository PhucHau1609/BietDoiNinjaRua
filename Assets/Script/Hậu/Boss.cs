using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float start, end; // điểm bắt đầu và kết thúc
    [SerializeField] GameObject player;
    [SerializeField] float speed = 1.5f;

    private bool isLeft = true; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        // lấy vị trí hiện tại của enemies
        var enemiesX = transform.position.x;

        // xác định hiện tại của enemies
        var scaleEnemies = transform.localScale;


        if (player != null)
        {
            // lấy vị trí hiện tại của player
            var playerX = player.transform.position.x;

            if (playerX > start && playerX < end)
            {
                if (playerX < enemiesX) { isLeft = true; }
                if (playerX > enemiesX) { isLeft = false; }
            }
        }


        if (enemiesX <= start)
        {
            isLeft = false;
        }

        if (enemiesX >= end)
        {
            isLeft = true;
        }

        if (isLeft)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {

            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        scaleEnemies.x = isLeft ? 3 : -3;

        transform.localScale = scaleEnemies;
    }
}
