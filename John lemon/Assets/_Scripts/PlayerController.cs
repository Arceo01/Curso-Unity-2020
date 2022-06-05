#if UNITY_ANDROID || UNITY_IOS
#define USUNG_MOBILE
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float turnSpeed = 20;
    private Quaternion rotation = Quaternion.identity;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
#if USING_MOBILE
        float horizontal = Input.GetAxis(axisName: "Mouse X");
        float vertical = Input.GetAxis(axisName: "Mouse Y");
        if(input.touchcount > 0)
        {
        horizontal = Input.touches[0].deltaposition.x:
        vertical = Input.touches[0].deltaposition.y:
        }

#else
        float horizontal = Input.GetAxis(axisName: "Horizontal");
        float vertical = Input.GetAxis(axisName: "Vertical");
#endif


        movement.Set(newX: horizontal, newY: 0, newZ: vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        _animator.SetBool(name: "IsWalking", value: isWalking);
        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
        Vector3 desiredForward = Vector3.RotateTowards(current: transform.forward, target: movement, maxRadiansDelta: turnSpeed * Time.fixedDeltaTime, maxMagnitudeDelta: 0);
        rotation = Quaternion.LookRotation(forward: desiredForward);
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(position: _rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rot: rotation);
    }
}
