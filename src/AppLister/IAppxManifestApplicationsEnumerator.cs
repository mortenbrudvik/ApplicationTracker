﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

namespace AppLister
{
    [Guid("9EB8A55A-F04B-4D0D-808D-686185D4847A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAppxManifestApplicationsEnumerator
    {
        IAppxManifestApplication GetCurrent();

        bool GetHasCurrent();

        bool MoveNext();
    }
}
