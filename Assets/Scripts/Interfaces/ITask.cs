public enum Goal
{
    Go,
    Gather
}

public interface ITask
{
    bool Completed();
    string TaskDescription();
}
