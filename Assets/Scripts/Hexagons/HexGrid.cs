using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hexagons {
    public static class ColorCheck
    {
        public static Color[] HexCellColors { get; set; } = { Color.white, Color.green, Color.blue, Color.red, Color.cyan, Color.yellow, Color.black};
        

    }

    public class HexGrid : MonoBehaviour
    {
        [field: SerializeField]
        public HexCell CellPrefab { get; private set; }

        public HexCell[] Cells { get; private set; }

        public Canvas HexCellCanvas { get; private set; }

        [field: SerializeField]
        public Text HexCellInformation { get; private set; }

        public HexMesh HexMeshProp { get; set; }

        private void Awake()
        {
            HexCellCanvas = GetComponentInChildren<Canvas>();
            HexMeshProp = GetComponentInChildren<HexMesh>();
            Cells = new HexCell[7];

            CreateCell(0, 0, 0);
            CreateCell(1, 1, 0);
            CreateCell(2, -1, 0);
            CreateCell(3, 0.5f, 0.5f);
            CreateCell(4, 0.5f, -0.5f);
            CreateCell(5, -0.5f, 0.5f);
            CreateCell(6, -0.5f, -0.5f);
        }

        private void Start()
        {
            foreach(var cell in Cells)
            {
                HexMeshProp.Triangulate(cell);
            }
        }

        private void CreateCell(int i, float x, float z)
        {
            Vector3 position = new Vector3();
            position.x = x * (HexMetric.innerRadius * 2);
            position.y = 0;
            position.z = z * (HexMetric.outerRadius * 2f);

            HexCell cell = Cells[i] = Instantiate(CellPrefab);
            cell.HexNumber = i;
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;

            Text label = Instantiate<Text>(HexCellInformation);
            label.rectTransform.SetParent(HexCellCanvas.transform, false);
            label.rectTransform.anchoredPosition3D = new Vector3(position.x, position.z, -1f);
            label.text = cell.GetComponent<HexCell>().HexNumber.ToString();
        }
    }
}
