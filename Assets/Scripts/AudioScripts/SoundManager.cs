using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public enum SoundCat
{
    PUZZLE_SOLVE, // Misc Sounds
    METAL_SET_DOWN, CHAIN, // Ryan Sounds
    SLAB_GRAB, PAPYRUS_GRAB, STONE_SET_DOWN, // Ben Sounds
    AMBIENT_MUSIC, // Reggie Sounds
    SPIRIT_HAPPY, SPIRIT_NEUTRAL, SPIRIT_REMINISCENT, SPIRIT_SILLY, SPIRIT_SAD, SPIRIT_SCARED, // Caleb Sounds
    DOOR_MOVING, // David Sounds
    SIMON_1, SIMON_2, SIMON_3, SIMON_4, SIMON_5, SIMON_6, SIMON_SOUND, // CoNiya Sounds
}
public struct Range 
{
    private readonly float min;
    private readonly float max;

    public Range(float min, float max) {
        this.min = min;
        this.max = max;
    }

    public float GetRandom() {
        return Random.Range(min, max);
    }
}

public class SoundCollection
{
    private AudioClip[] clips;
    public SoundCollection(params string[] audioFiles){
        clips = new AudioClip[audioFiles.Length];
        for (int i = 0; i < clips.Length; i++){
            clips[i] = Resources.Load(audioFiles[i]) as AudioClip;
        }
    }
    public AudioClip GetRandClip(){
        if (clips.Length == 1) {
            return clips[0];
        } else {
            return clips [Random.Range(0, clips.Length)];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private Dictionary<SoundCat, SoundCollection> sounds;
    private AudioSource audioSource;
    public static SoundManager instance { get; private set; }
    private void Awake() {
        instance = this;
    }
    void Start() {
        audioSource = GetComponent<AudioSource>();
        sounds = new()
        {
            {SoundCat.PUZZLE_SOLVE, new("sounds/puzzle_solve") },
            
            {SoundCat.DOOR_MOVING, new("sounds/door/door_1", "sounds/door/door_2") },
            
            {SoundCat.AMBIENT_MUSIC, new("sounds/ambient_music") },
            
            {SoundCat.CHAIN, new("sounds/chain/chain_1", "sounds/chain/chain_2", "sounds/chain/chain_3") },
            {SoundCat.METAL_SET_DOWN, new("sounds/metal_set/metal_1", "sounds/metal_set/metal_2", "sounds/metal_set/metal_3") },
            
            {SoundCat.PAPYRUS_GRAB, new("sounds/papyrus_grab/papyrus_1", "sounds/papyrus_grab/papyrus_2") },
            {SoundCat.SLAB_GRAB, new("sounds/slab_grab/slab_1", "sounds/slab_grab/slab_2", "sounds/slab_grab/slab_3") },
            {SoundCat.STONE_SET_DOWN, new("sounds/stone_set/stone_1", "sounds/stone_set/stone_2", "sounds/stone_set/stone_3") },
            
            {SoundCat.SPIRIT_HAPPY, new("sounds/spirit_happy/happy_1", "sounds/spirit_happy/happy_2", "sounds/spirit_happy/happy_3") },
            {SoundCat.SPIRIT_NEUTRAL, new("sounds/spirit_neutral/neutral_1", "sounds/spirit_neutral/neutral_2", "sounds/spirit_neutral/neutral_3", "sounds/spirit_neutral/neutral_4") },
            {SoundCat.SPIRIT_SILLY, new("sounds/spirit_silly/silly_1", "sounds/spirit_silly/silly_2") },
            {SoundCat.SPIRIT_SCARED, new("sounds/spirit_scared/scared_1", "sounds/spirit_scared/scared_2", "spirit_scared/scared_3", "spirit_scared/scared_4", "spirit_scared/scared_5") },
            {SoundCat.SPIRIT_SAD, new("sounds/spirit_sad/sad_1", "sounds/spirit_sad/sad_2", "sounds/spirit_sad/sad_3", "sounds/spirit_sad/sad_4", "sounds/spirit_sad/sad_5", "sounds/spirit_sad/sad_6") },
            {SoundCat.SPIRIT_REMINISCENT, new("sounds/spirit_rem/rem_1", "sounds/spirit_rem/rem_2", "sounds/spirit_rem/rem_3", "sounds/spirit_rem/rem_4", "sounds/spirit_rem/rem_5") },

            {SoundCat.SIMON_1, new("sounds/simon/blue_sound") },
            {SoundCat.SIMON_2, new("sounds/simon/green_sound") },
            {SoundCat.SIMON_3, new("sounds/simon/orange_sound") },
            {SoundCat.SIMON_4, new("sounds/simon/purple_sound") },
            {SoundCat.SIMON_5, new("sounds/simon/red_sound") },
            {SoundCat.SIMON_6, new("sounds/simon/yellow_sound") },
            {SoundCat.SIMON_SOUND, new("sounds/simon/simon_sound") }
        };
    }

    public void Play(SoundCat category, AudioSource audioSource = null){
        if (sounds.ContainsKey(category)) {
            if (audioSource == null) {
                this.audioSource.clip = sounds[category].GetRandClip();
                this.audioSource.Play();
            } else {
                audioSource.clip = sounds[category].GetRandClip();
                audioSource.Play();
            }
        }
    }
    public void Play(string category, AudioSource audioSource) {
        SoundCat soundCat = SoundCat.Parse<SoundCat>(category, true);
        Play(soundCat, audioSource);
    }
    public void Play(string category) {
        Play(category, audioSource);
    }
}
