using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField] float TimeStoneDestroy = 5f; // Thời gian chờ trước khi viên đá biến mất
    private float elapsedTime = 0f; // Bộ đếm thời gian thực
    private bool isPlayerOnStone = false; // Trạng thái kiểm tra người chơi có đang đứng trên đá hay không

    void Start()
    {
    }
    void Update()
    {
        if (isPlayerOnStone)
        {
            elapsedTime += Time.deltaTime; // Tăng thời gian đếm bằng thời gian thực
            if (elapsedTime >= TimeStoneDestroy)
            {
                Animator animator = GetComponent<Animator>();
                animator.Play("Block_Animation");
               
                Destroy(gameObject,1f); // Phá hủy đối tượng sau khi hết thời gian
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnStone = true;
            elapsedTime = 0f; // Reset bộ đếm thời gian
            //Debug.Log("Player đứng lên viên đá, bắt đầu đếm thời gian.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnStone = false;
            elapsedTime = 0f; // Reset bộ đếm thời gian
            //Debug.Log("Player rời khỏi viên đá, reset thời gian.");
        }
    }
}
