using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMProFX
{
    /// <summary>
    /// Set color of selective characters within text.
    /// </summary>
    public class ColorOverride : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI Text;
        public Color32 OverrideColor;
        public List<int> Indeces; // List of text indices to apply effect on: in between consecutive pairs

        protected const int vertsInQuad = 4; // Number of vertices in a single text quad.

        private void Awake()
        {
            UpdateVertices();
        }

        public void UpdateVertices()
        {
            if (Indeces.Count < 2) return;
            var tf = Text.textInfo;
            for (int charIndex = 0; charIndex < tf.characterCount; ++charIndex)
            {
                int meshIndex = tf.characterInfo[charIndex].materialReferenceIndex;
                int vertexIndex = tf.characterInfo[charIndex].vertexIndex;
                Color32[] vertexColors = tf.meshInfo[meshIndex].colors32;

                for (int j = 0; j < vertsInQuad; j++)
                {
                    if (tf.characterInfo[charIndex].character == ' ') continue; // Without skipping spaces, sometimes bugs out
                    if (charIndex >= Indeces[0] && charIndex < Indeces[1])
                        vertexColors[vertexIndex + j] = OverrideColor;
                    else
                        vertexColors[vertexIndex + j] = Text.color;
                }
            }

            Text.UpdateVertexData();
        }

        private void Update()
        {
            UpdateVertices();
        }
    }

}
