using System;
using UnityEngine;
using UnityEngine.UIElements;
using static FunctionLibrary;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform PointPrefab;
    [SerializeField][Range(10, 200)] private int resolution = 10;
    [SerializeField] private FunctionName function;
    
    private Transform[] points;
    float step = 0f;
    
    void Start()
    {
        points = new Transform[resolution * resolution];
        step = 2f / resolution;

        Vector3 scale = Vector3.one * step;
        
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(PointPrefab, transform);
            point.localScale = scale;
        }
    }

    void Update()
    {
        Function MathFunc = GetFunction(function);
        
        float time = Time.time;
        Vector3 position = Vector3.zero;
        float v = 0.5f * step - 1f;

        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            { 
                x = 0;
                z++;
                v = (z + 0.5f) * step - 1f;
            }
            
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = MathFunc(u, v, time);
        }
    }
}
