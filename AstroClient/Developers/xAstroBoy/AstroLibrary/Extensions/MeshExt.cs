using System;

namespace AstroClient.Developers.xAstroBoy.AstroLibrary.Extensions
{
    using UnityEngine;

    internal static class MeshExtensions
    {
        internal static void SeparateMeshes(this GameObject gameObject, bool separateSubmeshes = true, bool addMeshCollider = false)
        {
            MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

            if (meshFilter == null || meshRenderer == null)
            {
                Log.Debug("MeshFilter or MeshRenderer component not found on game object.");
                return;
            }

            Mesh combinedMesh = meshFilter.sharedMesh;
            int subMeshCount = combinedMesh.subMeshCount;
            Mesh[] subMeshes = new Mesh[subMeshCount];
            Material[] subMeshMaterials = new Material[subMeshCount];

            int activeSubmeshIndex = 0;
            int[] subMeshTriangles = combinedMesh.GetTriangles(activeSubmeshIndex);
            // Create a child GameObject to hold the submeshes
            GameObject subMeshObject = new GameObject("SubMeshes");
            subMeshObject.transform.parent = gameObject.transform;

            if (separateSubmeshes && subMeshCount > 1)
            {

                for (int i = 0; i < subMeshCount; i++)
                {
                    subMeshTriangles = combinedMesh.GetTriangles(i);
                    if (subMeshTriangles.Length == 0) continue; // skip empty submeshes

                    Vector3[] subMeshVertices = new Vector3[subMeshTriangles.Length];

                    for (int j = 0; j < subMeshTriangles.Length; j++)
                    {
                        subMeshVertices[j] = combinedMesh.vertices[subMeshTriangles[j]];
                        subMeshTriangles[j] = j;
                    }

                    Mesh subMesh = new Mesh();
                    subMesh.name = string.Format("SubMesh {0}", i);
                    subMesh.vertices = subMeshVertices;
                    subMesh.triangles = subMeshTriangles;
                    subMesh.uv = combinedMesh.uv;
                    subMesh.RecalculateBounds();
                    subMesh.RecalculateNormals();

                    subMeshes[i] = subMesh;

                    GameObject subMeshChildObject = new GameObject(subMesh.name);
                    subMeshChildObject.transform.parent = subMeshObject.transform;

                    MeshFilter subMeshFilter = subMeshChildObject.AddComponent<MeshFilter>();
                    subMeshFilter.mesh = subMesh;

                    MeshRenderer subMeshRenderer = subMeshChildObject.AddComponent<MeshRenderer>();
                    Material[] materials = meshRenderer.sharedMaterials;

                    if (i < materials.Length && materials[i] != null)
                    {
                        subMeshMaterials[i] = new Material(materials[i]);
                        subMeshMaterials[i].mainTexture = materials[i].mainTexture;
                    }

                    if (addMeshCollider)
                    {
                        subMeshChildObject.AddComponent<MeshCollider>();
                    }
                }

                activeSubmeshIndex = Array.IndexOf(meshRenderer.sharedMaterials, meshRenderer.sharedMaterial);
                if (activeSubmeshIndex < 0) activeSubmeshIndex = 0;
                if (activeSubmeshIndex >= subMeshCount) activeSubmeshIndex = subMeshCount - 1;

                meshFilter.mesh = subMeshes[activeSubmeshIndex];
            }
            else
            {
                // Use the original mesh and materials
                meshFilter.mesh = combinedMesh;

                for (int i = 0; i < subMeshCount; i++)
                {
                    if (i < meshRenderer.sharedMaterials.Length && meshRenderer.sharedMaterials[i] != null)
                    {
                        subMeshMaterials[i] = new Material(meshRenderer.sharedMaterials[i]);
                        subMeshMaterials[i].mainTexture = meshRenderer.sharedMaterials[i].mainTexture;
                    }
                }

                meshRenderer.materials = subMeshMaterials;
            }
            if (separateSubmeshes)
            {
                subMeshMaterials[activeSubmeshIndex] = meshRenderer.sharedMaterials[activeSubmeshIndex];

                for (int i = 0; i < subMeshCount; i++)
                {
                    if (i != activeSubmeshIndex && subMeshMaterials[i] == null)
                    {
                        if (i < meshRenderer.sharedMaterials.Length && meshRenderer.sharedMaterials[i] != null)
                        {
                            subMeshMaterials[i] = new Material(meshRenderer.sharedMaterials[i]);
                            subMeshMaterials[i].mainTexture = meshRenderer.sharedMaterials[i].mainTexture;
                        }
                    }
                }
            }
            else
            {
                if (meshRenderer.sharedMaterial != null)
                {
                    subMeshMaterials[0] = new Material(meshRenderer.sharedMaterial);
                    subMeshMaterials[0].mainTexture = meshRenderer.sharedMaterial.mainTexture;
                }
            }

            if (separateSubmeshes)
            {
                if (addMeshCollider)
                {
                    foreach (Transform child in subMeshObject.transform)
                    {
                        child.gameObject.AddComponent<MeshCollider>();
                    }
                }
            }
            else
            {
                if (addMeshCollider)
                {
                    gameObject.AddComponent<MeshCollider>();
                }
            }
        }





        internal static void ScaleMesh(this GameObject gameObject, Vector3 scale)
        {
            // Scale the mesh of each child GameObject
            foreach (Transform childTransform in gameObject.transform)
            {
                MeshFilter childMeshFilter = childTransform.GetComponent<MeshFilter>();
                Mesh childMesh = childMeshFilter.mesh;

                Vector3[] vertices = childMesh.vertices;
                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i] = Vector3.Scale(vertices[i], scale);
                }

                childMesh.vertices = vertices;
                childMesh.RecalculateBounds();
            }
        }

        internal static void ScaleMesh(this GameObject gameObject, float x, float y, float z)
        {
            gameObject.ScaleMesh(new Vector3(x, y, z));
        }
    }
}