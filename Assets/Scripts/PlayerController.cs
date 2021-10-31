using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]
    float MoveSpeed;
    [SerializeField]
    float maxPos;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        //This Line Code Simply Write To shortform
        transform.position += Vector3.right * inputX * MoveSpeed * Time.deltaTime;
        //This Line Player Move Control
        float Xpos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3(Xpos, transform.position.y, transform.position.z);


    }
}
