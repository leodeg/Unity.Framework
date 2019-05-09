using UnityEngine;
using UnityEditor;
using System.Collections;

namespace LeoDeg.Editor
{
    public class GroupObjectsMenu : MonoBehaviour
    {

        [MenuItem ("LeoDeg/Group Objects %#&d")]
        public static void LaunchGroupObjects ()
        {
            GroupObjectsEditorWindow.OpenWindow ();
        }
    }
}