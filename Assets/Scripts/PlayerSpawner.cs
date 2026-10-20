using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined {
    
    public GameObject PlayerPrefab;

    // If MY player joins, spawn it
    void IPlayerJoined.PlayerJoined(PlayerRef player) {
        if (player == Runner.LocalPlayer){
            Runner.Spawn(PlayerPrefab, new Vector3(Random.Range(0,6),1,0), Quaternion.identity);
        }
    }

}
