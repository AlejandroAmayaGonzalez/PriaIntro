using UnityEngine;
using Fusion;

public class BulletMovement : NetworkBehaviour {
    public float speed = 10f;
    private Vector3 direction;

    public override void Spawned(){
        direction = transform.forward;
    }

    public override void FixedUpdateNetwork(){
        if (!Object.HasStateAuthority)
            return;

        transform.position += direction * speed * Runner.DeltaTime;
    }
}
