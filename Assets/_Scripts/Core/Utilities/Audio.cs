using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using AudioType = Core.Enums.AudioType;

namespace Core
{
    public static class Audio
    {
        private static Factory _factory;
        private static readonly string AudioObjectPath = "Prefabs/Audio/AudioObject";

        private const string BackgroundClipPath =
            "Audio/background";

        private const string ButtonUIPath = "Audio/bloop";
        private const string CardClickPath = "Audio/card";
        private const string ApplausePath = "Audio/applause";

        private static List<AudioSource> FreeAudioSourceList = new List<AudioSource>();
        private static List<AudioSource> PlayingSourceList = new List<AudioSource>();

        public static void InitAudio(Factory factory)
        {
            _factory = factory;
        }

        public static void PlaySound(
            AudioType audio,
            bool loop = false)
        {
            AudioSource source;
            if (FreeAudioSourceList.Count > 0)
            {
                source = FreeAudioSourceList[index: 0];
                FreeAudioSourceList.Remove(item: source);
            }
            else
            {
                source = _factory
                         .CreateGameObjectFromResources(path: AudioObjectPath, audio == AudioType.BACKGROUND)
                         .GetComponent<AudioSource>();
            }

            PlayingSourceList.Add(item: source);

            if (audio == AudioType.BACKGROUND)
            {
                source.outputAudioMixerGroup = Resources
                                               .Load<AudioMixer>(
                                                   path: "Audio/Mixer")
                                               .FindMatchingGroups(
                                                   subPath: "Background")[0];
            }
            else
            {
                source.outputAudioMixerGroup = Resources
                                               .Load<AudioMixer>(
                                                   path: "Audio/Mixer")
                                               .FindMatchingGroups(
                                                   subPath: "SFX")[0];
            }

            source.clip = GetClipForAudioType(type: audio);
            source.loop = loop;
            source.Play();

            if (loop != true)
            {
                StopAudio(source: source);
            }
        }

        private static async void StopAudio(
            AudioSource source)
        {
            if (source == null)
            {
                return;
            }

            if (source.clip == null)
            {
                return;
            }

            await Task.Delay(millisecondsDelay: (int) (source.clip.length * 1000));

            if (source == null)
            {
                return;
            }

            if (source.clip == null)
            {
                return;
            }

            if (PlayingSourceList.Contains(item: source) != true)
            {
                return;
            }

            source.Stop();
            source.clip = null;
            PlayingSourceList.Remove(item: source);
            FreeAudioSourceList.Add(item: source);
        }

        private static AudioClip GetClipForAudioType(
            AudioType type)
        {
            switch (type)
            {
                case AudioType.BACKGROUND:
                    return Resources.Load<AudioClip>(path: BackgroundClipPath);
                case AudioType.BUTTON_UI:
                    return Resources.Load<AudioClip>(path: ButtonUIPath);
                case AudioType.CARD_CLICK:
                    return Resources.Load<AudioClip>(path: CardClickPath);
                case AudioType.APPLAUSE:
                    return Resources.Load<AudioClip>(path: ApplausePath);
                default:
                    return Resources.Load<AudioClip>(path: ButtonUIPath);
            }
        }
    }
}