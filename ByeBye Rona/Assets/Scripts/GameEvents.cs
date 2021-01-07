using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    
    public event EventHandler onSoapExit;
    public event EventHandler onMaskExit;
    public void SoapExitAction()
    {
        onSoapExit?.Invoke(this, EventArgs.Empty);   
    }

    public void MaskExitAction()
    {
        onMaskExit?.Invoke(this, EventArgs.Empty);
    }


}
