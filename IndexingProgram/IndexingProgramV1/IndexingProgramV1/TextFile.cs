using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexingProgramV1
{
    class TextFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Folder { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
