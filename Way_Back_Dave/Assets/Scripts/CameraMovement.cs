using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    public GameObject backstop;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start()
    {
        player = GameObject.Find("Player");
        backstop = GameObject.Find("backstop_end");
        xMax = backstop.transform.position.x - 10;
    }

    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

}
