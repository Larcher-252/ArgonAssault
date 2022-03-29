using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controllSpeed = 30f;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yMax = 7f;
    [SerializeField] float positionPitchFactor = 20f;
    [SerializeField] float ControlPitchFactor = 10f;
    [SerializeField] float positionYawFactor = 20f;
    [SerializeField] float ControlRollFactor = 10f;
    float xThrow = 0f;
    float yThrow = 0f;

    private void Update()
    {
        ProcessRotation();
        ProcessTranslation();
    }

    void ProcessRotation()
    {
        float pitchToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchToThrow = yThrow * ControlPitchFactor;

        float yawToPosition = transform.localPosition.x * -positionYawFactor;

        float rollToThrow = xThrow * -ControlRollFactor;

        float pitch = pitchToPosition + pitchToThrow;
        float yaw = yawToPosition;
        float roll = rollToThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // Update is called once per frame
    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controllSpeed;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controllSpeed;
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, 0, yMax);

        transform.localPosition = new Vector3 (xNewPos, yNewPos, transform.localPosition.z);
    }
}
