using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model.Logic
{
    public static class ValidationExtension
    {
        public static Validator Rules(this string content) => new Validator(content); 
    }
}
