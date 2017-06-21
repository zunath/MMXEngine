using System;
using System.IO.Abstractions;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using MMXEngine.Contracts.ScriptMethods;

namespace MMXEngine.ScriptEngine.Methods
{
    public class AudioMethods: IAudioMethods
    {
        private readonly ContentManager _contentManager;
        private readonly IFileSystem _fileSystem;

        public AudioMethods(ContentManager contentManager,
            IFileSystem fileSystem)
        {
            _contentManager = contentManager;
            _fileSystem = fileSystem;
        }

        public void ResumeMusic()
        {
            if(MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();
        }

        public void PauseMusic()
        {
            if(MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Pause();
        }

        public bool PlayMusic(string bgmFileName)
        {
            try
            {
                string path = ".\\Audio\\BGM\\" + bgmFileName;
                if (!_fileSystem.File.Exists(path))
                    return false;

                Song song = _contentManager.Load<Song>(path);
                MediaPlayer.Play(song);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void PlaySFX(string sfxFileName)
        {
            string path = ".\\Audio\\SFX\\" + sfxFileName;
            SoundEffect sfx = _contentManager.Load<SoundEffect>(path);
            sfx.Play();
        }
    }
}
