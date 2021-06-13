using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DaleranGames
{
    public static class SpriteTools
    {
        public static Texture2D ToTexture2D(this Sprite sprite, Color color, int width,int height)
        {
            Texture2D spritePreview = AssetPreview.GetAssetPreview(sprite); // Get sprite texture

            Color[] pixels = spritePreview.GetPixels();
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = pixels[i] * color; // Tint
            }
            spritePreview.SetPixels(pixels);
            spritePreview.Apply();

            Texture2D preview = new Texture2D(width, height);
            EditorUtility.CopySerialized(spritePreview, preview); // Returning the original texture causes an editor crash
            return preview;
        }

        public static Texture2D ToTexture2D(this Sprite sprite, int width, int height)
        {
            Texture2D spritePreview = AssetPreview.GetAssetPreview(sprite); // Get sprite texture
            Texture2D preview = new Texture2D(width, height);
            EditorUtility.CopySerialized(spritePreview, preview); // Returning the original texture causes an editor crash
            return preview;
        }

    }
}

