using UnityEngine;

namespace Assets.Scripts.Hexagons
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class HexCell : MonoBehaviour
    {
        public Mesh HexCellMesh { get; private set; }
        public int HexNumber { get; set; }
        public Color HexColor { get; private set; }

        private void Awake()
        {
            GetComponent<MeshFilter>().mesh = HexCellMesh = new Mesh();
        }
        private void Start()
        {
            GetComponent<MeshRenderer>().material.color = HexColor = ColorCheck.HexCellColors[HexNumber];
        }
    }
}