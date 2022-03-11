using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _StartView : GameObjectHandler
{
    //TODO - Adjust to really login, for now just opens the map szene
    public void LoginWaxCloudWallet()
    {
        GameObjectHandler.OpenScene("MapScene");
    }

    //TODO - Adjust to really login, for now just opens the map szene
    public void LoginAnchorWallet()
    {
        GameObjectHandler.OpenScene("MapScene");
    }

}
