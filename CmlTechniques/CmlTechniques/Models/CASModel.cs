using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CmlTechniques.Models
{
    public class CASModel
    {
        public int documentId { get; set; }
        public string cableReference { get; set; }        
        public string panelReference { get; set; }
        public string fedFrom { get; set; }
        public string powerTo { get; set; }
        public string documentName { get; set; }
    }
}