using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace I.MES.Models
{
   public static class AssemblyHelper
    {

        public static Type GetEntityClassType(string className)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var classType = asm.GetTypes().Where(p => p.Name == className).FirstOrDefault();
            return classType;
        }
    }
}
