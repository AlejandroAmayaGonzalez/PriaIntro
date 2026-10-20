using UnityEngine;
using UnityEngine.InputSystem;

public class SayHello : MonoBehaviour{
    public string mensaje = "Hello, I'm ";

    private float tiempoFin = 0f;

    void Update(){
        if (Keyboard.current != null &&
            Keyboard.current.hKey.wasPressedThisFrame){
            tiempoFin = Time.time + 3f;
        }
    }

    void OnGUI(){
        if (Time.time < tiempoFin){
            GUI.Box(new Rect(20, 20, 350, 50),mensaje);
        }
    }

    public void ShowMessage(string message){ 
        mensaje = message; 
        tiempoFin = Time.time + 3f;
    }
}
