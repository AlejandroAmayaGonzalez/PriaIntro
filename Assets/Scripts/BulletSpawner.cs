using UnityEngine;
using Fusion;

public class BulletSpawner : NetworkBehaviour {
    
    public GameObject BulletPrefab;
    private Camera cam;

    private float speed = 1f;

    public override void FixedUpdateNetwork(){
        if (!Object.HasStateAuthority)
        return;

        transform.position += cam.transform.position + cam.transform.forward * speed * Runner.DeltaTime;
    }

    public void SpawnBullet(Camera cam){
        this.cam = cam;

        Runner.Spawn(
            BulletPrefab, 
            cam.transform.position + cam.transform.forward, 
            Quaternion.Euler(90, 0, 0)
        );
    }
}
