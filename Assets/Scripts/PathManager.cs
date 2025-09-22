using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
    [HideInInspector] [SerializeField] public List<WayPoint> path;

    public GameObject prefab;
    int currentPointIndex = 0;

    public List<GameObject> prefabPoints;

    public List<WayPoint> GetPath()
    {
        if (path == null) path = new List<WayPoint>();
        return path;
    }

    public void CreateAddPoint()
    {
        WayPoint go = new WayPoint();
        path.Add(go);
    }

    public WayPoint getNextTarget()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);;
        currentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    public void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach (WayPoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }

    public void Update()
    {
        for (int i = 0; i < path.Count; i++)
        {
            WayPoint p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }
}
