namespace Vakili.StoreTest.OperationLogs
{
    public class CreateOperationLogDto
    {
        public string Description { get; set; }
        public string? NewValue { get; set; }
        public string? OldValue { get; set; }
    }
}
