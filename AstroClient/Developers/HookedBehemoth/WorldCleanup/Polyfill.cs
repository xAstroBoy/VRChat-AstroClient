/*
 * Copyright (c) 2021-2022 HookedBehemoth
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms and conditions of the GNU General Public License,
 * version 3, as published by the Free Software Foundation.
 *
 * This program is distributed in the hope it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using AvatarParameterAccess = ObjectPublicIAnimParameterAccessAnStInObLi1BoObSiAcUnique;
using AvatarParameterType = ObjectPublicIAnimParameterAccessAnStInObLi1BoObSiAcUnique.EnumNPublicSealedvaUnBoInFl5vUnique;

namespace AstroClient.HookedBehemoth.WorldCleanup;

public static class Polyfill {
    public static void RegisterAvatarCallback(Il2CppSystem.Action<Player, GameObject, VRC_AvatarDescriptor> callback) {
        VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 += callback;
    }

    public static VRCAvatarManager GetVRCAvatarManager(this VRCPlayer _this) {
        return _this.prop_VRCAvatarManager_0;
    }

    public static AvatarPlayableController GetAvatarPlayableController(this VRCAvatarManager _this) {
        return _this.field_Private_AvatarPlayableController_0;
    }

    //field_Private_Dictionary_2_Int32_AvatarParameterAccess_0
    public static Dictionary<int, AvatarParameterAccess> GetParameters(this AvatarPlayableController _this) {
        return _this.field_Private_Dictionary_2_Int32_ObjectPublicIAnimParameterAccessAnStInObLi1BoObSiAcUnique_0;
    }

    public static AvatarParameterType GetAvatarParameterType(this AvatarParameterAccess _this) {
        return _this.field_Public_EnumNPublicSealedvaUnBoInFl5vUnique_0;
    }
}