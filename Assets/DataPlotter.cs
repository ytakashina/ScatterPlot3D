using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.IO;
using Accord.Math;
using Extensions;


public class DataPlotter : MonoBehaviour
{
    public string InputPath;
    public float PlotScale;

    private double[][] _points;
    private string[] _columns;

    public int AxisX = 1;
    public int AxisY = 2;
    public int AxisZ = 3;
    public string NameAxisX => _columns[AxisX];
    public string NameAxisY => _columns[AxisY];
    public string NameAxisZ => _columns[AxisZ];
    public GameObject PointPrefab;
    public GameObject PointHolder;


    // Start is called before the first frame update
    void Start()
    {
        var table = new CsvReader(InputPath, true);
        _columns = table.GetFieldHeaders();
        _points = table.ToJagged().Get(null, 1, 5);
        _points = Tools.Scale(Vector.Zeros(4), Vector.Ones(4), _points);
        foreach (var point in _points)
        {
            var indices = new[] { AxisX, AxisY, AxisZ };
            var p = point.Get(indices).Select(v => (float) v).ToArray();
            var dataPoint = Instantiate(PointPrefab, p.ToUnityVector3() * PlotScale, Quaternion.identity);
            dataPoint.transform.parent = PointHolder.transform;
            dataPoint.transform.name = point.ToString(DefaultArrayFormatProvider.CurrentCulture);
            dataPoint.GetComponent<Renderer>().material.color = new Color(p[0], p[1], p[2], 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
