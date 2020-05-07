using System.Collections.Generic;
using System.Threading.Tasks;
using Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.Audio;
using AudioType = Core.Enums.AudioType;
using DG.Tweening;

namespace Core
{
    public static class Audio
    {
        private static Factory _factory;
        private static readonly string _audioObjectPath = "Prefabs/Audio/AudioObject";

        private const string _backgroundClipPath =
            "Audio/background";

        private const string ButtonUIPath = "Audio/bloop";
        private const string CardClickPath = "Audio/card";
        private const string ApplausePath = "Audio/applause";

        private static List<AudioSource> _freeAudioSourceList;
        private static List<AudioSource> _playingSourceList;
        private static AudioSource _previousVoiceoverSource;

        [RuntimeInitializeOnLoadMethod]
        private static void ResetInit()
        {
            AudioBootstrap.ResetInit();
        }

        public static void InitAudio(Factory factory)
        {
            _factory = factory;
            _freeAudioSourceList = new List<AudioSource>();
            _playingSourceList = new List<AudioSource>();
        }

        public static void PlaySound(
            AudioType audio,
            bool loop = false)
        {
            AudioSource source = GetAudioSource(audio == AudioType.BACKGROUND);

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

        public static async Task FadeLastVoiceover()
        {
            if (_previousVoiceoverSource != null)
            {
                _playingSourceList.Remove(_previousVoiceoverSource);
                _previousVoiceoverSource.DOFade(0, 0.2f).OnComplete(() =>
                {
                    _freeAudioSourceList.Add(_previousVoiceoverSource);
                    _previousVoiceoverSource.volume = 1;
                    _previousVoiceoverSource.clip = null;
                    _previousVoiceoverSource = null;
                });
                await Task.Delay(201);
            }
        }

        public static void PlayVoiceover(AudioClip clip)
        {
            AudioSource source = GetAudioSource(false);
            _previousVoiceoverSource = source;
            source.clip = clip;
            source.Play();
        }

        private static async void StopAudio(
            AudioSource source,
            bool force = false)
        {
            if (force == false)
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
            }

            if (_playingSourceList.Contains(item: source) != true)
            {
                return;
            }

            source.Stop();
            source.clip = null;
            _playingSourceList.Remove(item: source);
            _freeAudioSourceList.Add(item: source);
        }

        private static AudioClip GetClipForAudioType(
            AudioType type)
        {
            switch (type)
            {
                case AudioType.BACKGROUND:
                    return Resources.Load<AudioClip>(path: _backgroundClipPath);
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

        private static AudioSource GetAudioSource(bool canParentFactory)
        {
            AudioSource source;
            if (_freeAudioSourceList.Count > 0)
            {
                source = _freeAudioSourceList[index: 0];
                _freeAudioSourceList.Remove(item: source);
            }
            else
            {
                source = _factory
                         .CreateGameObjectFromResources(path: _audioObjectPath, canParentFactory)
                         .GetComponent<AudioSource>();
            }

            _playingSourceList.Add(item: source);
            return source;
        }
    }
}