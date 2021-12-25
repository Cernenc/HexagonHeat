using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hexagons
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class HexMesh : MonoBehaviour
    {
        private List<Vector3> _vertices;
        private List<int> _triangles;

        private void Awake()
        {
            _vertices = new List<Vector3>();
            _triangles = new List<int>();
        }

        internal void Triangulate(HexCell cell)
        {
            cell.HexCellMesh.Clear();
            _vertices.Clear();
            _triangles.Clear();
            
            Vector3 center = cell.transform.localPosition;
            for (int i = 0; i < 6; i++)
            {
                AddTriangle(
                    center,
                    center + HexMetric.corners[i],
                    center + HexMetric.corners[i + 1]
                );
            }

            cell.HexCellMesh.vertices = _vertices.ToArray();
            cell.HexCellMesh.triangles = _triangles.ToArray();
            cell.HexCellMesh.RecalculateNormals();
        }

        private void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            int vertexIndex = _vertices.Count;
            _vertices.Add(v1);
            _vertices.Add(v2);
            _vertices.Add(v3);
            _triangles.Add(vertexIndex);
            _triangles.Add(vertexIndex + 1);
            _triangles.Add(vertexIndex + 2);
        }
    }
}
