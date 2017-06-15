namespace MMXEngine.Contracts.ScriptMethods
{
    public interface IAudioMethods
    {
        void ResumeMusic();
        void PauseMusic();
        bool PlayMusic(string bgmFileName);
    }
}
