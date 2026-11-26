using System;
using System.Collections.Generic;

namespace ThanhCometics.Repository.Entities;

public partial class SkinTypeAnswer
{
    public int SkinTypeAnswerId { get; set; }

    public string Description { get; set; } = null!;

    public int SkinTypeQuestionId { get; set; }

    public virtual ICollection<SkinTypeAnswerSkinType> SkinTypeAnswerSkinTypes { get; set; } = null!;

    public virtual SkinTypeQuestion SkinTypeQuestion { get; set; } = null!;
}
