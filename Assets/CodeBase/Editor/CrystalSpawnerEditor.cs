using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(CrystalSpawner))]
    public class CrystalSpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmos(CrystalSpawner target, GizmoType gizmoType)
        {
            Vector3 position = target.transform.position;

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}