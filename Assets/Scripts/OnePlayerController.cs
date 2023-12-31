using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerController : MonoBehaviour
{

    public float forwardSpeed;

    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rigidbody;

    private Vector3 _direction;

    [SerializeField] private float moveSpeedVelocity;

    private Touch _touch;

    public bool isFinish;

    public GameObject playerBody;

    public GameObject playerPieceses;

    public FourCameraSahke cameraShake;


    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        if (isFinish) return;

        MoveForward();

        if (Input.touchCount > 0)
        {

            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {

                _direction = new Vector3(_touch.deltaPosition.x, 0, _touch.deltaPosition.y);

            }

            if (_touch.phase == TouchPhase.Ended)
            {

                _direction = Vector3.zero;

                _rigidbody.velocity = _direction;

            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("Obstacle collision");

            CollisionObstacle();

        }

    }


    private void FixedUpdate()
    {
        if (isFinish) return;

        MoveWithRigidbody();

    }

    private void MoveForward()

    {
        transform.position += transform.forward * (forwardSpeed * Time.deltaTime);

        cameraTransform.position += Vector3.forward * (forwardSpeed * Time.deltaTime);

    }

    private void MoveWithRigidbody()

    {

        _rigidbody.velocity = _direction * (moveSpeedVelocity * Time.fixedDeltaTime);

    }

    private void CollisionObstacle()

    {

        isFinish = true;

        _rigidbody.velocity = Vector3.zero;

        playerPieceses.SetActive(true);

        playerBody.SetActive(false);

        ThreeUiManager.Instance.OpenFailmage();

        cameraShake.ShakeCamera();

    }

}
