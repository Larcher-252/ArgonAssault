using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controllSpeed = 30f;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yMax = 7f;

    private void Update()
    {
        ProcessRotation();
        ProcessTranslation();
    }

    void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    // Update is called once per frame
    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controllSpeed;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controllSpeed;
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, 0, yMax);

        transform.localPosition = new Vector3 (xNewPos, yNewPos, transform.localPosition.z);
    }
}
