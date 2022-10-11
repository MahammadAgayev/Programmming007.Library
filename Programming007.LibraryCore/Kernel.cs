using Programming007.LibraryCore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programming007.LibraryCore
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; }
    }
}
