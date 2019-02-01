using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour {

    public float speed = 1f;
    public Transform target;

    private float posX;
    private float posY;

    private Vector2 originPos;

    private float targetPosX;
    private float targetPosY;

    private void Start()
    {
        speed = (speed / 10);
        originPos = new Vector2(transform.position.x, transform.position.y);
        targetPosX = target.transform.position.x;
        targetPosY = target.transform.position.y;
    }

    void Update () {
        if (target)
        {
            posX = targetPosX - target.transform.position.x;
            posY = targetPosY - target.transform.position.y;

            transform.position = originPos + new Vector2(posX * speed, posY * speed);
        }
	}
}
