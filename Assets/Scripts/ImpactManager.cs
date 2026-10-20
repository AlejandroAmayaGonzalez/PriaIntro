using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class impactManager : NetworkBehaviour {

    public MeshRenderer meshRenderer;
    
    [Networked, OnChangedRender(nameof(ImpactChangeColor))] Color ImpactColor { get; set; }

    // PLayer health
    float health = 50f;

    void Update(){
        if (HasStateAuthority == false) { return; }

        if (Keyboard.current.iKey.wasPressedThisFrame) {
            // Simulate an impact
            health -= Random.Range(2f, 5f);
            // Change green value
            ImpactColor = new Color(1-(health/100),health/50,0,1f);
        }
    }

    // Change the color of the player based on health
    private void ImpactChangeColor() { meshRenderer.material.color = ImpactColor; }
}
