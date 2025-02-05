using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothing", menuName = "Character/Clothing", order = 0)]
public class Clothing : ScriptableObject
{
    [Header("Prefab (Required)")]
    public GameObject ModelPrefab;

    [HideInInspector]
    public ClothingInternalData Internals;
    [HideInInspector]
    public ClothingInternalData[] InternalsMany; // Some clothing items have multiple skinnedmeshrenderers.

    [Header("Clothing Key Data (Required if not attachable)")]
    public BaseCharacter BaseCharacter;
    public MaterialData[] Materials;

    [Tooltip("This is an old deletion Option, use Skin Deletion instead.")]
    [Header("Feet Deletion (Old)")]
    public bool DeleteFeet;
    public float DeleteFeetHeight = 0.1f;

    [Tooltip("This is not compatiable with \"Feet Deletion (Old)\", untick the \"Delete Feet\" to make this work.")]
    [Header("Skin Deletion (New)")]
    public bool DeleteSkin;
    public SkinDeletionData[] DeleteCubeSpaces;

    [Header("Attachment Information (Optional)")]
    public bool IsNonSkinnedAttachment;
    public string AttachBone;
    public Vector3 AttachPosition, AttachRotation, AttachScale;

    [Serializable]
    public class MaterialData
    {
        public Material Material;
        public MaterialAction BakeAction;

        [Header("Optional Overrides")]
        public Material OverrideHDRP2018Material;
        public Material OverrideHDRP2019Material;
        public Material OverrideURP2019Material;
        public Material OverrideStandardMaterial;

        public enum MaterialAction
        {
            Merge,
            Leave,
            LeaveOrStrip,
        }
    }

    [Serializable]
    public class SkinDeletionData
    {
        [Tooltip("Unnecessary property, name the deletion space to note.")]
        public string Name;

        public Vector3 position;
        public Vector3 scale;
    }

    [Serializable]
    public class ClothingInternalData
    {
        public string MeshName;
        public Vector3[] OriginalVertices;
        public Vector3[] OriginalNormals;
        public TriangleData[] OriginalTriangles;
        public int[] Triangles;
        public Vector3[] Barycentric;
        public Vector3[] ClosestPoint;
    }

    [Serializable]
    public class TriangleData
    {
        public int SubMesh;
        public int[] Triangles;
    }
}
