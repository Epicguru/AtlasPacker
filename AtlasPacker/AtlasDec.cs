using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPacker
{
    public class AtlasDec
    {
        public string RootDir { get; private set; }
        public string Name { get; private set; }
        public string[] Images { get; private set; }

        public AtlasDec(string root, string name, string[] images)
        {
            this.RootDir = root;
            this.Name = name;
            this.Images = images;
        }
    }
}
