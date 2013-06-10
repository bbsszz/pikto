using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto.PictoModel
{
    class CategoryType
    {
        public string Name { get; private set; }

        public CategoryType(string name)
        {
            Name = name;
        }
    }
}
