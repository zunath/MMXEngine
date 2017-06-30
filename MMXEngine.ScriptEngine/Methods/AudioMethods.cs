using System;
using System.IO.Abstractions;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using MMXEngine.Common.Attributes;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.ScriptMethods;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for modifying audio.
    /// </summary>
    [ScriptNamespace("Audio")]
    public class AudioMethods: IAudioMethods
    {
        private readonly IContentManager _contentManager;
        private readonly IFileSystem _fileSystem;
        
        /// <summary>
        /// Constructor for the AudioMethods class.
        /// </summary>
        /// <param name="contentManager">The MonoGame content manager</param>
        /// <param name="fileSystem">The file system</param>
        public AudioMethods(IContentManager contentManager,
            IFileSystem fileSystem)
        {
            _contentManager = contentManager;
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Resumes the currently loaded background music. 
        /// If a song hasn't been started with PlayMusic, this method will do nothing.
        /// If the song hasn't been paused, this method will do nothing.
        /// </summary>
        public void ResumeMusic()
        {
            if(MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();
        }

        /// <summary>
        /// Pauses the currently loaded background music.
        /// If a song hasn't been started with PlayMusic, this method will do nothing.
        /// If a song isn't running, this method will do nothing.
        /// </summary>
        public void PauseMusic()
        {
            if(MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Pause();
        }

        /// <summary>
        /// Plays the background music file with the name specified for bgmFileName. 
        /// If a file with that name does not exist nothing will happen and return value will be false.
        /// </summary>
        /// <param name="bgmFileName">Name of the background music file to play</param>
        /// <returns>If failed to play, return value will be false. Otherwise, true.</returns>
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

        /// <summary>
        /// Plays a sound effect. 
        /// If a file with that name does not exist nothing will happen.
        /// </summary>
        /// <param name="sfxFileName">Name of the sound effect file to play.</param>
        public void PlaySFX(string sfxFileName)
        {
            string path = ".\\Audio\\SFX\\" + sfxFileName;
            if (!_fileSystem.File.Exists(path))
                return;

            SoundEffect sfx = _contentManager.Load<SoundEffect>(path);
            sfx.Play();
        }
    }
}
