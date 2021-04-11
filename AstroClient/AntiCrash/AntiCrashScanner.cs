namespace AstroClient.AntiCrash
{
    using AstroClient.ConsoleUtils;
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
                //AntiCrashUtils.TempLog($"Descriptor found: {descriptorObj.name}");
            }

            if (avatar != null)
            {
                avatar.SetActive(false);
                var player = avatar.transform.root.GetComponentInChildren<Player>();
                //AntiCrashUtils.TempLog($"Scanning {player.DisplayName()}'s avatar..");
                InitiateScan(avatar);
                avatar.SetActive(true);
            }
        }

        private static void InitiateScan(GameObject avatar)
        {
            var renderers = avatar.GetComponentsInChildren<Renderer>();
            var particleSystems = avatar.GetComponentsInChildren<ParticleSystem>();
            var skinnedMeshRenderers = avatar.GetComponentsInChildren<SkinnedMeshRenderer>();
            var audioSources = avatar.GetComponentsInChildren<AudioSource>();

            int audioSourcesCount = audioSources.Count;
            foreach (var audioSource in audioSources)
            {
                //AntiCrashUtils.TempLog($"AudioSources: {audioSourcesCount}");
                if (audioSourcesCount >= 25)
                {
                    audioSource.DestroyMeLocal();
                    AntiCrashUtils.TempLog($"AudioSources: destroyed, max reached.");
                }
                //AntiCrashUtils.TempLog($"SkinnedMeshRenderer found: {skinnedMeshRenderer.name}");
                // ScanAudioSources(audioSources);
            }

            foreach (var renderer in renderers)
            {
                //AntiCrashUtils.TempLog($"Renderer found: {renderer.name}");

                foreach (var material in renderer.materials)
                {
                    ScanMaterial(material);
                }
            }

            foreach (var particleSystem in particleSystems)
            {
                //AntiCrashUtils.TempLog($"ParticleSystem found: {particleSystem.name}");
                ScanParticleSystem(particleSystem);
            }

            foreach (var skinnedMeshRenderer in skinnedMeshRenderers)
            {
                //AntiCrashUtils.TempLog($"SkinnedMeshRenderer found: {skinnedMeshRenderer.name}");
                ScanSkinnedMeshRenderer(skinnedMeshRenderer);
            }
        }

        private static void ScanMaterial(Material material)
        {
            // TODO: Use blacklist instead
            //AntiCrashUtils.TempLog($"Shader: {material.shader.name} found.");
            if (material.shader.name != "Standard")
            {
                //AntiCrashUtils.TempLog($"Shader: {material.shader.name} reset to default.");
                //material = DefaultMaterial;
            }
        }

        private static void ScanParticleSystem(ParticleSystem particleSystem)
        {
            if (particleSystem.maxParticles >= 10000)
            {
                AntiCrashUtils.TempLog($"ParticleSystem: {particleSystem.name} with {particleSystem.maxParticles} particles destroyed.");
                //particleSystem.enableEmission = false;
                particleSystem.DestroyMeLocal();
            }

            if (particleSystem.collision.maxCollisionShapes >= 10000)
            {
                AntiCrashUtils.TempLog($"ParticleSystem: {particleSystem.name} with {particleSystem.collision.maxCollisionShapes} collision shapes destroyed.");
                //particleSystem.enableEmission = false;
                particleSystem.DestroyMeLocal();
            }

            // TODO: Check bursts
        }

        private static void ScanSkinnedMeshRenderer(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            var polyCount = GetPolyCount(skinnedMeshRenderer.sharedMesh);

            if (polyCount >= 1000000)
            {
                AntiCrashUtils.TempLog($"SkinnedMeshRenderer: with {polyCount} polys destroyed.");
                skinnedMeshRenderer.sharedMesh.DestroyMeLocal();
            }
        }

        private static void ScanAudioSources(AudioSource audioSource)
        {
        }

        private static int GetPolyCount(Mesh sourceMesh)
        {
            int num = 0;
            for (int i = 0; i < sourceMesh.subMeshCount; i++)
            {
                num += sourceMesh.GetTriangles(i).Length / 3;
            }
            return num;
        }
    }
}
