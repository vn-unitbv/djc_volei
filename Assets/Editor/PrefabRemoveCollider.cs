using UnityEngine;
using UnityEditor;

public class PrefabRemoveCollider : MonoBehaviour
{
    [MenuItem("Tools/Remove all colliders in selection")]
    static public void removeColliderAndApplyPrefabChanges()
    {
        var selection = Selection.gameObjects;
        int colliderCount = 0;
        if (selection != null)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                if (!selection[i].TryGetComponent<Collider>(out var collider))
                    continue;

                ++colliderCount;

                DestroyImmediate(collider);
            }

            Debug.Log($"Removed {colliderCount} colliders");
        }
        else
        {
            Debug.Log("Nothing selected");
        }
    }
}