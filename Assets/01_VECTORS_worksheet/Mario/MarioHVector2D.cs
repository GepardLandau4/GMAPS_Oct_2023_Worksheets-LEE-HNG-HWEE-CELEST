using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(rb.position) * -1f;
        moveDir = new HVector2D(gravityDir.y, gravityDir.x * -1f);
        moveDir.Normalize();
        moveDir = moveDir * -1f;

        rb.AddForce(moveDir.ToUnityVector2() * force);

        gravityDir.Normalize();
        gravityNorm = gravityDir;
        rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength);

        float angle = Vector3.SignedAngle(Vector3.right, moveDir.ToUnityVector2(), Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(rb.position, gravityDir.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(rb.position, moveDir.ToUnityVector3(), Color.blue, 60f);

    }
}
