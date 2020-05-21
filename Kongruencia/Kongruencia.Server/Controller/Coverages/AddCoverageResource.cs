using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kongruencia.Server.Controller
{
    [XmlRoot(ElementName = "metadata")]
    public class AddCoverageResource
    {
        [XmlAttribute("productname")]
        [Required]
        public string ProductName { get; set; }

        [XmlAttribute("branchname")]
        [Required]
        public string BranchName { get; set; }

        [XmlAttribute("buildnumber")]
        [Required]
        public int Buildnumber { get; set; }

        [XmlElement("coverage")]
        [Required]
        public coverage Coverage { get; set; }
    }
}
