using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform player;
    public float movingSpeed;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private int lastX;
    void start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        findPlayer(isLeft);
    }
    public void findPlayer(bool playerIsLeft)
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x,
           player.position.y - offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x,
           player.position.y - offset.y, transform.position.z);
        }
    }
    void Update()
    {
        if (this.player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
       
        if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft
= true;
            this.lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if (isLeft)
                target = new Vector3(player.position.x - offset.x, player.position.y
               - offset.y, transform.position.z);
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y
               - offset.y, transform.position.z);
            }
            this.transform.position = Vector3.Lerp(this.transform.position, target,
           movingSpeed * Time.deltaTime);
        }
    }
}
