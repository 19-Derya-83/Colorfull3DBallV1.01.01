using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerClamp : MonoBehaviour
{

    public OnePlayerController playerController;

    public float xClamp;

    public float zBackOffset;

    public float zForwardOffset;

    private Vector3 playerPosition;

    private void Update()
    {

        ClampPosition();

        MoveZPosition();

    }

    private void ClampPosition()

    {

        playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(transform.position.x, -xClamp, xClamp);

        playerPosition.z = Mathf.Clamp(transform.position.z, zBackOffset, zForwardOffset);

        transform.position = playerPosition;

    }

    private void MoveZPosition()

    {

        if (playerController.isFinish) return;

        zBackOffset += playerController.forwardSpeed * Time.deltaTime;

        zForwardOffset += playerController.forwardSpeed * Time.deltaTime;

    }

}
