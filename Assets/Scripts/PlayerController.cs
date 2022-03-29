using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float speed = 30f;
        float xOffset = xThrow * Time.deltaTime * speed;
        float yOffset = yThrow * Time.deltaTime * speed;

        transform.localPosition = new Vector3
        (transform.localPosition.x + xOffset,
        transform.localPosition.y + yOffset,
        transform.localPosition.z);
    }
}
