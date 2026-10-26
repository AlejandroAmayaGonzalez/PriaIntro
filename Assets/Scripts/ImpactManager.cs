using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class ImpactManager : NetworkBehaviour {

    public MeshRenderer meshRenderer;

    [Networked, OnChangedRender(nameof(UpdateColor))]
    public Color ImpactColor { get; set; }

    [Networked]
    public float Health { get; set; }

    public override void Spawned(){
        if (Object.HasStateAuthority){
            Health = 100f;
            ImpactColor = Color.green;
        }

        UpdateColor();
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_ReceiveDamage(int damage){
        Health = Mathf.Max(0f, Health - damage);

        ImpactColor = new Color(
            1f - Health / 100f,
            Health / 100f,
            0f,
            1f
        );
    }

    private void UpdateColor(){
        if (meshRenderer != null) meshRenderer.material.color = ImpactColor;
    }
}
