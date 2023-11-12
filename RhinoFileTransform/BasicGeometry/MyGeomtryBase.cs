using Rhino.FileIO;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public abstract class MyGeometryBase
    {
        // The Layer Index of The Geometry
        public int LayerIndex { get; private set; }
        // Object Type
        public string MyObjectType { get; } = "MyGeometryBase";


        /// <summary>
        /// Abstract Class for Every Geometry
        /// </summary>
        /// <param name="layerIndex"> The Geometry Layer Index int ptr </param>
        public MyGeometryBase(int layerIndex) 
        {
            this.LayerIndex = layerIndex;
        }

        public virtual string ToJson() 
        {
            Dictionary<string, object> jsonObject = new Dictionary<string, object>
            {
                { "LayerIndex", this.LayerIndex}
            };
            return JsonSerializer.Serialize(jsonObject);
        }

        public void SetLayerIndex(int layerIndex) => this.LayerIndex = layerIndex;
    }
}
