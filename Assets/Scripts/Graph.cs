using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform PointPrefab;
    [SerializeField][Range(10, 200)] private int resolution = 10;
    
    private Transform[] points;
    float step = 0f;
    
    void Start()
    {
        points = new Transform[resolution];
        step = 2f / resolution;

        Vector3 scale = Vector3.one * step;

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Instantiate(PointPrefab, transform);
            points[i].localScale = scale;
        }
    }

    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;

            position.x = (i + 0.5f) * step - 1f;
            position.y = MathF.Sin(MathF.E * position.x + time);

            point.localPosition = position;
        }
    }
}
