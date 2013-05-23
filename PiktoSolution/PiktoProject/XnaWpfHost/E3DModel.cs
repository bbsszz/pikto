using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
namespace Pikto
{
    class E3DModel
    {
          // Model's name to display
        public readonly string Name;

        // Model's transformation matrix in the real world (right-handed coordinate system)
        public readonly Matrix4x4 Transformation;

        // Model's size in real world (same units are used as for translation in transformation matrix)
        public readonly float Size;

        public E3DModel( string name, Matrix4x4 transformation, float size )
        {
            Name = name;
            Transformation = transformation;
            Size = size;
        }
    }
}
