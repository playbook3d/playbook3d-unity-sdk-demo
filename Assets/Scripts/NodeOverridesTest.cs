using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;
using PlaybookUnitySDK.Runtime;

namespace PlaybookUnitySDK.Scripts
{
    public class NodeOverridesTest : MonoBehaviour
    {
        private void Start()
        {
            OverrideNodeInputs();
        }

        [SerializeField] private NodeOverrideGroup[] nodeOverrides =
        {
            new() { nodeId = new int(), value = new string("") }
        };
        
        [ContextMenu("Apply Node Overrides")]
        void OverrideNodeInputs()
        {
            Dictionary<string, object> inputs = new();
            foreach(var i in nodeOverrides)
            {
                inputs[i.nodeId.ToString()] = i.value.ToString();
            }
            PlaybookSDK.OverrideNodeInputs(inputs);
            Debug.Log("Applied node overrides!");
        }
    }

    [Serializable]
    public struct NodeOverrideGroup
    {
        public int nodeId;
        public string value;
    }
}
