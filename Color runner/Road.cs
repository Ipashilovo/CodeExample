using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Road : MonoBehaviour
{
    [SerializeField] private ObjectColor _objectColor;

    public ObjectColor ObjectColor => _objectColor;
}
