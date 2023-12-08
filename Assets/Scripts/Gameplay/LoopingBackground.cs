using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float scrollSpeed = 5f;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
    }
}
