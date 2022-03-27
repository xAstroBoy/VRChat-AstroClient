using AstroClient.xAstroBoy.Extensions;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class TypeFinder
    {


        internal static Type GetExistingType(string fullname)
        {
            if(fullname.IsNotNullOrEmptyOrWhiteSpace())
            {
                return Type.GetType(fullname);

            }

            return null;
        }


    }
}
