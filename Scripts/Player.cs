using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] ParticleSystem flamethrowerParticles;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float turnSpeed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // flamethrower
        var emission = flamethrowerParticles.emission;
        if (Input.GetButton("Fire1")) {
            emission.enabled = true;
        } else {
            emission.enabled = false;
        }
    }

    void FixedUpdate()
    {
        // Controller from: https://www.youtube.com/watch?v=gs7y2b0xthU 
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        direction = new Vector2(xInput, yInput);
        float magnitude = Mathf.Clamp01(direction.magnitude);
        direction.Normalize();

        // reduce speed if using flamethrower
        float speed = Input.GetButton("Fire1") ? playerSpeed*0.05f : playerSpeed;

        transform.Translate(direction * speed * magnitude * Time.deltaTime, Space.World);

        if (direction != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }
}
