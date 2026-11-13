using ThanhCometics.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Models.SkinTestModel
{
    public class SkinTypeAnswerRequest
    {
        public string Description {  get; set; }
        public int SkinTypeId { get; set; }
    }
    public class SkinTypeAnswerUpdateRequest
    {
        public int SkinTypeAnswerId { get; set; }
        public string Description { get; set; }
        public int SkinTypeId { get; set; }
    }
}
