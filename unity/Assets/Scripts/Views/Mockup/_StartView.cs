using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _StartView : GameObjectHandler
{
    //TODO - Adjust to really login, for now just opens the map szene
    public void LoginWaxCloudWallet()
    {
        GameObjectHandler.OpenScene("_MapScene");
    }

    //TODO - Adjust to really login, for now just opens the map szene
    public void LoginAnchorWallet()
    {
        GameObjectHandler.OpenScene("_MapScene");
    }

    public void OpenCreateWallet()
    {
        Application.OpenURL("https://waxel.net/set-up-wax-wallet/");
    }

}
