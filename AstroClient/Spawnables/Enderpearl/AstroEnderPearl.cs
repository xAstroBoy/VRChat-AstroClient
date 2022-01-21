namespace AstroClient.Spawnables.Enderpearl
{
    using AstroMonos.Components.Custom.Items;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class AstroEnderPearl
    {
        private static GameObject ENDER;

        private static bool _isChocolateMatOn;
        private static bool _isStrawberryMatOn;
        private static bool _isStrawberryMilshakeFoamMatOn;
        private static bool _isCoffeeMatOn;
        private static bool _isCoralMatOn;
        private static bool _isCrystalMatOn = true;

        internal static bool isChocolateMatOn
        {
            get
            {
                return _isChocolateMatOn;
            }
            set
            {
                _isChocolateMatOn = value;
                if (value)
                {
                    isStrawberryMatOn = false;
                    isCoralMatOn = false;
                    isCoffeeMatOn = false;
                    isCrystalMatOn = false;
                    isStrawberryMilshakeFoamMatOn = false;
                }

            }
        }
        internal static bool isStrawberryMatOn
        {
            get
            {
                return _isStrawberryMatOn;
            }
            set
            {
                _isStrawberryMatOn = value;
                if (value)
                {
                    isChocolateMatOn = false;
                    isCoralMatOn = false;
                    isCrystalMatOn = false;
                    isCoffeeMatOn = false;
                    isStrawberryMilshakeFoamMatOn = false;
                }

            }
        }

        internal static bool isStrawberryMilshakeFoamMatOn
        {
            get
            {
                return _isStrawberryMilshakeFoamMatOn;
            }
            set
            {
                _isStrawberryMilshakeFoamMatOn = value;
                if (value)
                {
                    isChocolateMatOn = false;
                    isCoralMatOn = false;
                    isCrystalMatOn = false;
                    isCoffeeMatOn = false;
                    isStrawberryMatOn = false;
                }

            }
        }

        internal static bool isCoralMatOn
        {
            get
            {
                return _isCoralMatOn;
            }
            set
            {
                _isCoralMatOn = value;
                if (value)
                {
                    isChocolateMatOn = false;
                    isStrawberryMatOn = false;
                    isCrystalMatOn = false;
                    isCoffeeMatOn = false;
                    isStrawberryMilshakeFoamMatOn = false;
                }

            }
        }

        internal static bool isCrystalMatOn
        {
            get
            {
                return _isCrystalMatOn;
            }
            set
            {
                _isCrystalMatOn = value;
                if (value)
                {
                    isChocolateMatOn = false;
                    isStrawberryMatOn = false;
                    isCoralMatOn = false;
                    isCoffeeMatOn = false;
                    isStrawberryMilshakeFoamMatOn = false;
                }

            }
        }

        internal static bool isCoffeeMatOn
        {
            get
            {
                return _isCoffeeMatOn;
            }
            set
            {
                _isCoffeeMatOn = value;
                if (value)
                {
                    isChocolateMatOn = false;
                    isStrawberryMatOn = false;
                    isCoralMatOn = false;
                    isCrystalMatOn = false;
                    isStrawberryMilshakeFoamMatOn = false;
                }

            }
        }

        internal static void SpawnEnderPearl()
        {
            if (ENDER != null)
            {
                UnityEngine.Object.Destroy(ENDER);
                ENDER = null;
                return;
            }
            Vector3 bonePosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightHand);
            GameObject pearl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pearl.transform.SetParent(SpawnedItemsHolder.GetSpawnedItemsHolder().transform);
            pearl.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            pearl.transform.position = bonePosition;
            pearl.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            pearl.name = "EnderPearl (AstroClient)";
            pearl.AddToWorldUtilsMenu();
            var body = pearl.GetOrAddComponent<Rigidbody>();
            if (body != null)
            {
                body.useGravity = false;
            }
            pearl.RemoveAllColliders();
            pearl.GetOrAddComponent<EnderPearlBehaviour>();
            ENDER = pearl;
        }
    }
}