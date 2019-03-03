using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlotter : MonoBehaviour
{
    public string InputFile;
    private List<Dictionary<string, object>> _points;
    private List<string> _columns;

    public int ColumnX;
    public int ColumnY;
    public int ColumnZ;
    public string xName => _columns[ColumnX];
    public string yName => _columns[ColumnY];
    public string zName => _columns[ColumnZ];
    public GameObject PointPrefab;
    public GameObject PointHolder;


    // Start is called before the first frame update
    void Start()
    {
        _points = CSVReader.Read(InputFile);
        _columns = new List<string>(_points[1].Keys);

        foreach(var point in _points)
        {
            var x = Convert.ToSingle(point[xName]);
            var y = Convert.ToSingle(point[yName]);
            var z = Convert.ToSingle(point[zName]);
            var dataPoint = Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);
            dataPoint.transform.parent = PointHolder.transform;
            dataPoint.transform.name = $"{point[xName]}, {point[yName]}, {point[zName]}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
