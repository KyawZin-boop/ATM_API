using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ApplicationConfig;

namespace Model.Enitities
{
    public class Files : Common
    {
        [Key]
        public Guid FileID { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string Uri { get; set; }
        public string ContentType { get; set; }
    }
}
