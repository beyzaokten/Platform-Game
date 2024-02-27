using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private float lookAhead;

    private void Update()
    {
        transform.position = new Vector3(player.position.x+lookAhead,transform.position.y,transform.position.z);
        lookAhead=Mathf.Lerp(lookAhead,(distance*player.localScale.x),Time.deltaTime*speed);
    }

}
