using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public InputField code;

    public void onClickGetGoogleCode()
    {
        GoogleAuthenticator.GetAuthCode();
    }
}
