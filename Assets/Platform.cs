using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsActive;

    public Platform LastPlatform;
    public Platform NextPlatform;

    public Target ParentTarget;

    public void Start()
    {
        this.ParentTarget = this.GetComponentInParent<Target>();

        if (this.ParentTarget == null)
        {
            Debug.LogError("Platform does not have a Target Parent");
        }
    }

}
