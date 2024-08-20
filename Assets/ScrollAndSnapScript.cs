
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollAndSnapScript : MonoBehaviour
{
    public static ScrollRect scrollRect; // The ScrollRect component of your scroll view
    public RectTransform content; // The content RectTransform that holds all the children

    public GameObject scrollContentGameObject;
    RectTransform closestChild;
    RectTransform LastChild;
    float childNumber;
    float closestchildNumber;
    float ratio;
    public static float position;


    public GameObject centerOfCanvas;
    void Start()
    {
        // Get the ScrollRect component attached to the same GameObject this script is attached to
        scrollRect = GetComponent<ScrollRect>();

        SetSliderTo1();

    }
    public static void SetSliderTo1()
    {
        scrollRect.verticalNormalizedPosition = 1;

    }
    public void CenterChild(RectTransform targetChild)
    {
        // Get the position of the target child relative to the content RectTransform
        Vector2 childLocalPosition = targetChild.localPosition;

        // Calculate the offset to center the child
        float contentHeight = content.rect.height;
        float viewportHeight = scrollRect.viewport.rect.height;

        // Calculate the normalized position in the range [0, 1]
        float normalizedPositionY = 1f-Mathf.Clamp01((contentHeight / 2f - childLocalPosition.y) / (contentHeight - viewportHeight));


        // Set the normalized position of the scroll rect
        scrollRect.verticalNormalizedPosition = normalizedPositionY;
    }
    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            float closestDistance = float.MaxValue;
            foreach (RectTransform childTransform in scrollContentGameObject.transform)
            {
                childTransform.GetComponent<RectTransform>().localScale = Vector3.Lerp(childTransform.GetComponent<RectTransform>().localScale, new Vector3(1, 1, 1),0.3f); // new Vector3(1,1,1);
                childNumber = childNumber+1;
                if(Vector3.Distance(childTransform.position, centerOfCanvas.transform.position) < closestDistance)
                {
                    closestDistance = Vector2.Distance(childTransform.position, new Vector2(0, 0));
                    closestChild = childTransform;
                    closestchildNumber = childNumber;
                }
                LastChild = childTransform;
            }
            
            Debug.Log("Closest child " + closestchildNumber);
            Debug.Log("Closest Child Name:"+closestChild.name);
            Debug.Log("Closeest child distance to center" + closestChild.localPosition);
            closestChild.GetComponent<RectTransform>().localScale = Vector3.Lerp(closestChild.GetComponent<RectTransform>().localScale, new Vector3(1.5f, 1.5f, 1), 0.6f);

            position = 1f-(LastChild.localPosition.y + closestChild.localPosition.y) / (LastChild.localPosition.y * 2);
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition,position,0.3f);

            childNumber = 0;
            
        }
    }
}
