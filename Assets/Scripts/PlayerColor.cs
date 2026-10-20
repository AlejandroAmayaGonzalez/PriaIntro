using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class PlayerColor : NetworkBehaviour {

    public MeshRenderer meshRenderer;
    
    [Networked, OnChangedRender(nameof(ColorChanged))] public Color NetworkedColor { get; set; }

    private void Update() {
        if (HasStateAuthority == false) { return; }

        if (Keyboard.current.eKey.wasPressedThisFrame) {
            NetworkedColor = new Color(Random.value, Random.value, Random.value, 1f);
        }
    }

    private void ColorChanged() { meshRenderer.material.color = NetworkedColor; }
}
