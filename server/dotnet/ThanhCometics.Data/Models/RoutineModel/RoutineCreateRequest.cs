namespace ThanhCometics.Repository.Models.RoutineModel
{
    public class RoutineCreateRequest
    {
        public string RoutineName { get; set; } = null!;
        public int SkinTypeId { get; set; }
        public bool Status { get; set; }
        public List<RoutineDetailCreateRequest> RoutineDetails { get; set; } = new List<RoutineDetailCreateRequest>();

    }
    public class RoutineDetailCreateRequest
    {
        public string RoutineDetailName { get; set; }
        public List<RoutineStepCreateRequest> RoutineSteps { get; set; } = new List<RoutineStepCreateRequest>();
    }
    public class RoutineStepCreateRequest
    {
        public int Step { get; set; }
        public string Instruction { get; set; }
        public int CategoryId { get; set; }
    }

}
