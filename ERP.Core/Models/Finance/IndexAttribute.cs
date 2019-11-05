using System;

namespace ERP.Core.Models.Finance
{
    internal class IndexAttribute : Attribute
    {
        public bool IsUnique { get; set; }
    }
}