using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infraestructure.Factories
{
    public abstract class Creator
    {
        public abstract string ModelKey { get; }
        public abstract Vehicle Create();
    }
}
