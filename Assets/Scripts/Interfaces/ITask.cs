public enum Goal
{
    Go,
    Gather
}

public interface ITask
{
    bool CheckTaskStatus();
    string TaskProgression();
    string TaskDescription();
}
