/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/piranhacms/piranha
 * 
 */

using System;
using Microsoft.AspNetCore.Identity;

namespace Piranha.AspNetCore.Identity.Data
{
    /// <summary>
    /// Application role.
    /// </summary>
    public sealed class Role : IdentityRole<Guid>
    {
    }
}