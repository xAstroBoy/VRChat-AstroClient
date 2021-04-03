namespace AstroClient.AntiCrash
{
    using AstroClient.extensions;
    using DayClientML2.Utility.Extensions;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    public static class AntiCrashScanner
    {
        public static Material DefaultMaterial = new Material(Shader.Find("Standard"));

        public static void ScanAvatar(GameObject avatar, VRC_AvatarDescriptor descriptorObj)
        {
            if (descriptorObj != null)
            {
                AntiCrashUtils.TempLog($"Descriptor found: {descriptorObj.name}");
            }

            if (avatar != null)
            {
                var player = avatar.transform.root.GetComponentInChildren<Player>();
                AntiCrashUtils.TempLog($"Scanning {player.DisplayName()}'s avatar..");
                InitiateScan(avatar);
            }
        }

        private static void InitiateScan(GameObject avatar)
        {
            var renderers = avatar.GetComponentsInChildren<Renderer>();

            foreach (var renderer in renderers)
            {
                AntiCrashUtils.TempLog($"Renderer found: {renderer.name}");

                foreach (var material in renderer.materials)
                {
                    ScanMaterial(material);
                }
            }
        }

        private static void ScanMaterial(Material material)
        {
            // TODO: Use blacklist instead
            AntiCrashUtils.TempLog($"Shader: {material.shader.name}");
            if (material.shader.name != "Standard")
            {
                material = DefaultMaterial;
            }
        }

        private static int GetPolyCount(GameObject avatar)
        {
            return 0; // WIP
        }
    }
}
