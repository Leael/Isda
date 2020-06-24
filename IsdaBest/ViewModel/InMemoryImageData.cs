using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsdaBest.ViewModel
{
    public class InMemoryImageData
    {
        public InMemoryImageData(byte[] image)
        {
            Image = image;
        }

        public readonly byte[] Image;
    }
}
