﻿using UnityEngine;
using System.Collections;

public class TapGestureHandle : MonoBehaviour {

    private SelectObjectDelegate selectObject;
    public SelectObjectDelegate SelectCallback {
        set {
            selectObject = value;
        }
    }

    private TapIntercept tapIntercept;
    public TapIntercept TapInterceptDelegate {
        set {
            tapIntercept = value;
        }
    }

    #region MonoBehaviour
    void Start () {
    
    }
    
    void Update () {
    
    }
    #endregion

    #region FingerGesture
    void OnTap (TapGesture gesture) {
        if (tapIntercept()) {
            return;
        }
        if (gesture.Selection != null) {
            if (selectObject != null) {
                selectObject(gesture.Selection);
            }
            else {
                Debug.Log("TapGesturehandle selectObject is null");
            }
        }
        else {
            Debug.Log("No object was tapped at " + gesture.Position);
        }
    }
    #endregion
}
