using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SetPos : MonoBehaviour
{
    public float SpawnInterval;

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnInterval);
            // Spawn
            if (Input.GetMouseButton(0))
            {
                OnReceivePoint(Camera.main.ScreenToViewportPoint(Input.mousePosition));
            }
        }
    }


    public void OnReceivePoint(Vector2 pos)
    {
        GameObject obj = ObjectPool.SharedInstance.GetPooledObject();
        if (obj != null)
        {
            int w2 = Screen.width / 2;
            int h2 = Screen.height / 2;
            float x = remap(pos.x, 0, 1, -w2, w2);
            float y = remap(pos.y, 0, 1, -h2, h2);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            obj.SetActive(true);
        }
    }

    void Start()
    {
        // StartCoroutine(SpawnCoroutine());
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnReceivePoint(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
    }

    float remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}