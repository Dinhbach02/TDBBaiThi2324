using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;

namespace TDBBaiThi2324.Models
{
    [Table("TDB100Person")]
    public class TDB100Person
    {
        [Key]
        public string PersonID { get; set;}
        public string FullName { get; set;}
        public int Age { get; set;}
    }
}