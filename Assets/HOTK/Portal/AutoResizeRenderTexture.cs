﻿using System;
using UnityEngine;

public class AutoResizeRenderTexture : MonoBehaviour
{
    public AutoResizeCameraForRenderTexture script;
    public GameObject OutlineQuad;

    private float _width;
    private float _height;
	
	public void Update ()
    {
	    if (_width == transform.localScale.x && _height == transform.localScale.y) return;
	    _width = transform.localScale.x;
	    _height = transform.localScale.y;
	    var marginX = Math.Max(4, (((int) (transform.localScale.x/100f)) / 2) * 2);
	    var marginY = Math.Max(4, (((int) (transform.localScale.y/100f)) / 2) * 2);

        var r = DesktopPortalController.Instance.GetNewRenderTexture(marginX, marginY);
	    if (script != null) script.ResizeCamera(r);
        if (OutlineQuad != null) OutlineQuad.transform.localScale = new Vector3(transform.localScale.x + marginX, transform.localScale.y + marginY, 1f);
    }
}
