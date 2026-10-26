using UnityEngine;
using Fusion;

public class BulletManager : NetworkBehaviour {
    public float speed = 10f;
    private Vector3 direction;

    // Timer's bullet
    public float lifeTime = 3f;
    private TickTimer despawnTimer;

    public override void Spawned(){
        direction = transform.forward;
        // Iniatize the timer
        despawnTimer = TickTimer.CreateFromSeconds(Runner, lifeTime);
    }

    public override void FixedUpdateNetwork(){
        if (!Object.HasStateAuthority) return;

        // 3 seconds to the bullet to impact, if not despawn it
        if (despawnTimer.Expired(Runner)){
            Runner.Despawn(Object);
            return;
        }

        transform.position += direction * speed * Runner.DeltaTime;
    }

    private void OnTriggerEnter(Collider other){
        if (!Object.HasStateAuthority) return;

        if (!other.CompareTag("Player")) return;

        ImpactManager impactManager = other.GetComponentInParent<ImpactManager>();

        if (impactManager != null){ impactManager.RPC_ReceiveDamage(20); }

        Runner.Despawn(Object);
    }
}
