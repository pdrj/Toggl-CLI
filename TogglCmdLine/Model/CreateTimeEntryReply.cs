namespace TogglCmdLine.Model
{
    public struct CreateTimeEntryReply
    {
        public long Id { get; set; }
        public long WorkspaceId { get; set; }
        public string Name { get; set; }
    }
}