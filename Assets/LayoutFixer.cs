using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutFixer : MonoBehaviour
{
    public RectTransform layoutGroupRectTransform;

    void Start()
    {
        // Force the layout to rebuild after the scene loads
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroupRectTransform);
    }
}
