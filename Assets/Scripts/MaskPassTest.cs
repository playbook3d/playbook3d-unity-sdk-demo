using System;
using System.Collections.Generic;
using UnityEngine;
using PlaybookUnitySDK.Runtime;

namespace PlaybookUnitySDK.Scripts
{
    public class MaskPassTest : MonoBehaviour
    {
        [SerializeField]
        private MaskGroupObjects[] maskGroupObjects =
        {
            new() { group = MaskGroup.Mask1, maskGroupObjects = new List<GameObject>() },
            new() { group = MaskGroup.Mask2, maskGroupObjects = new List<GameObject>() },
            new() { group = MaskGroup.Mask3, maskGroupObjects = new List<GameObject>() }
        };

        private void Start()
        {
            foreach (MaskGroupObjects maskGroupObject in maskGroupObjects)
            {
                PlaybookSDK.AddObjectsToMaskGroup(
                    maskGroupObject.maskGroupObjects,
                    maskGroupObject.group
                );
            }
        }
    }

    [Serializable]
    public struct MaskGroupObjects
    {
        public MaskGroup group;
        public List<GameObject> maskGroupObjects;
    }
}