using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class HelloRPC : NetworkBehaviour {

    // Update is called once per frame
    void Update(){
        if (Keyboard.current != null && Keyboard.current.hKey.wasPressedThisFrame){
            string id_player = Runner.LocalPlayer.ToString();

            RPC_Greeting("Hello, I'm " + id_player);
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_Greeting(string message){
        SayHello helloInterface = FindAnyObjectByType<SayHello>();

        if (helloInterface != null){ helloInterface.ShowMessage(message); }
    }
}
