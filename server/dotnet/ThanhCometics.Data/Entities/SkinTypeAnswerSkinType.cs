using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Entities
{
    public class SkinTypeAnswerSkinType
    {
        public int SkinTypeAnswerId { get; set; }
        public int SkinTypeId { get; set; }
        public SkinTypeAnswer SkinTypeAnswer { get; set; } = null!;
        public SkinType SkinType { get; set; } = null!;
    }
}
