using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter.Factories
{
    public interface IDocumentConverter
    {
        void Convert(String data);
    }
}
